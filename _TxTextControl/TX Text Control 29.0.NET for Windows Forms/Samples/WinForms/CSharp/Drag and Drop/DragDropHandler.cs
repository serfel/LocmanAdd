/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Drag and Drop Sample
** description:	    Describes how to handle drag and drop with TX Text Control.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;

class FileDragDropHandler {

    private string m_fileName = String.Empty;
    private TXTextControl.StreamType m_streamType = TXTextControl.StreamType.All;
    private bool m_canDrop = false;

    // gets the name of the file handled through this drag&drop handler:
    public string FileName {
        get {
            return m_fileName;
        }
    }

    // gets the TXTextControl Streamtype of the file handled through this drag&drop handler:
    public TXTextControl.StreamType StreamType {
        get {
            return m_streamType;
        }
    }

    // gets a value indicating whether something can be dropped:
    public bool CanDrop {
        get {
            return m_canDrop;
        }
    }

    // resets the internal state of the drag&drop handler:
    public void Reset() {
        m_fileName = null;
        m_streamType = 0;
        m_canDrop = false;
    }

    public void CheckDraggedFiles(string[] fileList) {
        if (fileList != null) {
            //get first parameter from the list and check if it is a supported file type
            m_fileName = fileList[0];
            switch (Path.GetExtension(m_fileName).ToLower()) {
                case ".rtf":
                    m_streamType = TXTextControl.StreamType.RichTextFormat;
                    break;
                case ".doc":
                    m_streamType = TXTextControl.StreamType.MSWord;
                    break;
                case ".docx":
                    m_streamType = TXTextControl.StreamType.WordprocessingML;
                    break;
                case ".htm":
                case ".html":
                    m_streamType = TXTextControl.StreamType.HTMLFormat;
                    break;
                case ".pdf":
                    m_streamType = TXTextControl.StreamType.AdobePDF;
                    break;
                case ".txt":
                    m_streamType = TXTextControl.StreamType.PlainText;
                    break;
                default:
                    m_fileName = String.Empty;
                    break;
            }
            //if there is a file name, the dropped file type is supported
            if (m_fileName.Length > 0)
                m_canDrop = true;
        }
    }

    // calculates a drag&drop effect depending on the allowed effects:
    public DragDropEffects GetDragDropEffect(DragDropEffects allowedEffects, int keyState) {
        if ((allowedEffects & DragDropEffects.Copy) == DragDropEffects.Copy) {
            return DragDropEffects.Copy;
        }
        else if ((allowedEffects & DragDropEffects.Move) == DragDropEffects.Move) {
            return DragDropEffects.Move;
        }
        else {
            return DragDropEffects.None;
        }
    }


}

