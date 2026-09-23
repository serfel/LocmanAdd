/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Drag and Drop Sample
** description:	    Describes how to handle drag and drop with TX Text Control.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace Drag_and_Drop {

    public partial class Form1 : Form {

        FileDragDropHandler fileDragDrop = new FileDragDropHandler();

        public Form1() {
            InitializeComponent();
            textControl1.RulerBar = rulerBar2;
            textControl1.ButtonBar = buttonBar1;
            textControl1.StatusBar = statusBar1;
            textControl1.VerticalRulerBar = rulerBar1;
        }

        private void textControl1_DragDrop(object sender, DragEventArgs e) {
            loadFile(fileDragDrop.FileName, fileDragDrop.StreamType);
        }

        private void textControl1_DragEnter(object sender, DragEventArgs e) {
            fileDragDrop.Reset();
            fileDragDrop.CheckDraggedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        private void textControl1_DragOver(object sender, DragEventArgs e) {
            if (fileDragDrop.CanDrop == true)
                e.Effect = fileDragDrop.GetDragDropEffect(e.AllowedEffect, e.KeyState);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e) {
            loadFile(fileDragDrop.FileName, fileDragDrop.StreamType);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e) {
            fileDragDrop.Reset();
            fileDragDrop.CheckDraggedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        private void Form1_DragOver(object sender, DragEventArgs e) {
            if (fileDragDrop.CanDrop == true)
                e.Effect = fileDragDrop.GetDragDropEffect(e.AllowedEffect, e.KeyState);
        }

        private void loadFile(string file, TXTextControl.StreamType streamType) {
            try {
                textControl1.Load(file, streamType);
            } catch (Exception x) {
                MessageBox.Show("Error when loading dropped file: " + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}