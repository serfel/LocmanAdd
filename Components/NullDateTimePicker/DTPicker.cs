using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DataExplorer
{
    public partial class DTPicker : MaskedTextBox
    {
        public string NullValue;
        public DTPicker()
        { InitializeComponent();
            NullValue = "<Нет даты>";
            Mask = "00.00.0000";
            InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.Size = new Size(75, this.Height);
            Application.DoEvents();
            this.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(OnTypeValidationCompleted);
            this.Leave += new EventHandler(OnLeave);
        }

        
        public void AddMessageFilter()
        {
            //Application.AddMessageFilter(this);
        }
        public void RemoveMessageFilter()
        {
            //Application.RemoveMessageFilter(this);
        }
        /*
        protected override void WndProc(ref Message m)
        {
            switch ((WM)m.Msg)
            {
                case WM.WM_LBUTTONDOWN:
                    //ShowPropertyPages();
                    break;
                case WM.WM_SYSKEYDOWN:
                    break;
                case WM.WM_KEYDOWN:
                    int wParam = m.WParam.ToInt32();
                    switch ((VK)wParam)
                    {
                        case VK.VK_LEFT:
                        case VK.VK_RIGHT:
                            aaaaa();
                            break;
                        case VK.VK_UP:
                        case VK.VK_DOWN:
                            if (LowerLimit <= Temperature && UpperLimit >= Temperature)
                                Temperature--;
                            break;
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
        /*
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 641 && m.Msg != 642 && m.Msg != 132)
            { 
            
            }

            if (m.Msg == (int)WM.VK_LEFT) // Курсор влево
            {
                //MessageBox.Show("wow");
            }
            if (m.Msg == (int)WM.VK_RIGHT) // Курсор вправо
            {
                //MessageBox.Show("wow");
            }
            base.WndProc(ref m);
        }
        */

        public enum WM : int
        {
            #region Key Messages
            VK_LEFT = 0x25,
            VK_RIGHT = 0x27,
            #endregion
        }

        public void SetToNullValue()
        {
            Text = NullValue;
        }

        public void OnTypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                //toolTip1.ToolTipTitle = "Invalid Date";
                //toolTip1.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.", maskedTextBox1, 0, -20, 5000);
            }
            else
            {   //Now that the type has passed basic type validation, enforce more specific type rules.
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate < DateTime.Now)
                {   //toolTip1.ToolTipTitle = "Invalid Date";
                    MessageBox.Show("The date in this field must be greater than today's date.");
                    e.Cancel = true;
                }
            }
        }

        public void OnLeave(object sender, EventArgs e)
        {
            SelectionStart = 0;   
        }
    }
}
