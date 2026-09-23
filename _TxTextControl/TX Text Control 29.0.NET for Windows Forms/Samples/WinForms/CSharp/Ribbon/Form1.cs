/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Ribbon Tutorial Sample
** description:	Shows how to create a word processor application with a ribbon interface from 
**                  scratch with just a few lines of code. 						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;

namespace Tutorial {

    public partial class Form1 : TXTextControl.Windows.Forms.Ribbon.RibbonForm {

        public Form1() {
            InitializeComponent();

            textControl1.InputPositionChanged += TextControl1_InputPositionChanged;
            textControl1.FrameSelected += TextControl1_FrameSelected;
            textControl1.FrameDeselected += TextControl1_FrameDeselected;
            textControl1.DrawingActivated += TextControl1_DrawingActivated;
            textControl1.DrawingDeselected += TextControl1_DrawingDeselected;

            m_rbtnLoad.Click += M_rbtnLoad_Click;
            m_rbtnSave.Click += M_rbtnSave_Click;
        }

        private void M_rbtnSave_Click(object sender, EventArgs e) {
            textControl1.Save();
        }

        private void M_rbtnLoad_Click(object sender, EventArgs e) {
            textControl1.Load();
        }

        private void TextControl1_DrawingDeselected(object sender, TXTextControl.DataVisualization.DrawingEventArgs e) {
            if ((textControl1.Frames.GetItem() == null) &&
                (textControl1.Drawings.GetActivatedItem() == null)) {
                m_grpFrameTools.Visible = false;
            }
        }

        private void TextControl1_DrawingActivated(object sender,
            TXTextControl.DataVisualization.DrawingEventArgs e) {
            m_grpFrameTools.Visible = true;
        }

        private void TextControl1_FrameDeselected(object sender,
            TXTextControl.FrameEventArgs e) {
            if ((textControl1.Frames.GetItem() == null) &&
                (textControl1.Drawings.GetActivatedItem() == null)) {
                m_grpFrameTools.Visible = false;
            }
        }

        private void TextControl1_FrameSelected(object sender,
            TXTextControl.FrameEventArgs e) {
            m_grpFrameTools.Visible = true;
        }

        private void TextControl1_InputPositionChanged(object sender, EventArgs e) {
            m_grpTableTools.Visible = textControl1.Tables.GetItem() != null;
        }
    }
}
