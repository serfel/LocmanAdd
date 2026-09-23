/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl.DataVisualization;
using System.Reflection;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** partial class MainWindow
	** Capsulates events and creation of toolbar's menu for shapes.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** MnuInsert_Shapes_DropDownOpening method
		** Fills toolbar's Insert->Shapes menu with items for inserting shapes on the first opening.
		**-----------------------------------------------------------------------------------------------------------*/
		private void MnuInsert_Shapes_DropDownOpening(object sender, EventArgs e) {

			if (mnuInsert_Shapes_Lines.DropDownItems.Count > 0) return; // Menu items were already added

			// Add shape menu items:
			AddShapeMenuItems();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddShapeMenuItems method
		** Fills toolbar's menus for the different shape categories with items for inserting the different kinds of
		** shapes.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddShapeMenuItems() {
			// "Lines": 

			ToolStripItemCollection items = mnuInsert_Shapes_Lines.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Line);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BentConnector3);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.CurvedConnector3);

			// "Rectangles":

			items = mnuInsert_Shapes_Rectangles.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Rectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.RoundRectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Snip1Rectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Snip2SameRectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Snip2DiagonalRectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.SnipRoundRectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Round1Rectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Round2SameRectangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Round2DiagonalRectangle);

			// "Basic Shapes":

			items = mnuInsert_Shapes_Basic.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Ellipse);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Triangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.RightTriangle);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Parallelogram);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.NonIsoscelesTrapezoid);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Diamond);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Pentagon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Hexagon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Heptagon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Octagon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Decagon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Dodecagon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Pie);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Chord);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Teardrop);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Frame);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.HalfFrame);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Corner);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.DiagonalStripe);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Plus);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Plaque);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Can);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Cube);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Bevel);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Donut);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.NoSmoking);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BlockArc);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FoldedCorner);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.SmileyFace);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Heart);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LightningBolt);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Sun);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Moon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Cloud);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Arc);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BracketPair);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BracePair);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftBracket);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.RightBracket);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftBrace);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.RightBrace);

			// "Block Arrows":

			items = mnuInsert_Shapes_BlockArrows.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.RightArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.UpArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.DownArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftRightArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.UpDownArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.QuadArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftRightUpArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BentArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.UTurnArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftUpArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BentUpArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.CurvedRightArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.CurvedLeftArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.CurvedUpArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.CurvedDownArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.StripedRightArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.NotchedRightArrow);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.HomePlate);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Chevron);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.RightArrowCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.DownArrowCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftArrowCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.UpArrowCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.LeftRightArrowCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.QuadArrowCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.CircularArrow);

			// "Equation Shapes":

			items = mnuInsert_Shapes_Equation.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.MathPlus);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.MathMinus);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.MathMultiply);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.MathDivide);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.MathEqual);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.MathNotEqual);

			// "Flowchart":

			items = mnuInsert_Shapes_FlowChart.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartProcess);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartAlternateProcess);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartDecision);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartInputOutput);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartPredefinedProcess);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartInternalStorage);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartDocument);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartMultidocument);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartTerminator);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartPreparation);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartManualInput);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartManualOperation);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartConnector);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartOffpageConnector);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartPunchedCard);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartPunchedTape);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartSummingJunction);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartOr);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartCollate);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartSort);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartExtract);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartMerge);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartOnlineStorage);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartDelay);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartMagneticTape);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartMagneticDisk);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartMagneticDrum);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.FlowChartDisplay);

			// "Stars and Banners":

			items = mnuInsert_Shapes_StarsBanners.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.IrregularSeal1);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.IrregularSeal2);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star4);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star5);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star6);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star7);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star8);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star10);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star12);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star16);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star24);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Star32);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Ribbon2);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Ribbon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.EllipseRibbon2);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.EllipseRibbon);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.VerticalScroll);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.HorizontalScroll);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Wave);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.DoubleWave);

			// "Callouts":

			items = mnuInsert_Shapes_Callouts.DropDownItems;
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.WedgeRectangleCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.WedgeRoundRectangleCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.WedgeEllipseCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.CloudCallout);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BorderCallout1);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BorderCallout2);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.BorderCallout3);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.AccentCallout1);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.AccentCallout2);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.AccentCallout3);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Callout1);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Callout2);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.Callout3);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.AccentBorderCallout1);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.AccentBorderCallout2);
			AddShapeItem(items, TXTextControl.Drawing.ShapeType.AccentBorderCallout3);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddShapeItem method
		** Creates a new MenuItem by the ShapeType and adds them to the passed items. Stores the ShapeType in the Tag
		** property for getting the ShapeType in clickhandler.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddShapeItem(ToolStripItemCollection items, TXTextControl.Drawing.ShapeType shapeType) {

			string text = Resources.ResourceManager.GetString("TOOLTIP_SHAPE_" + shapeType.ToString());
			var image = TXTextControl.Windows.Forms.ResourceProvider.GetSmallIcon("TXITEM_SHAPE_" + shapeType.ToString(), DeviceDpi);

			var item = new ToolStripMenuItem(text, image);
			item.Tag = shapeType;   // Somehow store the shape type in the menu item object
			item.Click += ShapeMenuItem_Click;
			items.Add(item);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ShapeMenuItem_Click method
		** Handles a click on a menuitem. Inserts a shape in the TextControl with help of the ShapeType embedded 
		** in menuitem's Tag property.
		**-----------------------------------------------------------------------------------------------------------*/
		void ShapeMenuItem_Click(object sender, EventArgs e) {
			TXTextControl.Drawing.ShapeType shapeType;
			var item = sender as ToolStripMenuItem;
			if (item == null) return;

			try { shapeType = (TXTextControl.Drawing.ShapeType)item.Tag; }
			catch (InvalidCastException) { return; }

			InsertShape(shapeType);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertDrawingCanvas method
		** Try to add a drawing frame in TextControl at current position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertDrawingCanvas() {
			try {
				var drawing = new TXTextControl.Drawing.TXDrawingControl(7000, 4000);
				var frame = new DrawingFrame(drawing);
				textControl.Drawings.Add(
					frame, TXTextControl.HorizontalAlignment.Left, -1,
					TXTextControl.FrameInsertionMode.DisplaceText | TXTextControl.FrameInsertionMode.MoveWithText);
				frame.Activate();
			}
			catch (TXTextControl.LicenseLevelException ex) {
				string strProductName = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;
				MessageBox.Show(ex.Message, strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertShape method
		** Add the shape to the selected DrawingFrame. Otherwise create a new one and add this to TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertShape(TXTextControl.Drawing.ShapeType shapeType) {
			try {
				DrawingFrame frame = textControl.Drawings.GetActivatedItem();
				if (frame != null) {
					var drawing = frame.Drawing as TXTextControl.Drawing.TXDrawingControl;
					if (drawing != null && drawing.IsCanvasVisible) {
						drawing.Shapes.Add(new TXTextControl.Drawing.Shape(shapeType), TXTextControl.Drawing.ShapeCollection.AddStyle.MouseCreation);
					}
				}
				else {
					var drawing = new TXTextControl.Drawing.TXDrawingControl(7000, 4000);
					var shape = new TXTextControl.Drawing.Shape(shapeType) { AutoSize = true, Movable = false, Sizable = false };
					drawing.Shapes.Add(shape, TXTextControl.Drawing.ShapeCollection.AddStyle.Fill);

					frame = new DrawingFrame(drawing);
					textControl.Drawings.Add(frame, TXTextControl.FrameInsertionMode.AboveTheText | TXTextControl.FrameInsertionMode.MoveWithText);
				}
				frame.Activate();

			}
			catch (TXTextControl.LicenseLevelException ex) {
				string strProductName = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;
				MessageBox.Show(ex.Message, strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}
	}
}
