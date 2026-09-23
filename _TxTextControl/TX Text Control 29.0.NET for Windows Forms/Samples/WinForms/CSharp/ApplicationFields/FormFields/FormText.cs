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

namespace FormFields {

    // this class implements the functionality of the MS Word FormTextBox field
    public class FormText {

        private string[] _strParameters;

        private string _name = "";
        private bool _enabled;
        private bool _calcOnExit;
        private string _default = "";
        private FormTextBoxFormat _format = FormTextBoxFormat.None;
        private FormTextBoxType _type = FormTextBoxType.RegularText;
        private int _maxLength = 0;

        public int MaxLength {
            get {
                return _maxLength;
            }
            set {
                _maxLength = value;
                if (_field.Text.Length > _maxLength & _maxLength != 0)
                    _field.Text = _field.Text.Substring(0, _maxLength);
                SetParameters();
            }
        }

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
                SetParameters();
            }
        }

        public bool Enabled {
            get {
                return _enabled;
            }
            set {
                _enabled = value;
                SetParameters();
            }
        }

        public bool CalcOnExit {
            get {
                return _calcOnExit;
            }
            set {
                _calcOnExit = value;
                SetParameters();
            }
        }

        public string Default {
            get {
                return _default;
            }
            set {
                _default = value;
                _field.Text = _default;
                SetParameters();
            }
        }

        public FormTextBoxFormat Format {
            get {
                return _format;
            }
            set {
                _format = value;
                SetParameters();
            }
        }

        public FormTextBoxType Type {
            get {
                return _type;
            }
            set {
                _type = value;
                SetParameters();
            }
        }

        public enum FormTextBoxFormat {
            UPPERCASE,
            lowercase,
            Firstcapital,
            TitleCase,
            None
        }

        public enum FormTextBoxType {
            RegularText,
            Number,
            Date,
            CurrentDate,
            CurrentTime,
            Calculation
        }

        // _field is a reference to the ApplicationField that will be synchronized
        private TXTextControl.ApplicationField _field;

        public FormText(TXTextControl.ApplicationField Field) {
            _field = Field;
            _strParameters = _field.Parameters;
            _default = _field.Text;
            GetParameters();
        }

        // read the parameters to set the properties
        private void GetParameters() {
            foreach (string parameter in _strParameters) {
                if (parameter.Contains("w:name w:val")) {
                    _name = parameter.Split('"').GetValue(1).ToString();
                    continue;
                }
                if (parameter.Contains("w:maxLength w:val")) {
                    _maxLength = Convert.ToInt32(parameter.Split('"').GetValue(1));
                    continue;
                }
                if (parameter.Contains("w:enabled w:val")) {
                    _enabled = Convert.ToBoolean(parameter.Split('"').GetValue(1));
                    continue;
                }
                if (parameter.Contains("w:calcOnExit w:val")) {
                    _calcOnExit = Convert.ToBoolean(parameter.Split('"').GetValue(1));
                    continue;
                }
                if (parameter.Contains("w:default w:val")) {
                    _default = parameter.Split('"').GetValue(1).ToString();
                    continue;
                }
                if (parameter.Contains("w:format w:val")) {
                    switch (parameter.Split('"').GetValue(1).ToString()) {
                        case "Uppercase":
                            _format = FormTextBoxFormat.UPPERCASE;
                            break;
                        case "lowercase":
                            _format = FormTextBoxFormat.lowercase;
                            break;
                        case "TitleCase":
                            _format = FormTextBoxFormat.TitleCase;
                            break;
                        case "FirstCapital":
                            _format = FormTextBoxFormat.Firstcapital;
                            break;
                    }
                    continue;
                }
                if (parameter.Contains("w:type w:val")) {
                    switch (parameter.Split('"').GetValue(1).ToString()) {
                        case "regular":
                            _type = FormTextBoxType.RegularText;
                            break;
                        case "number":
                            _type = FormTextBoxType.Number;
                            break;
                        case "date":
                            _type = FormTextBoxType.Date;
                            break;
                        case "currentDate":
                            _type = FormTextBoxType.CurrentDate;
                            break;
                        case "currentTime":
                            _type = FormTextBoxType.CurrentTime;
                            break;
                        case "calculated":
                            _type = FormTextBoxType.Calculation;
                            break;
                    }
                    continue;
                }
            }
        }

        // write the parameters
        private void SetParameters() {
            ArrayList ParameterList = new ArrayList();

            ParameterList.Add("w:name w:val=\"" + _name.ToString() + "\"");

            if (_calcOnExit)
                ParameterList.Add("w:calcOnExit w:val=\"" + _calcOnExit.ToString() + "\"");
            if (_default != "")
                ParameterList.Add("w:default w:val=\"" + _default.ToString() + "\"");
            if (_enabled)
                ParameterList.Add("w:enabled w:val=\"" + _enabled.ToString() + "\"");
            if (_format != FormTextBoxFormat.None) {
                string formatString = "";

                switch (_format) {
                    case FormTextBoxFormat.UPPERCASE:
                        formatString = "uppercase";
                        break;
                    case FormTextBoxFormat.lowercase:
                        formatString = "lowercase";
                        break;
                    case FormTextBoxFormat.TitleCase:
                        formatString = "TitleCase";
                        break;
                    case FormTextBoxFormat.Firstcapital:
                        formatString = "FirstCapital";
                        break;
                }

                ParameterList.Add("w:format w:val=\"" + formatString + "\"");
            }
            if (_maxLength != 0)
                ParameterList.Add("w:maxLength w:val=\"" + _maxLength.ToString() + "\"");

            string typeString = "";

            switch (_type) {
                case FormTextBoxType.RegularText:
                    typeString = "regular";
                    break;
                case FormTextBoxType.Number:
                    typeString = "number";
                    break;
                case FormTextBoxType.Date:
                    typeString = "date";
                    break;
                case FormTextBoxType.CurrentDate:
                    typeString = "currentDate";
                    break;
                case FormTextBoxType.CurrentTime:
                    typeString = "currentTime";
                    break;
                case FormTextBoxType.Calculation:
                    typeString = "calculated";
                    break;
            }

            ParameterList.Add("w:type w:val=\"" + typeString + "\"");

            _strParameters = ParameterList.ToArray(System.Type.GetType("System.String")) as string[];
            _field.Parameters = _strParameters;
        }


    }
}
