/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mail Merge Sample
** description:	Shows how to use the DocumentServer.MailMerge class in Windows Forms projects 
**              to merge TXTextControl.ApplicationFields in template documents with data from 
**              various data sources. The MailMerge class encapsulates powerful mail merge 
**              capabilities in a ready-to-use component. The DocumentServer.MailMerge class 
**              is part of the TXTextControl.DocumentServer namespace.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Globalization;

// This class implements the MergeFields. It is inheritet from
// TXTextControl's ApplicationField class
public class MergeField : TXTextControl.ApplicationField {

    private string m_text;
    private string m_mergeFieldName;
    private string m_textBefore = string.Empty;
    private string m_textAfter = string.Empty;
    private bool m_mapped = false;
    private bool m_verticalFormatting = false;
    private bool m_preserveFormatting = false;
    private TextFormatOptions m_textFormat = TextFormatOptions.None;

    public TXTextControl.ApplicationField m_field;

    // Enumeration for the text format options
    public enum TextFormatOptions {
        Uppercase,
        Lowercase,
        FirstCapital,
        TitleCase,
        None
    }

    // This constructor is used when a new MergeField is inserted
    public MergeField(string MergeFieldName, string Text, CollectionSync SyncObject)
        : base(TXTextControl.ApplicationFieldFormat.MSWord, "MERGEFIELD", Text, new string[] { MergeFieldName }) {
        TXTextControl.ApplicationField newField = new TXTextControl.ApplicationField(TXTextControl.ApplicationFieldFormat.MSWord, "MERGEFIELD", Text, new string[] { MergeFieldName });
        SyncObject.m_tx.ApplicationFields.Add(newField);

        m_field = newField;
        m_field.DoubledInputPosition = true;
        m_field.HighlightMode = TXTextControl.HighlightMode.Activated;

        m_text = newField.Text;

        SyncObject.SyncCollections();
        GetParameters();
    }

    // This constructor is used by the synchronization object
    public MergeField(TXTextControl.ApplicationField field)
        : base(field.Format, field.TypeName, field.Text, field.Parameters) {
        m_field = field;
        m_text = field.Text;

        GetParameters();
    }

    // This method fills the Parameter property of the ApplicationField
    private void SetParameters() {
        ArrayList ParameterList = new ArrayList();

        ParameterList.Add(m_mergeFieldName);

        if (m_mapped)
            ParameterList.Add("\\m");
        if (m_verticalFormatting)
            ParameterList.Add("\\v");
        if (m_textAfter != string.Empty)
            ParameterList.Add("\\f " + m_textAfter);
        if (m_textBefore != string.Empty)
            ParameterList.Add("\\b " + m_textBefore);
        if (m_textFormat != TextFormatOptions.None) {
            switch (m_textFormat) {
                case TextFormatOptions.Uppercase:
                    ParameterList.Add("\\* Upper");
                    break;
                case TextFormatOptions.Lowercase:
                    ParameterList.Add("\\* Lower");
                    break;
                case TextFormatOptions.FirstCapital:
                    ParameterList.Add("\\* FirstCap");
                    break;
                case TextFormatOptions.TitleCase:
                    ParameterList.Add("\\* Caps");
                    break;
            }
        }
        if (m_preserveFormatting)
            ParameterList.Add("\\* MERGEFORMAT");

        this.Parameters = ParameterList.ToArray(Type.GetType("System.String")) as string[];
        m_field.Parameters = this.Parameters;
    }

    // This method gets the parameters from the Parameters property to fill
    // the implemented properties of the MergeField
    private void GetParameters() {
        m_mergeFieldName = this.Parameters[0];

        foreach (string parameter in this.Parameters) {
            if (parameter.Contains("\\m")) {
                m_mapped = true;
            }
            if (parameter.Contains("\\v")) {
                m_verticalFormatting = true;
            }
            if (parameter.Contains("\\b")) {
                m_textBefore = parameter.Substring(3, parameter.Length - 3);
            }
            else if (parameter.Contains("\\f")) {
                m_textAfter = parameter.Substring(3, parameter.Length - 3);
            }
            else if (parameter.Contains("\\*")) {
                switch (parameter.Substring(3, parameter.Length - 3)) {
                    case "Upper":
                        m_textFormat = TextFormatOptions.Uppercase;
                        break;
                    case "Lower":
                        m_textFormat = TextFormatOptions.Lowercase;
                        break;
                    case "FirstCap":
                        m_textFormat = TextFormatOptions.FirstCapital;
                        break;
                    case "Caps":
                        m_textFormat = TextFormatOptions.TitleCase;
                        break;
                    case "MERGEFORMAT":
                        m_preserveFormatting = true;
                        break;
                }
            }
        }
    }

    // This property sets the text of the MergeField. It implies the text format
    // and the text before and text after settings
    public new string Text {
        get {
            m_text = m_field.Text;

            if (m_text.StartsWith(this.TextBefore, true, CultureInfo.CurrentCulture))
                m_text = m_text.Substring(m_textBefore.Length, m_text.Length - m_textBefore.Length);
            if (m_text.EndsWith(this.TextAfter, true, CultureInfo.CurrentCulture))
                m_text = m_text.Substring(0, m_text.Length - m_textAfter.Length);

            return m_text;
        }

        set {
            string newText = value;

            // Text before
            if (this.m_textBefore != string.Empty) {
                if (newText.ToLower().StartsWith(this.m_textBefore.ToLower()) == false) {
                    newText = this.m_textBefore + newText;
                }
            }

            // Text after
            if (this.m_textAfter != string.Empty) {
                if (newText.ToLower().EndsWith(this.m_textAfter.ToLower()) == false) {
                    newText += this.m_textAfter;
                }
            }

            // Text format
            switch (this.TextFormat) {
                case MergeField.TextFormatOptions.Lowercase:
                    m_text = newText.ToLower();
                    break;
                case TextFormatOptions.Uppercase:
                    m_text = newText.ToUpper();
                    break;
                case TextFormatOptions.TitleCase:
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    m_text = textInfo.ToTitleCase(newText);
                    break;
                case TextFormatOptions.FirstCapital:
                    m_text = newText.Substring(0, 1).ToUpper() + newText.Substring(1, newText.Length - 1);
                    break;
                default:
                    m_text = newText;
                    break;
            }

            m_field.Text = m_text;
        }
    }

    public string MergeFieldName {
        get {
            return m_mergeFieldName.Replace("\"", "");
        }

        set {
            m_mergeFieldName = value;

            if (m_mergeFieldName.Contains(" "))
                m_mergeFieldName = "\"" + m_mergeFieldName + "\"";

            SetParameters();
        }
    }

    public TextFormatOptions TextFormat {
        get {
            return m_textFormat;
        }

        set {
            m_textFormat = value;
            this.Text = this.Text;
            SetParameters();
        }
    }

    public string TextBefore {
        get {
            return m_textBefore;
        }

        set {
            m_textBefore = value;
            this.Text = this.Text;
            SetParameters();
        }
    }

    public string TextAfter {
        get {
            return m_textAfter;
        }

        set {
            m_textAfter = value;
            this.Text = this.Text;
            SetParameters();
        }
    }

    public bool Mapped {
        get {
            return m_mapped;
        }
        set {
            m_mapped = value;
            SetParameters();
        }
    }

    public bool VerticalFormatting {
        get {
            return m_verticalFormatting;
        }
        set {
            m_verticalFormatting = value;
            SetParameters();
        }
    }

    public bool PreserveFormatting {
        get {
            return m_preserveFormatting;
        }
        set {
            m_preserveFormatting = value;
            SetParameters();
        }
    }
}

