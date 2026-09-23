using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace TXTextControl.Drawing
{
	/// <summary>The Drawing.ShapesContextMenuStrip class represents the default context menu of the Windows Forms TXDrawingControl.</summary>
	public class ShapesContextMenuStrip : ContextMenuStrip
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TXDrawing));

		private TXDrawingControl txdrawingControl_0;

		private Shape shape_0;

		private MenuItem menuItem_0 = new MenuItem();

		private MenuItem menuItem_1 = new MenuItem();

		private MenuItem menuItem_2 = new MenuItem();

		private MenuItem menuItem_3 = new MenuItem();

		private MenuItem menuItem_4 = new MenuItem();

		private MenuItem menuItem_5 = new MenuItem();

		private MenuItem menuItem_6 = new MenuItem();

		private MenuItem menuItem_7 = new MenuItem();

		private MenuItem menuItem_8 = new MenuItem();

		private MenuItem menuItem_9 = new MenuItem();

		private MenuItem menuItem_10 = new MenuItem();

		private MenuItem menuItem_11 = new MenuItem();

		private MenuItem menuItem_12 = new MenuItem();

		private MenuItem menuItem_13 = new MenuItem();

		private MenuItem menuItem_14 = new MenuItem();

		private MenuItem menuItem_15 = new MenuItem();

		private MenuItem menuItem_16 = new MenuItem();

		private MenuItem menuItem_17 = new MenuItem();

		private MenuItem menuItem_18 = new MenuItem();

		private MenuItem menuItem_19 = new MenuItem();

		private MenuItem menuItem_20 = new MenuItem();

		private MenuItem menuItem_21 = new MenuItem();

		private ToolStripSeparator toolStripSeparator_0 = new ToolStripSeparator();

		private ToolStripSeparator toolStripSeparator_1 = new ToolStripSeparator();

		private ToolStripSeparator toolStripSeparator_2 = new ToolStripSeparator();

		private ToolStripSeparator toolStripSeparator_3 = new ToolStripSeparator();

		private bool bool_0 = true;

		private ToolStripItem[] toolStripItem_0;

		private ToolStripItem[] toolStripItem_1;

		private Assembly assembly_0 = Assembly.GetAssembly(typeof(TXDrawing));

		/// <summary>Returns an array of System.Windows.Forms.ToolStripItem objects that represents those items which are displayed in the context menu strip when the control is right clicked inside a shape.</summary>
		public ToolStripItem[] SelectedShapesMenuItems
		{
			get
			{
				return this.toolStripItem_0;
			}
			set
			{
				this.toolStripItem_0 = value;
			}
		}

		/// <summary>Returns an array of System.Windows.Forms.ToolStripItem objects that represents those items which are displayed in the context menu strip when the control is right clicked outside a shape.</summary>
		public ToolStripItem[] StandardMenuItems
		{
			get
			{
				return this.toolStripItem_1;
			}
			set
			{
				this.toolStripItem_1 = value;
			}
		}

		internal ShapesContextMenuStrip()
		{
			this.Items.AddRange(new ToolStripMenuItem[1] { this.menuItem_2 });
		}

		private void method_0(string string_0, MenuItem menuItem_22)
		{
			int num = SystemInformation.MenuCheckSize.Width;
			string_0 = string_0 + "_" + ((num < 24) ? 16 : ((num < 32) ? 24 : 32));
			using Stream stream = this.assembly_0.GetManifestResourceStream("TXTextControl.Drawing.Items.small." + string_0 + ".png");
			menuItem_22.Image = System.Drawing.Image.FromStream(stream);
			menuItem_22.ImageScaling = ToolStripItemImageScaling.None;
		}

		internal void method_1(TXDrawingControl txdrawingControl_1)
		{
			this.txdrawingControl_0 = txdrawingControl_1;
			this.txdrawingControl_0.PropertyChanged += txdrawingControl_0_PropertyChanged;
			this.txdrawingControl_0.Selection.PropertyChanged += txdrawingControl_0_PropertyChanged;
			this.txdrawingControl_0.ChangedInternal += method_9;
			this.toolStripItem_0 = new ToolStripItem[15]
			{
				this.menuItem_0, this.menuItem_1, this.menuItem_2, this.toolStripSeparator_0, this.menuItem_3, this.menuItem_6, this.menuItem_9, this.menuItem_12, this.toolStripSeparator_1, this.menuItem_16,
				this.menuItem_17, this.menuItem_18, this.menuItem_19, this.toolStripSeparator_2, this.menuItem_20
			};
			this.toolStripItem_1 = new ToolStripItem[2] { this.menuItem_2, this.menuItem_21 };
			this.method_10();
			this.method_11();
			this.method_12();
			this.method_13();
			this.method_14();
			this.method_15();
			this.method_16();
			this.method_17();
			this.method_18();
			this.method_19();
			this.method_20();
			this.method_21();
			this.method_22();
			this.method_23();
			this.method_24();
			this.method_25();
			this.method_26();
			this.method_27();
			this.method_2();
		}

		private void txdrawingControl_0_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "CanCopy":
			{
				MenuItem menuItem = this.menuItem_0;
				bool enabled = (this.menuItem_1.Enabled = this.txdrawingControl_0.CanCopy);
				menuItem.Enabled = enabled;
				break;
			}
			case "CanPaste":
				this.menuItem_2.Enabled = this.txdrawingControl_0.CanPaste;
				break;
			case "CanBringForward":
			{
				MenuItem menuItem3 = this.menuItem_3;
				bool enabled3 = (this.menuItem_5.Enabled = this.txdrawingControl_0.Selection.CanBringForward);
				menuItem3.Enabled = enabled3;
				break;
			}
			case "CanBringToFront":
				this.menuItem_4.Enabled = this.txdrawingControl_0.Selection.CanBringToFront;
				break;
			case "CanSendBackward":
			{
				MenuItem menuItem2 = this.menuItem_6;
				bool enabled2 = (this.menuItem_8.Enabled = this.txdrawingControl_0.Selection.CanSendBackward);
				menuItem2.Enabled = enabled2;
				break;
			}
			case "CanSendToBack":
				this.menuItem_7.Enabled = this.txdrawingControl_0.Selection.CanSendToBack;
				break;
			case "Shapes":
				if (sender == this.txdrawingControl_0.Selection)
				{
					this.menuItem_10.CheckState = this.method_3();
					this.menuItem_11.CheckState = this.method_4();
					this.menuItem_16.CheckState = this.method_5();
					this.menuItem_17.CheckState = this.method_6();
					this.menuItem_18.CheckState = this.method_7();
					this.menuItem_19.Enabled = this.method_8();
				}
				break;
			}
		}

		private void method_2()
		{
			MenuItem menuItem = this.menuItem_0;
			bool enabled = (this.menuItem_1.Enabled = this.txdrawingControl_0.CanCopy);
			menuItem.Enabled = enabled;
			this.menuItem_2.Enabled = this.txdrawingControl_0.CanPaste;
			MenuItem menuItem2 = this.menuItem_3;
			bool enabled2 = (this.menuItem_5.Enabled = this.txdrawingControl_0.Selection.CanBringForward);
			menuItem2.Enabled = enabled2;
			this.menuItem_4.Enabled = this.txdrawingControl_0.Selection.CanBringToFront;
			MenuItem menuItem3 = this.menuItem_6;
			bool enabled3 = (this.menuItem_8.Enabled = this.txdrawingControl_0.Selection.CanSendBackward);
			menuItem3.Enabled = enabled3;
			this.menuItem_7.Enabled = this.txdrawingControl_0.Selection.CanSendToBack;
			this.menuItem_10.CheckState = this.method_3();
			this.menuItem_11.CheckState = this.method_4();
			this.menuItem_16.CheckState = this.method_5();
			this.menuItem_17.CheckState = this.method_6();
			this.menuItem_18.CheckState = this.method_7();
			this.menuItem_19.Enabled = this.method_8();
		}

		private CheckState method_3()
		{
			Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
			CheckState result = CheckState.Unchecked;
			if (shapes.Length > 0)
			{
				bool flag2 = (this.menuItem_10.Enabled = this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.FlipHorizontal));
				result = ((!flag2) ? CheckState.Indeterminate : (((this.txdrawingControl_0.Selection.Shapes[0].Flip & Flip.Horizontal) == Flip.Horizontal) ? CheckState.Checked : CheckState.Unchecked));
			}
			return result;
		}

		private CheckState method_4()
		{
			Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
			CheckState result = CheckState.Unchecked;
			if (shapes.Length > 0)
			{
				bool flag2 = (this.menuItem_11.Enabled = this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.FlipVertical));
				result = ((!flag2) ? CheckState.Indeterminate : (((this.txdrawingControl_0.Selection.Shapes[0].Flip & Flip.Vertical) == Flip.Vertical) ? CheckState.Checked : CheckState.Unchecked));
			}
			return result;
		}

		private CheckState method_5()
		{
			if (this.txdrawingControl_0.Selection.Shapes.Length > 0)
			{
				this.menuItem_19.Enabled = this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.CanFitToCanvas) && this.txdrawingControl_0.Selection.Shapes[0].CanFitToCanvas;
				if (this.menuItem_16.Enabled = this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.Movable))
				{
					if (!this.txdrawingControl_0.Selection.Shapes[0].Movable)
					{
						return CheckState.Unchecked;
					}
					return CheckState.Checked;
				}
				return CheckState.Indeterminate;
			}
			return CheckState.Unchecked;
		}

		private CheckState method_6()
		{
			if (this.txdrawingControl_0.Selection.Shapes.Length > 0)
			{
				if (this.menuItem_17.Enabled = this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.Sizable))
				{
					if (!this.txdrawingControl_0.Selection.Shapes[0].Sizable)
					{
						return CheckState.Unchecked;
					}
					return CheckState.Checked;
				}
				return CheckState.Indeterminate;
			}
			return CheckState.Unchecked;
		}

		private CheckState method_7()
		{
			if (this.txdrawingControl_0.Selection.Shapes.Length > 0)
			{
				if (this.menuItem_18.Enabled = this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.AutoSize))
				{
					if (!this.txdrawingControl_0.Selection.Shapes[0].AutoSize)
					{
						return CheckState.Unchecked;
					}
					return CheckState.Checked;
				}
				return CheckState.Indeterminate;
			}
			return CheckState.Unchecked;
		}

		private bool method_8()
		{
			if (this.txdrawingControl_0.Selection.Shapes.Length > 0)
			{
				if (this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.CanFitToCanvas))
				{
					if (!this.txdrawingControl_0.Selection.Shapes[0].CanFitToCanvas)
					{
						return false;
					}
					return true;
				}
				return true;
			}
			return false;
		}

		private void method_9(object sender, EventArgs e)
		{
			if (this.txdrawingControl_0.Selection.Shapes.Length > 0)
			{
				this.menuItem_19.Enabled = this.txdrawingControl_0.Selection.IsCommonValueSelected(Selection.Attribute.CanFitToCanvas) && this.txdrawingControl_0.Selection.Shapes[0].CanFitToCanvas;
			}
		}

		private void method_10()
		{
			this.menuItem_0.Click += menuItem_0_Click;
			this.menuItem_0.Text = this.resourceManager_0.GetString("ITM_CUT");
			this.method_0("cut", this.menuItem_0);
		}

		private void menuItem_0_Click(object sender, EventArgs e)
		{
			if (this.bool_0 && this.txdrawingControl_0.TXDrawing_0.method_15())
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_11()
		{
			this.menuItem_1.Click += menuItem_1_Click;
			this.menuItem_1.Text = this.resourceManager_0.GetString("ITM_COPY");
			this.method_0("copy", this.menuItem_1);
		}

		private void menuItem_1_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.Copy();
			}
		}

		private void method_12()
		{
			this.menuItem_2.Click += menuItem_2_Click;
			this.menuItem_2.Text = this.resourceManager_0.GetString("ITM_PASTE");
			this.method_0("paste", this.menuItem_2);
		}

		private void menuItem_2_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.TXDrawing_0.method_16(this.txdrawingControl_0.TXDrawing_0.MemoryStream_0);
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_13()
		{
			this.menuItem_3.Text = this.resourceManager_0.GetString("ITM_BRING_TO_FRONT_DROP_DOWN");
			this.menuItem_4.Click += menuItem_4_Click;
			this.menuItem_4.Text = this.resourceManager_0.GetString("ITM_BRING_TO_FRONT");
			this.menuItem_5.Click += menuItem_5_Click;
			this.menuItem_5.Text = this.resourceManager_0.GetString("ITM_BRING_FORWARD");
			this.method_0("zordertop", this.menuItem_3);
			this.method_0("zordertop", this.menuItem_4);
			this.method_0("zorderup", this.menuItem_5);
			this.menuItem_3.DropDownItems.Add(this.menuItem_4);
			this.menuItem_3.DropDownItems.Add(this.menuItem_5);
		}

		private void menuItem_5_Click(object sender, EventArgs e)
		{
			if (this.txdrawingControl_0.Selection.method_3())
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void menuItem_4_Click(object sender, EventArgs e)
		{
			if (this.txdrawingControl_0.Selection.method_4())
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_14()
		{
			this.menuItem_6.Text = this.resourceManager_0.GetString("ITM_SEND_TO_BACK_DROP_DOWN");
			this.menuItem_7.Click += menuItem_7_Click;
			this.menuItem_7.Text = this.resourceManager_0.GetString("ITM_SEND_TO_BACK");
			this.menuItem_8.Click += menuItem_8_Click;
			this.menuItem_8.Text = this.resourceManager_0.GetString("ITM_SEND_BACKWARD");
			this.method_0("zorderbottom", this.menuItem_6);
			this.method_0("zorderbottom", this.menuItem_7);
			this.method_0("zorderdown", this.menuItem_8);
			this.menuItem_6.DropDownItems.Add(this.menuItem_7);
			this.menuItem_6.DropDownItems.Add(this.menuItem_8);
		}

		private void menuItem_8_Click(object sender, EventArgs e)
		{
			if (this.txdrawingControl_0.Selection.method_5())
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void menuItem_7_Click(object sender, EventArgs e)
		{
			if (this.txdrawingControl_0.Selection.method_6())
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_15()
		{
			this.menuItem_9.Text = this.resourceManager_0.GetString("ITM_FLIP_DROP_DOWN");
			this.method_0("shapefliphorizontally", this.menuItem_9);
			this.menuItem_9.DropDownItems.Add(this.menuItem_10);
			this.menuItem_9.DropDownItems.Add(this.menuItem_11);
		}

		private void method_16()
		{
			this.menuItem_10.CheckedChanged += menuItem_10_CheckedChanged;
			this.menuItem_10.Click += menuItem_10_Click;
			this.menuItem_10.CheckOnClick = true;
			this.menuItem_10.Text = this.resourceManager_0.GetString("ITM_FLIP_HORIZONTAL");
		}

		private void menuItem_10_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void menuItem_10_CheckedChanged(object sender, EventArgs e)
		{
			if (this.bool_0 && this.menuItem_10.Enabled)
			{
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					Flip flip = (this.menuItem_10.Checked ? Flip.Horizontal : Flip.None);
					Flip flip2 = (((shape.Flip & Flip.Vertical) == Flip.Vertical) ? Flip.Vertical : Flip.None);
					shape.method_6(flip | flip2);
				}
			}
		}

		private void method_17()
		{
			this.menuItem_11.CheckedChanged += menuItem_11_CheckedChanged;
			this.menuItem_11.Click += menuItem_11_Click;
			this.menuItem_11.CheckOnClick = true;
			this.menuItem_11.Text = this.resourceManager_0.GetString("ITM_FLIP_VERTICAL");
		}

		private void menuItem_11_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void menuItem_11_CheckedChanged(object sender, EventArgs e)
		{
			if (this.bool_0 && this.menuItem_11.Enabled)
			{
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					Flip flip = (((shape.Flip & Flip.Horizontal) == Flip.Horizontal) ? Flip.Horizontal : Flip.None);
					Flip flip2 = (this.menuItem_11.Checked ? Flip.Vertical : Flip.None);
					shape.method_6(flip | flip2);
				}
			}
		}

		private void method_18()
		{
			this.menuItem_12.Text = this.resourceManager_0.GetString("ITM_ROTATE_DROP_DOWN");
			this.method_0("shaperotateright90", this.menuItem_12);
			this.menuItem_12.DropDownItems.Add(this.menuItem_13);
			this.menuItem_12.DropDownItems.Add(this.menuItem_14);
			this.menuItem_12.DropDownItems.Add(this.menuItem_15);
		}

		private void method_19()
		{
			this.menuItem_13.Click += menuItem_13_Click;
			this.menuItem_13.Text = this.resourceManager_0.GetString("ITM_ROTATE_90_RIGHT");
			this.method_0("shaperotateright90", this.menuItem_13);
		}

		private void menuItem_13_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					shape.method_4(shape.Angle + 90);
				}
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_20()
		{
			this.menuItem_14.Click += menuItem_14_Click;
			this.menuItem_14.Text = this.resourceManager_0.GetString("ITM_ROTATE_90_LEFT");
			this.method_0("shaperotateleft90", this.menuItem_14);
		}

		private void menuItem_14_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					shape.method_4(shape.Angle - 90);
				}
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_21()
		{
			this.menuItem_15.Click += menuItem_15_Click;
			this.menuItem_15.Text = this.resourceManager_0.GetString("ITM_ROTATE_180");
			this.method_0("shaperotate180", this.menuItem_15);
		}

		private void menuItem_15_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					shape.method_4(shape.Angle + 180);
				}
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_22()
		{
			this.menuItem_16.CheckedChanged += menuItem_16_CheckedChanged;
			this.menuItem_16.Click += menuItem_16_Click;
			this.menuItem_16.CheckOnClick = true;
			this.menuItem_16.Text = this.resourceManager_0.GetString("ITM_MOVABLE");
		}

		private void menuItem_16_CheckedChanged(object sender, EventArgs e)
		{
			if (this.bool_0 && this.menuItem_16.Enabled)
			{
				bool flag = false;
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					flag |= shape.method_7(this.menuItem_16.Checked);
				}
				if (flag)
				{
					this.txdrawingControl_0.Selection.method_27();
				}
			}
		}

		private void menuItem_16_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: false, bool_7: true, bool_8: true);
			}
		}

		private void method_23()
		{
			this.menuItem_17.CheckedChanged += menuItem_17_CheckedChanged;
			this.menuItem_17.Click += menuItem_17_Click;
			this.menuItem_17.CheckOnClick = true;
			this.menuItem_17.Text = this.resourceManager_0.GetString("ITM_SIZABLE");
		}

		private void menuItem_17_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0 || !this.menuItem_17.Enabled)
			{
				return;
			}
			bool flag = false;
			Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
			foreach (Shape shape in shapes)
			{
				if (this.menuItem_17.CheckState != CheckState.Indeterminate)
				{
					flag |= shape.method_8(this.menuItem_17.Checked);
				}
			}
			if (flag)
			{
				this.txdrawingControl_0.Selection.method_29();
			}
		}

		private void menuItem_17_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void method_24()
		{
			this.menuItem_18.CheckedChanged += menuItem_18_CheckedChanged;
			this.menuItem_18.Click += menuItem_18_Click;
			this.menuItem_18.CheckOnClick = true;
			this.menuItem_18.Text = this.resourceManager_0.GetString("ITM_SIZE_AUTOMATICALLY");
		}

		private void menuItem_18_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		private void menuItem_18_CheckedChanged(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					shape.method_5(this.menuItem_18.Checked);
				}
			}
		}

		private void method_25()
		{
			this.menuItem_19.Click += menuItem_19_Click;
			this.menuItem_19.Text = this.resourceManager_0.GetString("ITM_FIT_TO_CANVAS");
			this.method_0("shape_fittocanvas", this.menuItem_19);
		}

		private void menuItem_19_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				Shape[] shapes = this.txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					shape.method_2();
				}
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
				this.menuItem_19.Enabled = false;
			}
		}

		private void method_26()
		{
			this.menuItem_20.Click += menuItem_20_Click;
			this.menuItem_20.Text = this.resourceManager_0.GetString("ITM_FORMAT_SHAPES_DIALOG");
			this.method_0("shape_format", this.menuItem_20);
		}

		private void menuItem_20_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.txdrawingControl_0.method_4(bool_2: true, 0);
			}
		}

		private void method_27()
		{
			this.menuItem_21.Click += menuItem_21_Click;
			this.menuItem_21.Text = this.resourceManager_0.GetString("ITM_SELECT_ALL");
			this.method_0("shape_selectall", this.menuItem_21);
		}

		private void menuItem_21_Click(object sender, EventArgs e)
		{
			if (this.bool_0 && this.txdrawingControl_0.TXDrawing_0.method_17())
			{
				this.txdrawingControl_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		protected override void OnMouseDown(MouseEventArgs mea)
		{
			if (mea.Button == MouseButtons.Right)
			{
				this.bool_0 = false;
			}
			else
			{
				this.bool_0 = true;
			}
			base.OnMouseDown(mea);
		}

		protected override void OnOpening(CancelEventArgs cancelEventArgs_0)
		{
			if (!this.txdrawingControl_0.Visible)
			{
				cancelEventArgs_0.Cancel = true;
			}
			this.Items.Clear();
			this.shape_0 = this.txdrawingControl_0.method_13();
			if (this.shape_0 == null)
			{
				this.method_28(this.toolStripItem_1);
			}
			else
			{
				this.method_28(this.toolStripItem_0);
			}
			base.OnOpening(cancelEventArgs_0);
		}

		protected override void Dispose(bool disposing)
		{
			if (this.txdrawingControl_0 != null)
			{
				this.txdrawingControl_0.ChangedInternal -= method_9;
			}
			base.Dispose(disposing);
		}

		private void method_28(ToolStripItem[] toolStripItem_2)
		{
			foreach (ToolStripItem value in toolStripItem_2)
			{
				this.Items.Add(value);
			}
		}
	}
}
