/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Ribbon Modify Tutorial Sample
** description:	Describes how to add drawings functionality to TX Text Control.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl.Drawing;

namespace Shapes {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void drawingCanvasToolStripMenuItem_Click(object sender, EventArgs e) {
            // calculate the available page width
            textControl1.PageUnit = TXTextControl.MeasuringUnit.Twips;
            int iPageWidth = (int)(textControl1.Sections.GetItem().Format.PageSize.Width -
                textControl1.Sections.GetItem().Format.PageMargins.Left -
                textControl1.Sections.GetItem().Format.PageMargins.Right);

            // create a new TXDrawingControl that fills the complete page width
            TXTextControl.Drawing.TXDrawingControl drawingObject =
                new TXTextControl.Drawing.TXDrawingControl(iPageWidth, 5000);

            // create a new DrawingFrame object that hosts the TXDrawingControl
            TXTextControl.DataVisualization.DrawingFrame drawingFrame =
                new TXTextControl.DataVisualization.DrawingFrame(drawingObject);

            // add the frame object to the Drawings collection
            textControl1.Drawings.Add(drawingFrame, -1);
            drawingFrame.Activate();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // fill drop-down with available shape names
            foreach (string shapeName in Enum.GetNames(typeof(ShapeType))) {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(shapeName);
                menuItem.Click += menuItem_Click;
                shapesToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        void menuItem_Click(object sender, EventArgs e) {
            if (textControl1.Drawings.GetActivatedItem() != null) {
                // create new Shape object from selected menu item text string
                TXTextControl.Drawing.Shape newShape = new TXTextControl.Drawing.Shape(
                    (ShapeType)Enum.Parse(typeof(ShapeType),
                    ((ToolStripMenuItem)sender).Text));

                // add Shape object to drawing canvas
                ((TXTextControl.Drawing.TXDrawingControl)
                 textControl1.Drawings.GetActivatedItem().Drawing)
                    .Shapes.Add(newShape, ShapeCollection.AddStyle.MouseCreation);
            }
            else {
                TXTextControl.Drawing.TXDrawingControl drawingObject =
                    new TXTextControl.Drawing.TXDrawingControl(5000, 5000);

                // create a new DrawingFrame object that hosts the TXDrawingControl
                TXTextControl.DataVisualization.DrawingFrame drawingFrame =
                    new TXTextControl.DataVisualization.DrawingFrame(drawingObject);

                // add the frame object to the Drawings collection
                textControl1.Drawings.Add(drawingFrame,
                    new Point(0, 0),
                    -1,
                    TXTextControl.FrameInsertionMode.DisplaceText);

                TXTextControl.Drawing.Shape newShape = new TXTextControl.Drawing.Shape(
                    (ShapeType)Enum.Parse(typeof(ShapeType),
                    ((ToolStripMenuItem)sender).Text));

                newShape.AutoSize = true;
                newShape.Sizable = false;
                newShape.Movable = false;

                // add shape directly to TextControl
                drawingObject.Shapes.Add(newShape, ShapeCollection.AddStyle.Fill);
                textControl1.Refresh();
            }
        }

        private void shapeToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.DrawingLayoutDialog();
        }

        private void formatToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            // enable the dropdown item, if a drawing canvas is selected
            shapeToolStripMenuItem.Enabled = textControl1.Drawings.GetItem() == null ? false : true;
        }

        private void textControl1_DrawingActivated(object sender, TXTextControl.DataVisualization.DrawingEventArgs e) {
            // attach events to enable alignment buttons
            ((TXDrawingControl)e.DrawingFrame.Drawing).ShapeSelected += Form1_ShapeSelected;
            ((TXDrawingControl)e.DrawingFrame.Drawing).ShapeDeselected += Form1_ShapeSelected;
        }

        void Form1_ShapeSelected(object sender, ShapeEventArgs e) {
            // if more than 1 shape is selected, enable alignment buttons
            TXDrawingControl drawingControl = sender as TXDrawingControl;

            if (drawingControl.Selection.Shapes.Length > 1)
                toolStrip1.Enabled = true;
            else
                toolStrip1.Enabled = false;
        }

        private void textControl1_DrawingDeactivated(object sender, TXTextControl.DataVisualization.DrawingEventArgs e) {
            // detach events
            ((TXDrawingControl)e.DrawingFrame.Drawing).ShapeSelected -= Form1_ShapeSelected;
            ((TXDrawingControl)e.DrawingFrame.Drawing).ShapeDeselected -= Form1_ShapeSelected;
            toolStrip1.Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            // align shapes to top
            Shapes.ShapesHelper.AlignShapes(((TXDrawingControl)textControl1.Drawings.GetActivatedItem().Drawing).Selection.Shapes, Shapes.ShapesHelper.ShapeAlignment.Top);
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            // align shapes to bottom
            Shapes.ShapesHelper.AlignShapes(((TXDrawingControl)textControl1.Drawings.GetActivatedItem().Drawing).Selection.Shapes, Shapes.ShapesHelper.ShapeAlignment.Bottom);
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            // align shapes to left
            Shapes.ShapesHelper.AlignShapes(((TXDrawingControl)textControl1.Drawings.GetActivatedItem().Drawing).Selection.Shapes, Shapes.ShapesHelper.ShapeAlignment.Left);
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            // align shapes to right
            Shapes.ShapesHelper.AlignShapes(((TXDrawingControl)textControl1.Drawings.GetActivatedItem().Drawing).Selection.Shapes, Shapes.ShapesHelper.ShapeAlignment.Right);
        }
    }
}
