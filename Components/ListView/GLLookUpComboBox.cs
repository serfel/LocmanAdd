using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace GlacialComponents.Controls
{
    public partial class ComboxBoxEx : ComboBox
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner 
            public int Top;         // y position of upper-left corner 
            public int Right;       // x position of lower-right corner 
            public int Bottom;      // y position of lower-right corner 
        }

        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020;
        public const int SWP_NOOWNERZORDER = 0x0200;

        public const int WM_CTLCOLORLISTBOX = 0x0134;

        private int _hwndDropDown = 0;

        internal List<int> ItemHeights = new List<int>();

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CTLCOLORLISTBOX)
            {
                if (_hwndDropDown == 0)
                {
                    _hwndDropDown = m.LParam.ToInt32();

                    if (ItemHeights.Count == 0) return;

                    RECT r;
                    GetWindowRect((IntPtr)_hwndDropDown, out r);

                    int newHeight = 0;
                    int n = (Items.Count > MaxDropDownItems) ? MaxDropDownItems : Items.Count;
                    for (int i = 0; i < n; i++)
                    {
                        newHeight += ItemHeights[i];
                    }
                    newHeight += 5; //to stop scrollbars showing

                    SetWindowPos((IntPtr)_hwndDropDown, IntPtr.Zero,
                        r.Left,
                                 r.Top,
                                 DropDownWidth,
                                 newHeight,
                                 SWP_FRAMECHANGED |
                                     SWP_NOACTIVATE |
                                     SWP_NOZORDER |
                                     SWP_NOOWNERZORDER);
                }
            }

            base.WndProc(ref m);
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            _hwndDropDown = 0;
            base.OnDropDownClosed(e);
        }
    }

    public class GLLookUpComboBox : ComboxBoxEx, GLEmbeddedControl
    {
        bool сохранениеЋиста;
        public bool —охранениеЋиста
        {
            get
            {
                return сохранениеЋиста;
            }
            set
            {
                сохранениеЋиста = value;
            }
        }

        /// <summary>
        /// OnKeyPress event component checks that user entered a correct symbol, 
        /// which corresponds to item in item list. If symbol is correct the field takes value true, otherwise - false
        /// Field is used when allowTypeAllSymbols is true. 
        /// </summary>
        private bool isTextCorrect;

        private bool allowTypeAllSymbols = true;

        public GLLookUpComboBox() : base()
        {
            this.MeasureItem += comboBox_MeasureItem;
            this.DrawItem += comboBox_DrawItem;
            this.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            this.Enter += comboBox_Enter;
            this.Leave += comboBox_Leave;
            this.LostFocus += comboBox_Leave;
        }

        protected void comboBox_Enter(object sender, EventArgs e)
        {
            if (!сохранениеЋиста) return;
            try
            {
                ComboxBoxEx cbox = (ComboxBoxEx)sender;
                string outName = System.Windows.Forms.Application.StartupPath + "\\—правочники\\" + cbox.Parent.Name + cbox.Name + cbox.Tag.ToString();
                if (!File.Exists(outName)) { File.WriteAllText(outName, ""); return; }

                string[] ret = File.ReadAllLines(outName);
                base.Items.Clear();
                for (int x = 0; x < ret.Length; x++)
                    base.Items.Add(ret[x]);
            }
            catch { }
        }

        protected void comboBox_Leave(object sender, EventArgs e)
        {
            if (!сохранениеЋиста) return;
            ComboxBoxEx cbox = (ComboxBoxEx)sender;
            try
            {
                string outName = System.Windows.Forms.Application.StartupPath + "\\—правочники\\" + cbox.Parent.Name + cbox.Name + cbox.Tag.ToString();
                if (!File.Exists(outName)) File.WriteAllText(outName, "");

                string[] ret = new string[base.Items.Count];

                return;

                if (!base.Items.Contains(cbox.Text) && cbox.Text != "")
                {
                    ret = new string[base.Items.Count + 1];
                    for (int x = 0; x < base.Items.Count; x++)
                        ret[x] = base.Items[x].ToString();
                    ret[base.Items.Count] = cbox.Text;
                }
                else
                {
                    for (int x = 0; x < base.Items.Count; x++)
                        ret[x] = base.Items[x].ToString();
                }
                cbox.Sorted = true;
                File.WriteAllLines(outName, ret);
            }
            catch { }
        }

        protected void comboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            ComboxBoxEx cbox = (ComboxBoxEx)sender;
            //DataRowView item = (DataRowView)cbox.Items[e.Index];
            //string txt = item["address"].ToString();
            string txt = cbox.Items[e.Index].ToString();

            int height = Convert.ToInt32(e.Graphics.MeasureString(txt, cbox.Font).Height);

            e.ItemHeight = height * 5 + 4;
            e.ItemWidth = cbox.DropDownWidth;

            cbox.ItemHeights.Add(e.ItemHeight);
        }

        private void comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboxBoxEx cbox = (ComboxBoxEx)sender;
            
            //DataRowView item = (DataRowView)cbox.Items[e.Index];
            //string txt = item["address"].ToString();
            string txt = cbox.Items[e.Index].ToString();

            e.DrawBackground();
            e.Graphics.DrawString(txt, cbox.Font, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height * 5));
            e.Graphics.DrawLine(new Pen(Color.LightGray), e.Bounds.X, e.Bounds.Top + e.Bounds.Height - 1, e.Bounds.Width, e.Bounds.Top + e.Bounds.Height * 5 - 1);
            e.DrawFocusRectangle();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboxBoxEx cbox = (ComboxBoxEx)sender;
            if (cbox.SelectedItem == null) return;

           // DataRowView item = (DataRowView)cbox.SelectedItem;

            //label1.Text = item["id"].ToString();
        }

        /// <summary>
        /// If the property is true you can type any symbols in combo-box textbox. 
        /// The item will be selected according to first correctly entered symbols. 
        /// For example, combobox holds "Item 1", "Item 2", "Test 1", "Test 2", "Combo", "Box"
        /// If you enter "it" the Item 1 will be selected. Then if you enter "itm". 
        /// The "Item 1" still will be selected. You can continue to enter any amount of symbols. 
        /// 
        /// If AllTypeAllSymbols is false. You will be able to enter only those symbols, 
        /// that are defined in strings of Items (or bound DateSource) propertу. For this example 
        /// you will be able to enter only i, t, c, b as a first symbol. If you enter "i" as a 
        /// first symbol Ц "Item 1" will be automatically selected, the second symbol can be 
        /// only "t", you will be not able to enter any other symbol. "Item 2" will be selected, 
        /// until you type the whole string "Item 2". 
        /// </summary>
        [Browsable(true)]
        public bool AllowTypeAllSymbols
        {
            set
            {
                allowTypeAllSymbols = value;
            }
            get
            {
                return allowTypeAllSymbols;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!allowTypeAllSymbols)
            {
                isTextCorrect = false;
                if (!char.IsControl(e.KeyChar))
                {
                    string actual = this.Text.Substring(0, SelectionStart) + e.KeyChar;

                    // Find the first match for the typed value.
                    int index = this.FindString(actual);

                    // if correspondig item is found set isTextCorrect property to true.
                    if (index > -1)
                    {
                        isTextCorrect = true;
                        base.OnKeyPress(e);
                    }
                    else
                        e.Handled = true;
                }

            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            int index;
            string actual;
            string found;

            // Do nothing for certain keys, such as navigation keys.
            if ((e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                (e.KeyCode == Keys.Up) ||
                (e.KeyCode == Keys.Down) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.PageUp) ||
                (e.KeyCode == Keys.PageDown) ||
                (e.KeyCode == Keys.Home) ||
                (e.KeyCode == Keys.End) ||
                (e.KeyCode == Keys.ShiftKey) ||
                (e.KeyCode == Keys.Tab) ||
                (e.KeyCode == Keys.Menu))
            {
                return;
            }

            // Store the actual text that has been typed.
            actual = this.Text.Substring(0, this.SelectionStart);

            // Find the first match for the typed value.
            index = this.FindString(actual);

            // If current text is correct
            if (index > -1)
            {
                if ((!allowTypeAllSymbols && isTextCorrect) || (allowTypeAllSymbols))
                {
                    // If data are bound to combo-box
                    if (this.DataSource != null && this.DisplayMember != "")
                        found = ((DataRowView)(this.Items[index]))[this.DisplayMember].ToString();
                    else
                        found = this.Items[index].ToString();

                    // Select this item from the list.
                    this.SelectedIndex = index;
                    this.Text = found;

                    // Select the portion of the text that was automatically
                    // added so that additional typing replaces it.
                    this.SelectionStart = actual.Length;
                    this.SelectionLength = found.Length;
                    base.OnKeyUp(e);
                }
            }
        }

        #region GLEmbeddedControl Members

        public GLItem Item
        {
            get
            {
                return m_item;
            }
            set
            {
                m_item = value;
            }
        }

        public GLSubItem SubItem
        {
            get
            {
                return m_subItem;
            }
            set
            {
                m_subItem = value;
            }
        }

        public GlacialList ListControl
        {
            get
            {
                return m_Parent;
            }
            set
            {
                m_Parent = value;
            }
        }

        public string GLReturnText()
        {
            return this.Text;
        }

        protected GLItem m_item = null;
        protected GLSubItem m_subItem = null;
        protected GlacialList m_Parent = null;

        public bool GLLoad(GLItem item, GLSubItem subItem, GlacialList listctrl, object[] obj)
        {
            m_item = item;
            m_subItem = subItem;
            m_Parent = listctrl;

            this.Text = subItem.Text;
            if (obj != null) this.Items.AddRange(obj);
            //this.Items.Add( "i2" );
            //this.Items.Add( "i3" );

            return true;
        }

        public void GLUnload()
        {
            m_subItem.Text = this.Text;
        }


        #endregion

    }
}
