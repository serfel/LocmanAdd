using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ns20;
using ns25;
using TXTextControl;
using TXTextControl.Barcode;
using TXTextControl.DataVisualization;
using TXTextControl.Drawing;
using TXTextControl.ProxyClasses.Charts;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class477 : BindingAdapter
	{
		internal class Class485
		{
			private string string_0;

			private double double_0;

			private double double_1;

			private double double_2;

			private double double_3;

			internal string String_0 => this.string_0;

			internal double Double_0 => this.double_0;

			internal double Double_1 => this.double_1;

			internal double Double_2 => this.double_2;

			internal double Double_3 => this.double_3;

			internal Class485(string string_1, double double_4, double double_5, double double_6, double double_7)
			{
				this.string_0 = string_1;
				this.double_0 = double_4;
				this.double_1 = double_5;
				this.double_2 = double_6;
				this.double_3 = double_7;
			}
		}

		private Class506 class506_0;

		private RibbonLabel ribbonLabel_0;

		private Class485[] class485_0 = new Class485[5]
		{
			new Class485(DateTime.Today.AddDays(-4.0).ToString("d"), 55.0, 11.0, 44.0, 25.0),
			new Class485(DateTime.Today.AddDays(-3.0).ToString("d"), 57.0, 12.0, 25.0, 38.0),
			new Class485(DateTime.Today.AddDays(-2.0).ToString("d"), 57.0, 13.0, 38.0, 48.0),
			new Class485(DateTime.Today.AddDays(-1.0).ToString("d"), 58.0, 11.0, 48.0, 34.0),
			new Class485(DateTime.Today.ToString("d"), 36.0, 5.0, 34.0, 18.0)
		};

		private string[] string_0 = new string[5] { "Ada", "Bob", "Cyd", "Dan", "Eve" };

		private double[] double_0 = new double[5] { 4.2, 2.5, 3.4, 4.5, 3.7 };

		private double[] double_1 = new double[5] { 2.3, 4.2, 1.8, 2.8, 2.1 };

		private double[] double_2 = new double[5] { 2.0, 2.0, 3.0, 5.0, 4.0 };

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class506_0;
			}
			set
			{
				this.class506_0 = value as Class506;
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				ribbonMenuButton.DropDownOpening += method_78;
				this.ribbonLabel_0 = new RibbonLabel
				{
					Text = base.m_rmResourceManager.GetString(RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTableGallery.ToString().Replace("TXITEM", "HEADER")),
					Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTableGalleryHeader.ToString()
				};
				((IRibbonItem)this.ribbonLabel_0).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(this.ribbonLabel_0.Name, this.ribbonLabel_0);
				RibbonListView ribbonListView = this.method_1(dictionary_0, 10, 8);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTableSeperator.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTableDialog.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[4] { this.ribbonLabel_0, ribbonListView, ribbonSeperator2, ribbonButton });
			}
		}

		private RibbonListView method_1(Dictionary<string, object> dictionary_0, int int_0, int int_1)
		{
			RibbonListView ribbonListView = new RibbonListView();
			ribbonListView.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTableGallery.ToString();
			RibbonListView ribbonListView2 = ribbonListView;
			((IRibbonItem)ribbonListView2).IsDefaultRibbonTabItem = true;
			ribbonListView2.MouseLeave += method_81;
			ribbonListView2.LostFocus += method_81;
			ribbonListView2.ItemMouseEnter += method_79;
			ribbonListView2.ItemMouseUp += method_80;
			ribbonListView2.MinColumnCount = int_0;
			ribbonListView2.CellPadding = new Padding(0);
			int num = 0;
			int num2 = 0;
			int num3 = int_1 * int_0;
			for (int i = 0; i < num3; i++)
			{
				RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
				num = i % int_0;
				num2 = i / int_0;
				ribbonListViewItem.Tag = new int[2]
				{
					num + 1,
					num2 + 1
				};
				ribbonListView2.RibbonListViewItems.Add(ribbonListViewItem);
			}
			dictionary_0.Add(ribbonListView2.Name, ribbonListView2);
			return ribbonListView2;
		}

		private void method_2(RibbonListView ribbonListView_0, PointF pointF_0)
		{
			int width = Class517.smethod_45(Class519.Class533.Size_0.Width, pointF_0.X);
			int height = Class517.smethod_45(Class519.Class533.Size_0.Height, pointF_0.Y);
			int x = Class517.smethod_45(Class519.Class533.Point_0.X, pointF_0.X);
			int y = Class517.smethod_45(Class519.Class533.Point_0.Y, pointF_0.Y);
			int num = Class517.smethod_45(Class519.Class533.Size_1.Width, pointF_0.X);
			int num2 = Class517.smethod_45(Class519.Class533.Size_1.Height, pointF_0.Y);
			int num3 = Class517.smethod_45(Class519.Class533.Int32_0, pointF_0.X);
			foreach (RibbonListView.RibbonListViewItem ribbonListViewItem in ribbonListView_0.RibbonListViewItems)
			{
				Bitmap bitmap = new Bitmap(width, height);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.Clear(Color.Transparent);
				graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), num3), new Rectangle(x, y, bitmap.Width - num, bitmap.Height - num2));
				graphics.Dispose();
				ribbonListViewItem.Icon = bitmap;
			}
		}

		private void method_3(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertImageDialog.ToString(), null, this);
				ribbonButton.Click += TXITEM_InsertImage_Handler;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertImagePlaceHolder.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonButton, ribbonButton2 });
			}
		}

		private void method_4(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) == null)
			{
				return;
			}
			if (Class440.Assembly_0 == null)
			{
				if (ribbonMenuButton.ParentCollection != null)
				{
					ribbonMenuButton.ParentCollection.Remove(ribbonMenuButton);
				}
				return;
			}
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_ColumnCategory.ToString(), null, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_ColumnGallery.ToString(), new RibbonInsertTab.ChartTemplate[7]
			{
				RibbonInsertTab.ChartTemplate.ClusteredColumn,
				RibbonInsertTab.ChartTemplate.StackedColumn,
				RibbonInsertTab.ChartTemplate.StackedColumn100Percent,
				RibbonInsertTab.ChartTemplate.ClusteredColumn3D,
				RibbonInsertTab.ChartTemplate.StackedColumn3D,
				RibbonInsertTab.ChartTemplate.StackedColumn100Percent3D,
				RibbonInsertTab.ChartTemplate.Column3D
			});
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_LineCategory.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_LineSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_LineGallery.ToString(), new RibbonInsertTab.ChartTemplate[3]
			{
				RibbonInsertTab.ChartTemplate.Line,
				RibbonInsertTab.ChartTemplate.LineWithMarkers,
				RibbonInsertTab.ChartTemplate.Line3D
			});
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_PieCategory.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_PieSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_PieGallery.ToString(), new RibbonInsertTab.ChartTemplate[3]
			{
				RibbonInsertTab.ChartTemplate.Pie,
				RibbonInsertTab.ChartTemplate.Pie3D,
				RibbonInsertTab.ChartTemplate.Doughnut
			});
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_BarCategory.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_BarSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_BarGallery.ToString(), new RibbonInsertTab.ChartTemplate[6]
			{
				RibbonInsertTab.ChartTemplate.ClusteredBar,
				RibbonInsertTab.ChartTemplate.StackedBar,
				RibbonInsertTab.ChartTemplate.StackedBar100Percent,
				RibbonInsertTab.ChartTemplate.ClusteredBar3D,
				RibbonInsertTab.ChartTemplate.StackedBar3D,
				RibbonInsertTab.ChartTemplate.StackedBar100Percent3D
			});
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_AreaCategory.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_AreaSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_AreaGallery.ToString(), new RibbonInsertTab.ChartTemplate[6]
			{
				RibbonInsertTab.ChartTemplate.Area,
				RibbonInsertTab.ChartTemplate.StackedArea,
				RibbonInsertTab.ChartTemplate.StackedArea100Percent,
				RibbonInsertTab.ChartTemplate.Area3D,
				RibbonInsertTab.ChartTemplate.StackedArea3D,
				RibbonInsertTab.ChartTemplate.StackedArea100Percent3D
			});
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_XYScatterCategory.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_XYScatterSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_XYScatterGallery.ToString(), new RibbonInsertTab.ChartTemplate[7]
			{
				RibbonInsertTab.ChartTemplate.Scatter,
				RibbonInsertTab.ChartTemplate.ScatterWithSmoothLinesAndMarkers,
				RibbonInsertTab.ChartTemplate.ScatterWithSmoothLines,
				RibbonInsertTab.ChartTemplate.ScatterWithStraightLinesAndMarkers,
				RibbonInsertTab.ChartTemplate.ScatterWithStraightLines,
				RibbonInsertTab.ChartTemplate.Bubble,
				RibbonInsertTab.ChartTemplate.Bubble3D
			});
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_StockCategory.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_StockSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_StockGallery.ToString(), new RibbonInsertTab.ChartTemplate[2]
			{
				RibbonInsertTab.ChartTemplate.HighLowClose,
				RibbonInsertTab.ChartTemplate.OpenHighLowClose
			});
			base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_RadarCategory.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_RadarSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_RadarGallery.ToString(), new RibbonInsertTab.ChartTemplate[3]
			{
				RibbonInsertTab.ChartTemplate.Radar,
				RibbonInsertTab.ChartTemplate.RadarWithMarkers,
				RibbonInsertTab.ChartTemplate.FilledRadar
			});
		}

		private void method_5(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_LinesCategory, null, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertShapeLinesGallery, new ShapeType[3]
				{
					ShapeType.Line,
					ShapeType.BentConnector3,
					ShapeType.CurvedConnector3
				});
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_RectanglesCategory, RibbonInsertTab.InternalRibbonItem.TXITEM_RectanglesSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_RectanglesGallery, new ShapeType[9]
				{
					ShapeType.Rectangle,
					ShapeType.RoundRectangle,
					ShapeType.Snip1Rectangle,
					ShapeType.Snip2SameRectangle,
					ShapeType.Snip2DiagonalRectangle,
					ShapeType.SnipRoundRectangle,
					ShapeType.Round1Rectangle,
					ShapeType.Round2SameRectangle,
					ShapeType.Round2DiagonalRectangle
				});
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_BasicShapesCategory, RibbonInsertTab.InternalRibbonItem.TXITEM_BasicShapesSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_BasicShapesGallery, new ShapeType[41]
				{
					ShapeType.Ellipse,
					ShapeType.Triangle,
					ShapeType.RightTriangle,
					ShapeType.Parallelogram,
					ShapeType.NonIsoscelesTrapezoid,
					ShapeType.Diamond,
					ShapeType.Pentagon,
					ShapeType.Hexagon,
					ShapeType.Heptagon,
					ShapeType.Octagon,
					ShapeType.Decagon,
					ShapeType.Dodecagon,
					ShapeType.Pie,
					ShapeType.Chord,
					ShapeType.Teardrop,
					ShapeType.Frame,
					ShapeType.HalfFrame,
					ShapeType.Corner,
					ShapeType.DiagonalStripe,
					ShapeType.Plus,
					ShapeType.Plaque,
					ShapeType.Can,
					ShapeType.Cube,
					ShapeType.Bevel,
					ShapeType.Donut,
					ShapeType.NoSmoking,
					ShapeType.BlockArc,
					ShapeType.FoldedCorner,
					ShapeType.SmileyFace,
					ShapeType.Heart,
					ShapeType.LightningBolt,
					ShapeType.Sun,
					ShapeType.Moon,
					ShapeType.Cloud,
					ShapeType.Arc,
					ShapeType.BracketPair,
					ShapeType.BracePair,
					ShapeType.LeftBracket,
					ShapeType.RightBracket,
					ShapeType.LeftBrace,
					ShapeType.RightBrace
				});
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_BlockArrowsCategory, RibbonInsertTab.InternalRibbonItem.TXITEM_BlockArrowsSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_BlockArrowsGallery, new ShapeType[27]
				{
					ShapeType.RightArrow,
					ShapeType.LeftArrow,
					ShapeType.UpArrow,
					ShapeType.DownArrow,
					ShapeType.LeftRightArrow,
					ShapeType.UpDownArrow,
					ShapeType.QuadArrow,
					ShapeType.LeftRightUpArrow,
					ShapeType.BentArrow,
					ShapeType.UTurnArrow,
					ShapeType.LeftUpArrow,
					ShapeType.BentUpArrow,
					ShapeType.CurvedRightArrow,
					ShapeType.CurvedLeftArrow,
					ShapeType.CurvedUpArrow,
					ShapeType.CurvedDownArrow,
					ShapeType.StripedRightArrow,
					ShapeType.NotchedRightArrow,
					ShapeType.HomePlate,
					ShapeType.Chevron,
					ShapeType.RightArrowCallout,
					ShapeType.DownArrowCallout,
					ShapeType.LeftArrowCallout,
					ShapeType.UpArrowCallout,
					ShapeType.LeftRightArrowCallout,
					ShapeType.QuadArrowCallout,
					ShapeType.CircularArrow
				});
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_EquationShapesCategory, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertShapeEquationShapesSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_InsertShapeEquationShapesGallery, new ShapeType[6]
				{
					ShapeType.MathPlus,
					ShapeType.MathMinus,
					ShapeType.MathMultiply,
					ShapeType.MathDivide,
					ShapeType.MathEqual,
					ShapeType.MathNotEqual
				});
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_FlowChartCategory, RibbonInsertTab.InternalRibbonItem.TXITEM_FlowChartSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_FlowChartGallery, new ShapeType[28]
				{
					ShapeType.FlowChartProcess,
					ShapeType.FlowChartAlternateProcess,
					ShapeType.FlowChartDecision,
					ShapeType.FlowChartInputOutput,
					ShapeType.FlowChartPredefinedProcess,
					ShapeType.FlowChartInternalStorage,
					ShapeType.FlowChartDocument,
					ShapeType.FlowChartMultidocument,
					ShapeType.FlowChartTerminator,
					ShapeType.FlowChartPreparation,
					ShapeType.FlowChartManualInput,
					ShapeType.FlowChartManualOperation,
					ShapeType.FlowChartConnector,
					ShapeType.FlowChartOffpageConnector,
					ShapeType.FlowChartPunchedCard,
					ShapeType.FlowChartPunchedTape,
					ShapeType.FlowChartSummingJunction,
					ShapeType.FlowChartOr,
					ShapeType.FlowChartCollate,
					ShapeType.FlowChartSort,
					ShapeType.FlowChartExtract,
					ShapeType.FlowChartMerge,
					ShapeType.FlowChartOnlineStorage,
					ShapeType.FlowChartDelay,
					ShapeType.FlowChartMagneticTape,
					ShapeType.FlowChartMagneticDisk,
					ShapeType.FlowChartMagneticDrum,
					ShapeType.FlowChartDisplay
				});
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_StarsAndBannersCategory, RibbonInsertTab.InternalRibbonItem.TXITEM_StarsAndBannersSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_StarsAndBannersGallery, new ShapeType[20]
				{
					ShapeType.IrregularSeal1,
					ShapeType.IrregularSeal2,
					ShapeType.Star4,
					ShapeType.Star5,
					ShapeType.Star6,
					ShapeType.Star7,
					ShapeType.Star8,
					ShapeType.Star10,
					ShapeType.Star12,
					ShapeType.Star16,
					ShapeType.Star24,
					ShapeType.Star32,
					ShapeType.Ribbon2,
					ShapeType.Ribbon,
					ShapeType.EllipseRibbon2,
					ShapeType.EllipseRibbon,
					ShapeType.VerticalScroll,
					ShapeType.HorizontalScroll,
					ShapeType.Wave,
					ShapeType.DoubleWave
				});
				this.method_6(dictionary_0, ribbonMenuButton.DropDownItems, RibbonInsertTab.InternalRibbonItem.TXITEM_CalloutsCategory, RibbonInsertTab.InternalRibbonItem.TXITEM_CalloutsSeperator.ToString(), RibbonInsertTab.InternalRibbonItem.TXITEM_CalloutsGallery, new ShapeType[16]
				{
					ShapeType.WedgeRectangleCallout,
					ShapeType.WedgeRoundRectangleCallout,
					ShapeType.WedgeEllipseCallout,
					ShapeType.CloudCallout,
					ShapeType.BorderCallout1,
					ShapeType.BorderCallout2,
					ShapeType.BorderCallout3,
					ShapeType.AccentCallout1,
					ShapeType.AccentCallout2,
					ShapeType.AccentCallout3,
					ShapeType.Callout1,
					ShapeType.Callout2,
					ShapeType.Callout3,
					ShapeType.AccentBorderCallout1,
					ShapeType.AccentBorderCallout2,
					ShapeType.AccentBorderCallout3
				});
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertShapeSeperator.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertDrawingCanvas.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_DrawingMarkerLines.ToString(), "Click", this);
				ribbonToggleButton.Checked = true;
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonSeperator2, ribbonButton, ribbonToggleButton });
			}
		}

		private void method_6(Dictionary<string, object> dictionary_0, RibbonItemCollection ribbonItemCollection_0, RibbonInsertTab.InternalRibbonItem internalRibbonItem_0, string string_1, RibbonInsertTab.InternalRibbonItem internalRibbonItem_1, ShapeType[] shapeType_0)
		{
			if (string_1 != null)
			{
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = string_1;
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				ribbonItemCollection_0.Add(ribbonSeperator2);
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
			}
			RibbonLabel ribbonLabel = new RibbonLabel();
			ribbonLabel.Text = base.m_rmResourceManager.GetString(internalRibbonItem_0.ToString().Replace("TXITEM", "HEADER"));
			ribbonLabel.Name = internalRibbonItem_0.ToString();
			RibbonLabel ribbonLabel2 = ribbonLabel;
			((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
			ribbonItemCollection_0.Add(ribbonLabel2);
			dictionary_0.Add(ribbonLabel2.Name, ribbonLabel2);
			RibbonListView ribbonListView = new RibbonListView();
			ribbonListView.MinColumnCount = 12;
			ribbonListView.Name = internalRibbonItem_1.ToString();
			RibbonListView ribbonListView2 = ribbonListView;
			((IRibbonItem)ribbonListView2).IsDefaultRibbonTabItem = true;
			foreach (ShapeType shapeType_ in shapeType_0)
			{
				ribbonListView2.RibbonListViewItems.Add(this.method_7(shapeType_));
			}
			dictionary_0.Add(ribbonListView2.Name, ribbonListView2);
			ribbonListView2.ItemClick += method_82;
			ribbonItemCollection_0.Add(ribbonListView2);
		}

		private RibbonListView.RibbonListViewItem method_7(ShapeType shapeType_0)
		{
			RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
			ribbonListViewItem.Tag = shapeType_0;
			ribbonListViewItem.String_0 = "TXITEM_SHAPE_" + shapeType_0;
			RibbonListView.RibbonListViewItem ribbonListViewItem2 = ribbonListViewItem;
			ribbonListViewItem2.ToolTip.Title = base.m_rmResourceManager.GetString("TOOLTIPTITLE_SHAPE_" + shapeType_0);
			ribbonListViewItem2.ToolTip.Description = base.m_rmResourceManager.GetString("TOOLTIP_SHAPE_" + shapeType_0);
			return ribbonListViewItem2;
		}

		private void method_8(Dictionary<string, object> dictionary_0, RibbonMenuButton ribbonMenuButton_0)
		{
			try
			{
				Control7 control = (Control7)base.m_txTextControl.textControlCore_0.control4_0.CreateControlProxy(null);
				List<Control> list = new List<Control>();
				string[] array = control.method_3();
				foreach (string string_ in array)
				{
					this.method_9(dictionary_0, ribbonMenuButton_0.DropDownItems, string_);
				}
				ribbonMenuButton_0.DropDownItems.AddRange(list.ToArray());
			}
			catch
			{
				if (ribbonMenuButton_0.ParentCollection != null)
				{
					ribbonMenuButton_0.ParentCollection.Remove(ribbonMenuButton_0);
				}
			}
		}

		private void method_9(Dictionary<string, object> dictionary_0, RibbonItemCollection ribbonItemCollection_0, string string_1)
		{
			RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, "TXITEM_BARCODE_" + string_1, null, this);
			ribbonButton.Text = string_1;
			ribbonButton.ToolTip.Title = base.m_rmResourceManager.GetString("TOOLTIPTITLE_" + string_1);
			ribbonButton.ToolTip.Description = base.m_rmResourceManager.GetString("TOOLTIP_" + string_1);
			ribbonButton.Click += method_83;
			ribbonItemCollection_0.Add(ribbonButton);
		}

		private void method_10(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertHyperlinkDialog.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_EditHyperlink.ToString(), null, this);
				ribbonButton2.Click += TXITEM_InsertHyperlinkDialog_Handler;
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonButton, ribbonButton2 });
				ribbonMenuButton.DropDownOpening += method_84;
			}
		}

		private void method_11(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertBookmarkDialog.ToString(), "Click", this);
				ribbonButton.IsAddToQuickAccessToolbarEnabled = false;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_DeleteBookmark.ToString(), "Click", this);
				ribbonButton2.IsAddToQuickAccessToolbarEnabled = false;
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_EditBookmark.ToString(), null, this);
				ribbonButton3.IsAddToQuickAccessToolbarEnabled = false;
				ribbonButton3.Click += TXITEM_InsertBookmarkDialog_Handler;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertBookmarkSeperator.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonInsertTab.InternalRibbonItem.TXITEM_DocumentTargetMarkers.ToString(), "Click", this);
				ribbonToggleButton.Checked = true;
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonButton, ribbonButton2, ribbonButton3, ribbonSeperator2, ribbonToggleButton });
				ribbonMenuButton.DropDownOpening += method_85;
			}
		}

		private void method_12(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_EditHeader.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_RemoveHeader.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonButton, ribbonButton2 });
				ribbonMenuButton.DropDownOpening += method_86;
			}
		}

		private void method_13(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_EditFooter.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_RemoveFooter.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonButton, ribbonButton2 });
				ribbonMenuButton.DropDownOpening += TXITEM_InsertFooter_DropDownOpening;
			}
		}

		private void method_14(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_InsertStandardPageNumber.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_FormatPageNumber.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_RemovePageNumber.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonButton, ribbonButton2, ribbonButton3 });
			}
		}

		private void method_15(bool bool_0)
		{
			RibbonButton ribbonButton = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertStandardPageNumber.ToString()] as RibbonButton;
			ribbonButton.Enabled = !bool_0;
			RibbonButton ribbonButton2 = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_FormatPageNumber.ToString()] as RibbonButton;
			RibbonButton ribbonButton3 = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_RemovePageNumber.ToString()] as RibbonButton;
			bool enabled = (ribbonButton3.Enabled = bool_0);
			ribbonButton2.Enabled = enabled;
		}

		private void method_16(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_AddTextFrame.ToString(), null, this);
				ribbonButton.Click += TXITEM_InsertTextFrame_Handler;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTextFrameSeperator.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonInsertTab.InternalRibbonItem.TXITEM_TextFrameMarkerLines.ToString(), "Click", this);
				ribbonToggleButton.Checked = false;
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonButton, ribbonSeperator2, ribbonToggleButton });
			}
		}

		private void method_17(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton;
			if ((ribbonMenuButton = control_0 as RibbonMenuButton) != null)
			{
				RibbonListView ribbonListView = this.method_18(dictionary_0);
				ribbonListView.ItemClick += method_87;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertSymbolSeperator.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonInsertTab.InternalRibbonItem.TXITEM_MoreSymbols.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonListView, ribbonSeperator2, ribbonButton });
			}
		}

		private RibbonListView method_18(Dictionary<string, object> dictionary_0)
		{
			string[] array = new string[20]
			{
				"™", "ß", "€", "£", "¥", "©", "®", "±", "≠", "≤",
				"≥", "÷", "×", "∞", "µ", "α", "π", "Ω", "∑", "☺"
			};
			RibbonListView ribbonListView = new RibbonListView();
			ribbonListView.MinColumnCount = 5;
			ribbonListView.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_SymbolGallery.ToString();
			ribbonListView.ViewMode = RibbonListView.ListViewMode.Text;
			RibbonListView ribbonListView2 = ribbonListView;
			((IRibbonItem)ribbonListView2).IsDefaultRibbonTabItem = true;
			string[] array2 = array;
			foreach (string text in array2)
			{
				ribbonListView2.RibbonListViewItems.Add(new RibbonListView.RibbonListViewItem
				{
					Text = text,
					Tag = text
				});
			}
			dictionary_0.Add(ribbonListView2.Name, ribbonListView2);
			return ribbonListView2;
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			this.method_2(this.class506_0.TXITEM_TableGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTableGallery.ToString()] as RibbonListView, dpi);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertShapeLinesGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_RectanglesGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_BasicShapesGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_BlockArrowsGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertShapeEquationShapesGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_FlowChartGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_StarsAndBannersGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_CalloutsGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Small_16x16);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_ColumnGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_LineGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_PieGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_BarGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_AreaGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_XYScatterGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_StockGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart_RadarGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_InsertTable":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertImage":
				this.method_3(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertShape":
				this.method_5(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertChart":
				this.method_4(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertHyperlink":
				this.method_10(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertBookmark":
				this.method_11(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertHeader":
				this.method_12(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertFooter":
				this.method_13(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertPageNumber":
				this.method_14(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertTextFrame":
				this.method_16(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertSymbol":
				this.method_17(groupItemsDictionary, ribbonItem);
				break;
			}
			if (!string.IsNullOrEmpty(eventName))
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.HeaderFooterActivated -= method_88;
			base.m_txTextControl.HeaderFooterDeactivated -= method_91;
			base.m_txTextControl.TextFieldLeft -= method_89;
			base.m_txTextControl.TextFieldEntered -= method_90;
		}

		internal override void OnTextControlConnected()
		{
			RibbonSplitButton ribbonMenuButton_ = this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertBarcode.ToString()] as RibbonSplitButton;
			this.method_8(this.class506_0.TXITEM_IllustrationsGroup_Items, ribbonMenuButton_);
			base.m_txTextControl.HeaderFooterActivated += method_88;
			base.m_txTextControl.HeaderFooterDeactivated += method_91;
		}

		private void method_19()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Selection.Text = ((base.m_txTextControl.InputPosition.TextPosition == base.m_txTextControl.TextChars.Count) ? "\f" : "\f\f");
				base.m_txTextControl.ScrollLocation = new Point(base.m_txTextControl.InputPosition.Location.X, base.m_txTextControl.InputPosition.Location.Y - 1440);
			}
		}

		private void method_20()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TextChars.Add(ControlChars.PageBreak);
				base.m_txTextControl.ScrollLocation = new Point(base.m_txTextControl.InputPosition.Location.X, base.m_txTextControl.InputPosition.Location.Y - 1440);
			}
		}

		private void method_21(RibbonMenuButton ribbonMenuButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			bool canAdd = base.m_txTextControl.Tables.CanAdd;
			foreach (Control dropDownItem in ribbonMenuButton_0.DropDownItems)
			{
				if ((dropDownItem as IRibbonItem).IsDefaultRibbonTabItem)
				{
					dropDownItem.Enabled = canAdd;
				}
			}
		}

		private void method_22(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			List<RibbonListView.RibbonListViewItem> list = new List<RibbonListView.RibbonListViewItem>();
			int[] array = ribbonListViewItemEventArgs_0.Item.Tag as int[];
			foreach (RibbonListView.RibbonListViewItem ribbonListViewItem in ribbonListView_0.RibbonListViewItems)
			{
				int[] array2 = ribbonListViewItem.Tag as int[];
				if (array2[0] <= array[0] && array2[1] <= array[1])
				{
					list.Add(ribbonListViewItem);
				}
			}
			if (this.ribbonLabel_0 != null)
			{
				this.ribbonLabel_0.Text = ((this.class506_0.Control_0.RightToLeft == RightToLeft.Yes) ? (base.m_rmResourceManager.GetString("HEADER_InsertTableGallerySize") + array[1] + base.m_rmResourceManager.GetString("HEADER_InsertTableGallerySizeTimesSign") + array[0]) : (array[0] + base.m_rmResourceManager.GetString("HEADER_InsertTableGallerySizeTimesSign") + array[1] + base.m_rmResourceManager.GetString("HEADER_InsertTableGallerySize")));
			}
			ribbonListView_0.SelectedItems = list.ToArray();
		}

		private void method_23(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl.Tables.CanAdd)
			{
				int[] array = ribbonListViewItemEventArgs_0.Item.Tag as int[];
				base.m_txTextControl.Tables.Add(array[1], array[0]);
			}
		}

		private void method_24(RibbonListView ribbonListView_0)
		{
			ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[0];
			if (this.ribbonLabel_0 != null)
			{
				this.ribbonLabel_0.Text = base.m_rmResourceManager.GetString(RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTableGallery.ToString().Replace("TXITEM", "HEADER"));
			}
		}

		private void method_25()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Tables.Add();
			}
		}

		private void method_26()
		{
			if (base.m_txTextControl != null)
			{
				var image = new Image();
				base.m_txTextControl.Images.Add(image, -1);
			}
		}

		private void method_27()
		{
			if (base.m_txTextControl != null)
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				UnmanagedMemoryStream unmanagedMemoryStream = executingAssembly.GetManifestResourceStream("TXTextControl.Images.placeholder.emf") as UnmanagedMemoryStream;
				if (unmanagedMemoryStream != null)
				{
					var image = new Image(unmanagedMemoryStream);
					base.m_txTextControl.Images.Add(image, -1);
				}
			}
		}

		private void method_28(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_InsertChart_ColumnGallery":
				case "TXITEM_InsertChart_LineGallery":
				case "TXITEM_InsertChart_PieGallery":
				case "TXITEM_InsertChart_BarGallery":
				case "TXITEM_InsertChart_AreaGallery":
				case "TXITEM_InsertChart_XYScatterGallery":
				case "TXITEM_InsertChart_StockGallery":
				case "TXITEM_InsertChart_RadarGallery":
					this.method_60((RibbonInsertTab.ChartTemplate)Enum.Parse(typeof(RibbonInsertTab.ChartTemplate), ribbonListViewItemEventArgs_0.Item.Tag.ToString()));
					ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[0];
					break;
				}
			}
		}

		private void method_29(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_InsertShapeLinesGallery":
				case "TXITEM_RectanglesGallery":
				case "TXITEM_BasicShapesGallery":
				case "TXITEM_BlockArrowsGallery":
				case "TXITEM_InsertShapeEquationShapesGallery":
				case "TXITEM_FlowChartGallery":
				case "TXITEM_StarsAndBannersGallery":
				case "TXITEM_CalloutsGallery":
					this.method_67((ShapeType)Enum.Parse(typeof(ShapeType), ribbonListViewItemEventArgs_0.Item.Tag.ToString()));
					ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[0];
					break;
				}
			}
		}

		private void method_30()
		{
			if (base.m_txTextControl != null)
			{
				HeaderFooter headerFooter = base.m_txTextControl.TextParts.GetItem() as HeaderFooter;
				TXDrawingControl drawing = new TXDrawingControl(7000, 4000);
				DrawingFrame drawingFrame = new DrawingFrame(drawing);
				if (headerFooter == null)
				{
					base.m_txTextControl.Drawings.Add(drawingFrame, HorizontalAlignment.Left, -1, FrameInsertionMode.DisplaceText);
				}
				else
				{
					base.m_txTextControl.Drawings.Add(drawingFrame, new Point(1000, 100), FrameInsertionMode.BelowTheText);
				}
				drawingFrame.Activate();
			}
		}

		private void method_31(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DrawingMarkerLines = bool_0;
			}
		}

		private void method_32(string string_1)
		{
			if (base.m_txTextControl != null)
			{
				Control7 control = (Control7)base.m_txTextControl.textControlCore_0.control4_0.CreateControlProxy(null);
				TXBarcodeControl tXBarcodeControl = control.Component as TXBarcodeControl;
				tXBarcodeControl.Size = Class517.smethod_48(Class519.Class533.Size_2, base.m_pntDPI);
				tXBarcodeControl.BarcodeType = (BarcodeType)Enum.Parse(typeof(BarcodeType), string_1);
				BarcodeFrame barcodeFrame = new BarcodeFrame(tXBarcodeControl);
				base.m_txTextControl.Barcodes.Add(barcodeFrame, -1);
			}
		}

		private void method_33()
		{
			RibbonButton ribbonButton = this.class506_0.TXITEM_LinksGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertHyperlinkDialog.ToString()] as RibbonButton;
			ribbonButton.Enabled = this.method_68();
			RibbonButton ribbonButton2 = this.class506_0.TXITEM_LinksGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_EditHyperlink.ToString()] as RibbonButton;
			ribbonButton2.Enabled = this.method_69();
		}

		private void method_34()
		{
			if (base.m_txTextControl != null)
			{
				HyperlinkDialog hyperlinkDialog = new HyperlinkDialog(base.m_txTextControl);
				hyperlinkDialog.Font = new Font("Segoe UI", 9f, GraphicsUnit.Point);
				hyperlinkDialog.Owner = base.m_txTextControl.FindForm();
				hyperlinkDialog.ShowDialog();
			}
		}

		private void method_35()
		{
			RibbonButton ribbonButton = this.class506_0.TXITEM_LinksGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertBookmarkDialog.ToString()] as RibbonButton;
			ribbonButton.Enabled = this.method_70();
			RibbonButton ribbonButton2 = this.class506_0.TXITEM_LinksGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_DeleteBookmark.ToString()] as RibbonButton;
			ribbonButton2.Enabled = this.method_71();
			RibbonButton ribbonButton3 = this.class506_0.TXITEM_LinksGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_EditBookmark.ToString()] as RibbonButton;
			ribbonButton3.Enabled = this.method_72();
		}

		private void method_36(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				RibbonButton ribbonButton = this.class506_0.TXITEM_LinksGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertBookmarkDialog.ToString()] as RibbonButton;
				DocumentTarget bookmarkToEdit = ((ribbonButton_0 == ribbonButton) ? null : base.m_txTextControl.DocumentTargets.GetItem());
				BookmarkDialog bookmarkDialog = new BookmarkDialog(base.m_txTextControl, bookmarkToEdit);
				bookmarkDialog.ShowDialog();
			}
		}

		private void method_37()
		{
			if (base.m_txTextControl != null)
			{
				DeleteBookmarksDialog deleteBookmarksDialog = new DeleteBookmarksDialog(base.m_txTextControl);
				deleteBookmarksDialog.ShowDialog();
			}
		}

		private void method_38(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DocumentTargetMarkers = bool_0;
			}
		}

		private void method_39()
		{
			if (this.method_75() && base.m_txTextControl != null)
			{
				this.method_76(HeaderFooterType.Header);
			}
		}

		private void method_40()
		{
			RibbonButton ribbonButton = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_EditHeader.ToString()] as RibbonButton;
			ribbonButton.Enabled = this.method_75();
			RibbonButton ribbonButton2 = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_RemoveHeader.ToString()] as RibbonButton;
			ribbonButton2.Enabled = this.method_73();
		}

		private void method_41()
		{
			if (base.m_txTextControl != null)
			{
				this.method_76(HeaderFooterType.Header);
			}
		}

		private void method_42()
		{
			if (base.m_txTextControl != null)
			{
				this.method_77(base.m_txTextControl.GetPages().GetItem().Header);
			}
		}

		private void method_43()
		{
			if (this.method_75() && base.m_txTextControl != null)
			{
				this.method_76(HeaderFooterType.Footer);
			}
		}

		private void method_44()
		{
			if (base.m_txTextControl != null)
			{
				RibbonButton ribbonButton = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_EditFooter.ToString()] as RibbonButton;
				ribbonButton.Enabled = this.method_75();
				RibbonButton ribbonButton2 = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_RemoveFooter.ToString()] as RibbonButton;
				ribbonButton2.Enabled = this.method_74();
			}
		}

		private void method_45()
		{
			if (base.m_txTextControl != null)
			{
				this.method_76(HeaderFooterType.Footer);
			}
		}

		private void method_46()
		{
			if (base.m_txTextControl != null)
			{
				this.method_77(base.m_txTextControl.GetPages().GetItem().Footer);
			}
		}

		private void method_47()
		{
			if (base.m_txTextControl != null)
			{
				HeaderFooter headerFooter = base.m_txTextControl.TextParts.GetItem() as HeaderFooter;
				if (headerFooter != null)
				{
					headerFooter.PageNumberFields.Add(new PageNumberField());
					this.method_15(headerFooter.PageNumberFields.GetItem() != null);
				}
			}
		}

		private void method_48()
		{
			if (base.m_txTextControl != null)
			{
				(base.m_txTextControl.TextParts.GetItem() as HeaderFooter)?.PageNumberFields.GetItem()?.PageNumberDialog();
			}
		}

		private void method_49()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			HeaderFooter headerFooter = base.m_txTextControl.TextParts.GetItem() as HeaderFooter;
			if (headerFooter != null)
			{
				PageNumberField item = headerFooter.PageNumberFields.GetItem();
				if (item != null)
				{
					headerFooter.PageNumberFields.Remove(item);
					this.method_15(headerFooter.PageNumberFields.GetItem() != null);
				}
			}
		}

		private void method_50()
		{
			if (base.m_txTextControl != null)
			{
				TextFrame textFrame = new TextFrame(new Size(2880, 2880));
				HeaderFooter headerFooter = base.m_txTextControl.TextParts.GetItem() as HeaderFooter;
				base.m_txTextControl.TextFrames.Add(textFrame, (headerFooter == null) ? ((TextFrameInsertionMode)65544) : TextFrameInsertionMode.BelowTheText);
			}
		}

		private void method_51(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TextFrameMarkerLines = bool_0;
			}
		}

		private void method_52()
		{
			if (base.m_txTextControl != null)
			{
				LoadSettings loadSettings = new LoadSettings();
				loadSettings.ApplicationFieldFormat = ApplicationFieldFormat.MSWord;
				loadSettings.DocumentPartName = string.Empty;
				LoadSettings loadSettings2 = loadSettings;
				base.m_txTextControl.Selection.Load(StreamType.All, loadSettings2);
			}
		}

		private void method_53(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				string text = ribbonListViewItemEventArgs_0.Item.Tag as string;
				if (text != null && base.m_txTextControl != null)
				{
					base.m_txTextControl.Selection.Text = text;
				}
				ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[0];
			}
		}

		private void method_54()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.AddSymbolDialog();
			}
		}

		private void method_55(HeaderFooterEventArgs headerFooterEventArgs_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertPageNumber.ToString()] as RibbonMenuButton;
			if (this.class506_0.method_3(ribbonMenuButton))
			{
				ribbonMenuButton.Enabled = base.m_txTextControl.CanEdit;
				this.method_15(headerFooterEventArgs_0.HeaderFooter.PageNumberFields.GetItem() != null);
			}
			base.m_txTextControl.TextFieldEntered += method_90;
			base.m_txTextControl.TextFieldLeft += method_89;
		}

		private void method_56(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (textFieldEventArgs_0.TextField is PageNumberField)
			{
				this.method_15(bool_0: false);
			}
		}

		private void method_57(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (textFieldEventArgs_0.TextField is PageNumberField)
			{
				this.method_15(bool_0: true);
			}
		}

		private void method_58(HeaderFooterEventArgs headerFooterEventArgs_0)
		{
			(this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertPageNumber.ToString()] as Control).Enabled = false;
			base.m_txTextControl.TextFieldEntered -= method_90;
			base.m_txTextControl.TextFieldLeft -= method_89;
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			(this.class506_0.TXITEM_IllustrationsGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_DrawingMarkerLines.ToString()] as RibbonToggleButton).Checked = base.m_txTextControl.DrawingMarkerLines;
			(this.class506_0.TXITEM_LinksGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_DocumentTargetMarkers.ToString()] as RibbonToggleButton).Checked = base.m_txTextControl.DocumentTargetMarkers;
			HeaderFooter headerFooter = base.m_txTextControl.TextParts.GetItem() as HeaderFooter;
			RibbonMenuButton ribbonMenuButton = this.class506_0.TXITEM_HeaderFooterGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_InsertPageNumber.ToString()] as RibbonMenuButton;
			if (headerFooter != null)
			{
				ribbonMenuButton.Enabled = base.m_txTextControl.CanEdit;
				this.method_15(headerFooter.PageNumberFields.GetItem() != null);
			}
			else
			{
				ribbonMenuButton.Enabled = false;
				this.method_15(bool_0: false);
			}
			(this.class506_0.TXITEM_TextGroup_Items[RibbonInsertTab.InternalRibbonItem.TXITEM_TextFrameMarkerLines.ToString()] as RibbonToggleButton).Checked = base.m_txTextControl.TextFrameMarkerLines;
		}

		private Class440 method_59(RibbonInsertTab.ChartTemplate chartTemplate_0)
		{
			Class440 @class = new Class440(Class517.smethod_48(Class519.Class533.Size_3, base.m_pntDPI), chartTemplate_0.ToString().EndsWith("3D"));
			@class.Class435_0.Add(new Class437(@class.Nullable_0 ?? false));
			string @string = base.m_rmResourceManager.GetString(string.Concat("HEADER_", chartTemplate_0, "Title"));
			@class.Class441_0.Add(new Class443(@string));
			@class.Class449_0.Add(new Class451("Legend1"));
			Color color = Color.FromArgb(255, 192, 192, 192);
			Color color_ = Color.FromArgb(ControlPaint.Light(color).ToArgb());
			@class.Class435_0[0].Class439_0.Class438_0.Boolean_0 = false;
			@class.Class435_0[0].Class439_0.Class438_0.Color_0 = color;
			@class.Class435_0[0].Class439_0.Class438_1.Color_0 = color_;
			@class.Class435_0[0].Class439_2.Class438_0.Color_0 = color;
			@class.Class435_0[0].Class439_2.Class438_1.Color_0 = color_;
			@class.Class435_0[0].Class439_0.Color_0 = color;
			@class.Class435_0[0].Class439_2.Color_0 = color;
			@class.Class435_0[0].Class439_0.Class455_0.Color_0 = color;
			@class.Class435_0[0].Class439_0.Class455_1.Color_0 = color_;
			@class.Class435_0[0].Class439_2.Class455_0.Color_0 = color;
			@class.Class435_0[0].Class439_2.Class455_1.Color_0 = color_;
			return @class;
		}

		private void method_60(RibbonInsertTab.ChartTemplate chartTemplate_0)
		{
			if (base.m_txTextControl != null)
			{
				Class440 @class = null;
				Class454.SeriesChartType seriesChartType_ = Class454.SeriesChartType.UNKNOWN;
				switch (chartTemplate_0)
				{
				case RibbonInsertTab.ChartTemplate.StackedColumn:
				case RibbonInsertTab.ChartTemplate.StackedColumn3D:
					seriesChartType_ = Class454.SeriesChartType.StackedColumn;
					break;
				case RibbonInsertTab.ChartTemplate.StackedColumn100Percent:
				case RibbonInsertTab.ChartTemplate.StackedColumn100Percent3D:
					seriesChartType_ = Class454.SeriesChartType.StackedColumn100;
					break;
				case RibbonInsertTab.ChartTemplate.ClusteredColumn:
				case RibbonInsertTab.ChartTemplate.ClusteredColumn3D:
				case RibbonInsertTab.ChartTemplate.Column3D:
					seriesChartType_ = Class454.SeriesChartType.Column;
					break;
				case RibbonInsertTab.ChartTemplate.Line:
				case RibbonInsertTab.ChartTemplate.LineWithMarkers:
				case RibbonInsertTab.ChartTemplate.Line3D:
					seriesChartType_ = Class454.SeriesChartType.Line;
					break;
				case RibbonInsertTab.ChartTemplate.Pie:
				case RibbonInsertTab.ChartTemplate.Pie3D:
					seriesChartType_ = Class454.SeriesChartType.Pie;
					break;
				case RibbonInsertTab.ChartTemplate.Doughnut:
					seriesChartType_ = Class454.SeriesChartType.Doughnut;
					break;
				case RibbonInsertTab.ChartTemplate.ClusteredBar:
				case RibbonInsertTab.ChartTemplate.ClusteredBar3D:
					seriesChartType_ = Class454.SeriesChartType.Bar;
					break;
				case RibbonInsertTab.ChartTemplate.StackedBar:
				case RibbonInsertTab.ChartTemplate.StackedBar3D:
					seriesChartType_ = Class454.SeriesChartType.StackedBar;
					break;
				case RibbonInsertTab.ChartTemplate.StackedBar100Percent:
				case RibbonInsertTab.ChartTemplate.StackedBar100Percent3D:
					seriesChartType_ = Class454.SeriesChartType.StackedBar100;
					break;
				case RibbonInsertTab.ChartTemplate.Area:
				case RibbonInsertTab.ChartTemplate.Area3D:
					seriesChartType_ = Class454.SeriesChartType.Area;
					break;
				case RibbonInsertTab.ChartTemplate.StackedArea:
				case RibbonInsertTab.ChartTemplate.StackedArea3D:
					seriesChartType_ = Class454.SeriesChartType.StackedArea;
					break;
				case RibbonInsertTab.ChartTemplate.StackedArea100Percent:
				case RibbonInsertTab.ChartTemplate.StackedArea100Percent3D:
					seriesChartType_ = Class454.SeriesChartType.StackedArea100;
					break;
				case RibbonInsertTab.ChartTemplate.Scatter:
					seriesChartType_ = Class454.SeriesChartType.Point;
					break;
				case RibbonInsertTab.ChartTemplate.ScatterWithSmoothLinesAndMarkers:
				case RibbonInsertTab.ChartTemplate.ScatterWithSmoothLines:
					seriesChartType_ = Class454.SeriesChartType.Spline;
					break;
				case RibbonInsertTab.ChartTemplate.ScatterWithStraightLinesAndMarkers:
				case RibbonInsertTab.ChartTemplate.ScatterWithStraightLines:
					seriesChartType_ = Class454.SeriesChartType.Line;
					break;
				case RibbonInsertTab.ChartTemplate.Bubble:
				case RibbonInsertTab.ChartTemplate.Bubble3D:
					seriesChartType_ = Class454.SeriesChartType.Bubble;
					break;
				case RibbonInsertTab.ChartTemplate.HighLowClose:
					seriesChartType_ = Class454.SeriesChartType.Stock;
					break;
				case RibbonInsertTab.ChartTemplate.OpenHighLowClose:
					seriesChartType_ = Class454.SeriesChartType.Candlestick;
					break;
				case RibbonInsertTab.ChartTemplate.Radar:
				case RibbonInsertTab.ChartTemplate.RadarWithMarkers:
				case RibbonInsertTab.ChartTemplate.FilledRadar:
					seriesChartType_ = Class454.SeriesChartType.Radar;
					break;
				}
				@class = this.method_59(chartTemplate_0);
				this.method_62(seriesChartType_, @class);
				this.method_66(chartTemplate_0, @class);
				ChartFrame chartFrame = new ChartFrame(@class.Object_0 as Control);
				base.m_txTextControl.Charts.Add(chartFrame, HorizontalAlignment.Left, -1, FrameInsertionMode.DisplaceCompleteLines);
				Application.DoEvents();
			}
		}

		private void method_61(Class454.SeriesChartType seriesChartType_0, Class440 class440_0)
		{
			Class454 @class = new Class454(seriesChartType_0);
			@class.String_0 = base.m_rmResourceManager.GetString("HEADER_InsertChart_Series1");
			class440_0.Class452_0.Add(@class);
			@class.Class444_0.method_2(this.string_0, this.double_0);
			this.method_64(seriesChartType_0, @class);
			Class454 class2 = new Class454(seriesChartType_0);
			class2.String_0 = base.m_rmResourceManager.GetString("HEADER_InsertChart_Series2");
			class440_0.Class452_0.Add(class2);
			class2.Class444_0.method_3(this.double_1);
			this.method_64(seriesChartType_0, class2);
			Class454 class3 = new Class454(seriesChartType_0);
			class3.String_0 = base.m_rmResourceManager.GetString("HEADER_InsertChart_Series3");
			class440_0.Class452_0.Add(class3);
			class3.Class444_0.method_3(this.double_2);
			this.method_64(seriesChartType_0, class3);
		}

		private void method_62(Class454.SeriesChartType seriesChartType_0, Class440 class440_0)
		{
			switch (seriesChartType_0)
			{
			default:
				this.method_61(seriesChartType_0, class440_0);
				break;
			case Class454.SeriesChartType.Pie:
			case Class454.SeriesChartType.Doughnut:
				this.method_63(seriesChartType_0, class440_0);
				break;
			case Class454.SeriesChartType.Stock:
			case Class454.SeriesChartType.Candlestick:
				this.method_65(seriesChartType_0, class440_0);
				break;
			}
		}

		private void method_63(Class454.SeriesChartType seriesChartType_0, Class440 class440_0)
		{
			Class454 @class = new Class454(seriesChartType_0);
			@class.String_0 = "Series 1";
			class440_0.Class452_0.Add(@class);
			@class.Class444_0.method_2(this.string_0, this.double_0);
			this.method_64(seriesChartType_0, @class);
		}

		private void method_64(Class454.SeriesChartType seriesChartType_0, Class454 class454_0)
		{
			PropertyInfo property = class454_0.Object_0.GetType().GetProperty("Item", new Type[1] { typeof(string) });
			if (property != null)
			{
				switch (seriesChartType_0)
				{
				case Class454.SeriesChartType.Pie:
				case Class454.SeriesChartType.Doughnut:
					property.SetValue(class454_0.Object_0, "Disabled", new object[1] { "PieLabelStyle" });
					break;
				case Class454.SeriesChartType.Stock:
					property.SetValue(class454_0.Object_0, "Close", new object[1] { "ShowOpenClose" });
					break;
				case Class454.SeriesChartType.Candlestick:
					property.SetValue(class454_0.Object_0, "Green", new object[1] { "PriceUpColor" });
					property.SetValue(class454_0.Object_0, "Red", new object[1] { "PriceDownColor" });
					break;
				case Class454.SeriesChartType.Radar:
					property.SetValue(class454_0.Object_0, "Polygon", new object[1] { "AreaDrawingStyle" });
					break;
				case Class454.SeriesChartType.Bubble:
					property.SetValue(class454_0.Object_0, "30", new object[1] { "BubbleMinSize" });
					break;
				}
			}
		}

		private void method_65(Class454.SeriesChartType seriesChartType_0, Class440 class440_0)
		{
			Class454 @class = new Class454(seriesChartType_0);
			@class.String_0 = "Company XY";
			class440_0.Class452_0.Add(@class);
			for (int i = 0; i < this.class485_0.Length; i++)
			{
				@class.Class444_0.method_1(this.class485_0[i].String_0, this.class485_0[i].Double_0, this.class485_0[i].Double_1, this.class485_0[i].Double_2, this.class485_0[i].Double_3);
			}
			this.method_64(seriesChartType_0, @class);
		}

		private void method_66(RibbonInsertTab.ChartTemplate chartTemplate_0, Class440 class440_0)
		{
			switch (chartTemplate_0)
			{
			case RibbonInsertTab.ChartTemplate.StackedColumn100Percent:
				class440_0.Class435_0[0].Class439_2.Double_0 = 10.0;
				class440_0.Class435_0[0].Class439_2.Class448_0.String_0 = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.ClusteredColumn3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				class440_0.Class435_0[0].Class434_0.Boolean_1 = true;
				break;
			case RibbonInsertTab.ChartTemplate.StackedColumn3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 2.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 14.0;
				break;
			case RibbonInsertTab.ChartTemplate.StackedColumn100Percent3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 20.0;
				class440_0.Class435_0[0].Class439_2.Class448_0.String_0 = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.Column3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 5.0;
				break;
			case RibbonInsertTab.ChartTemplate.Line:
				foreach (Class454 item in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item.Int32_0 = 2;
				}
				break;
			case RibbonInsertTab.ChartTemplate.LineWithMarkers:
				foreach (Class454 item2 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item2.Int32_1 = 7;
					item2.MarkerStyle_0 = MarkerStyle.Circle;
					item2.Int32_0 = 2;
				}
				break;
			case RibbonInsertTab.ChartTemplate.Line3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 5.0;
				break;
			case RibbonInsertTab.ChartTemplate.StackedBar100Percent:
				class440_0.Class435_0[0].Class439_2.Double_0 = 10.0;
				class440_0.Class435_0[0].Class439_2.Class448_0.String_0 = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.ClusteredBar3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				class440_0.Class435_0[0].Class434_0.Boolean_1 = true;
				break;
			case RibbonInsertTab.ChartTemplate.StackedBar3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 2.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 14.0;
				break;
			case RibbonInsertTab.ChartTemplate.StackedBar100Percent3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 20.0;
				class440_0.Class435_0[0].Class439_2.Class448_0.String_0 = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.Area:
			case RibbonInsertTab.ChartTemplate.StackedArea:
				class440_0.Class435_0[0].Class439_0.Double_2 = 1.0;
				class440_0.Class435_0[0].Class439_0.Double_1 = 5.0;
				break;
			case RibbonInsertTab.ChartTemplate.StackedArea100Percent:
				class440_0.Class435_0[0].Class439_0.Double_2 = 1.0;
				class440_0.Class435_0[0].Class439_0.Double_1 = 5.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 10.0;
				class440_0.Class435_0[0].Class439_2.Class448_0.String_0 = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.Area3D:
				class440_0.Class435_0[0].Class439_0.Double_2 = 1.0;
				class440_0.Class435_0[0].Class439_0.Double_1 = 5.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 5.0;
				break;
			case RibbonInsertTab.ChartTemplate.StackedArea3D:
				class440_0.Class435_0[0].Class439_0.Double_2 = 1.0;
				class440_0.Class435_0[0].Class439_0.Double_1 = 5.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 14.0;
				break;
			case RibbonInsertTab.ChartTemplate.StackedArea100Percent3D:
				class440_0.Class435_0[0].Class439_0.Double_2 = 1.0;
				class440_0.Class435_0[0].Class439_0.Double_1 = 5.0;
				class440_0.Class435_0[0].Class439_2.Double_0 = 20.0;
				class440_0.Class435_0[0].Class439_2.Class448_0.String_0 = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.Scatter:
				class440_0.Class435_0[0].Class439_0.Double_0 = 0.5;
				foreach (Class454 item3 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item3.Int32_1 = 7;
					item3.MarkerStyle_0 = MarkerStyle.Circle;
				}
				break;
			case RibbonInsertTab.ChartTemplate.ScatterWithSmoothLinesAndMarkers:
			case RibbonInsertTab.ChartTemplate.ScatterWithStraightLinesAndMarkers:
				class440_0.Class435_0[0].Class439_0.Double_0 = 0.5;
				foreach (Class454 item4 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item4.Int32_1 = 7;
					item4.MarkerStyle_0 = MarkerStyle.Circle;
					item4.Int32_0 = 2;
				}
				break;
			case RibbonInsertTab.ChartTemplate.ScatterWithSmoothLines:
			case RibbonInsertTab.ChartTemplate.ScatterWithStraightLines:
				class440_0.Class435_0[0].Class439_0.Double_0 = 0.5;
				foreach (Class454 item5 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item5.Int32_0 = 2;
				}
				break;
			case RibbonInsertTab.ChartTemplate.Bubble:
				class440_0.Class435_0[0].Class439_0.Double_0 = 0.5;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				foreach (Class454 item6 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item6.MarkerStyle_0 = MarkerStyle.Circle;
				}
				break;
			case RibbonInsertTab.ChartTemplate.Bubble3D:
				class440_0.Class435_0[0].Class439_0.Double_0 = 0.5;
				class440_0.Class435_0[0].Class439_2.Double_0 = 1.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 6.0;
				foreach (Class454 item7 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item7.MarkerStyle_0 = MarkerStyle.Circle;
				}
				break;
			case RibbonInsertTab.ChartTemplate.HighLowClose:
			case RibbonInsertTab.ChartTemplate.OpenHighLowClose:
				class440_0.Class435_0[0].Class439_2.Double_0 = 10.0;
				class440_0.Class435_0[0].Class439_2.Double_1 = 70.0;
				break;
			case RibbonInsertTab.ChartTemplate.Radar:
				foreach (Class454 item8 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item8.Int32_0 = 2;
					PropertyInfo property3 = item8.Object_0.GetType().GetProperty("Item", new Type[1] { typeof(string) });
					property3.SetValue(item8.Object_0, "Line", new object[1] { "RadarDrawingStyle" });
				}
				break;
			case RibbonInsertTab.ChartTemplate.RadarWithMarkers:
				foreach (Class454 item9 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					item9.Int32_1 = 7;
					item9.MarkerStyle_0 = MarkerStyle.Circle;
					PropertyInfo property2 = item9.Object_0.GetType().GetProperty("Item", new Type[1] { typeof(string) });
					property2.SetValue(item9.Object_0, "Marker", new object[1] { "RadarDrawingStyle" });
				}
				break;
			case RibbonInsertTab.ChartTemplate.FilledRadar:
				foreach (Class454 item10 in (IEnumerable<Class454>)class440_0.Class452_0)
				{
					PropertyInfo property = item10.Object_0.GetType().GetProperty("Item", new Type[1] { typeof(string) });
					property.SetValue(item10.Object_0, "Area", new object[1] { "RadarDrawingStyle" });
				}
				break;
			case RibbonInsertTab.ChartTemplate.Pie:
			case RibbonInsertTab.ChartTemplate.Pie3D:
			case RibbonInsertTab.ChartTemplate.Doughnut:
			case RibbonInsertTab.ChartTemplate.ClusteredBar:
			case RibbonInsertTab.ChartTemplate.StackedBar:
				break;
			}
		}

		private void method_67(ShapeType shapeType_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			DrawingFrame activatedItem = base.m_txTextControl.Drawings.GetActivatedItem();
			if (activatedItem != null)
			{
				TXDrawingControl tXDrawingControl = activatedItem.Drawing as TXDrawingControl;
				if (tXDrawingControl != null && tXDrawingControl.IsCanvasVisible)
				{
					tXDrawingControl.Shapes.Add(new Shape(shapeType_0), ShapeCollection.AddStyle.MouseCreation);
				}
				return;
			}
			HeaderFooter headerFooter = base.m_txTextControl.TextParts.GetItem() as HeaderFooter;
			TXDrawingControl tXDrawingControl2 = new TXDrawingControl(7000, 4000);
			Shape shape = new Shape(shapeType_0);
			shape.AutoSize = true;
			shape.Movable = false;
			shape.Sizable = false;
			Shape shape2 = shape;
			tXDrawingControl2.Shapes.Add(shape2, ShapeCollection.AddStyle.Fill);
			activatedItem = new DrawingFrame(tXDrawingControl2);
			base.m_txTextControl.Drawings.Add(activatedItem, (headerFooter == null) ? (FrameInsertionMode.DisplaceText | FrameInsertionMode.MoveWithText) : FrameInsertionMode.BelowTheText);
		}

		private bool method_68()
		{
			if (base.m_txTextControl != null)
			{
				return base.m_txTextControl.HypertextLinks.CanAdd;
			}
			return false;
		}

		private bool method_69()
		{
			if (base.m_txTextControl != null)
			{
				if (base.m_txTextControl.HypertextLinks.GetItem() == null)
				{
					return base.m_txTextControl.DocumentLinks.GetItem() != null;
				}
				return true;
			}
			return false;
		}

		private bool method_70()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.DocumentTargets.CanAdd)
			{
				return base.m_txTextControl.CanEdit;
			}
			return false;
		}

		private bool method_71()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.DocumentTargets.Count != 0)
			{
				return base.m_txTextControl.CanEdit;
			}
			return false;
		}

		private bool method_72()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.DocumentTargets.GetItem() != null)
			{
				return base.m_txTextControl.CanEdit;
			}
			return false;
		}

		private bool method_73()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.CanEdit)
			{
				PageCollection pages = base.m_txTextControl.GetPages();
				if (pages == null)
				{
					return false;
				}
				Page item = pages.GetItem();
				if (item == null)
				{
					return false;
				}
				return item.Header != null;
			}
			return false;
		}

		private bool method_74()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.CanEdit)
			{
				PageCollection pages = base.m_txTextControl.GetPages();
				if (pages == null)
				{
					return false;
				}
				Page item = pages.GetItem();
				if (item == null)
				{
					return false;
				}
				return item.Footer != null;
			}
			return false;
		}

		private bool method_75()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.GetPages() != null)
			{
				return true;
			}
			return false;
		}

		private void method_76(HeaderFooterType headerFooterType_0)
		{
			Page item = base.m_txTextControl.GetPages().GetItem();
			HeaderFooter headerFooter = ((headerFooterType_0 == HeaderFooterType.Header) ? item.Header : item.Footer);
			if (headerFooter == null)
			{
				Section section = base.m_txTextControl.Sections[item.Section];
				if (section != null)
				{
					HeaderFooterCollection headersAndFooters = section.HeadersAndFooters;
					if (headersAndFooters != null)
					{
						headersAndFooters.Add(headerFooterType_0);
						headerFooter = ((headerFooterType_0 == HeaderFooterType.Header) ? item.Header : item.Footer);
					}
				}
			}
			headerFooter?.Activate();
		}

		private void method_77(HeaderFooter headerFooter_0)
		{
			if (headerFooter_0 != null)
			{
				base.m_txTextControl.Sections[headerFooter_0.Section]?.HeadersAndFooters?.Remove(headerFooter_0.Type);
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertPage_Handler(object sender, EventArgs e)
		{
			this.method_19();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertPageBreak_Handler(object sender, EventArgs e)
		{
			this.method_20();
		}

		private void method_78(object sender, EventArgs e)
		{
			this.method_21(sender as RibbonMenuButton);
		}

		private void method_79(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_22(sender as RibbonListView, e);
		}

		private void method_80(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_23(sender as RibbonListView, e);
		}

		private void method_81(object sender, EventArgs e)
		{
			this.method_24(sender as RibbonListView);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTableDialog_Handler(object sender, EventArgs e)
		{
			this.method_25();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertImage_Handler(object sender, EventArgs e)
		{
			this.method_26();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertImagePlaceHolder_Handler(object sender, EventArgs e)
		{
			this.method_27();
		}

		protected override void ChartGallery_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_28(sender as RibbonListView, e);
		}

		private void method_82(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_29(sender as RibbonListView, e);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertDrawingCanvas_Handler(object sender, EventArgs e)
		{
			this.method_30();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DrawingMarkerLines_Handler(object sender, EventArgs e)
		{
			this.method_31((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertBarcode_Handler(object sender, EventArgs e)
		{
			this.method_32("AztecCode");
		}

		private void method_83(object sender, EventArgs e)
		{
			this.method_32(((RibbonButton)sender).Text);
		}

		private void method_84(object sender, EventArgs e)
		{
			this.method_33();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertHyperlinkDialog_Handler(object sender, EventArgs e)
		{
			this.method_34();
		}

		private void method_85(object sender, EventArgs e)
		{
			this.method_35();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertBookmarkDialog_Handler(object sender, EventArgs e)
		{
			this.method_36(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteBookmark_Handler(object sender, EventArgs e)
		{
			this.method_37();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DocumentTargetMarkers_Handler(object sender, EventArgs e)
		{
			this.method_38((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertHeader_Handler(object sender, EventArgs e)
		{
			this.method_39();
		}

		private void method_86(object sender, EventArgs e)
		{
			this.method_40();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EditHeader_Handler(object sender, EventArgs e)
		{
			this.method_41();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_RemoveHeader_Handler(object sender, EventArgs e)
		{
			this.method_42();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertFooter_Handler(object sender, EventArgs e)
		{
			this.method_43();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertFooter_DropDownOpening(object sender, EventArgs e)
		{
			this.method_44();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EditFooter_Handler(object sender, EventArgs e)
		{
			this.method_45();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_RemoveFooter_Handler(object sender, EventArgs e)
		{
			this.method_46();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertStandardPageNumber_Handler(object sender, EventArgs e)
		{
			this.method_47();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_FormatPageNumber_Handler(object sender, EventArgs e)
		{
			this.method_48();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_RemovePageNumber_Handler(object sender, EventArgs e)
		{
			this.method_49();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTextFrame_Handler(object sender, EventArgs e)
		{
			this.method_50();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TextFrameMarkerLines_Handler(object sender, EventArgs e)
		{
			this.method_51((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertFile_Handler(object sender, EventArgs e)
		{
			this.method_52();
		}

		private void method_87(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_53(sender as RibbonListView, e);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_MoreSymbols_Handler(object sender, EventArgs e)
		{
			this.method_54();
		}

		private void method_88(object sender, HeaderFooterEventArgs e)
		{
			this.method_55(e);
		}

		private void method_89(object sender, TextFieldEventArgs e)
		{
			this.method_56(e);
		}

		private void method_90(object sender, TextFieldEventArgs e)
		{
			this.method_57(e);
		}

		private void method_91(object sender, HeaderFooterEventArgs e)
		{
			this.method_58(e);
		}
	}
}
