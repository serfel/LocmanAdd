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
        {   InitializeComponent();
            NullValue = "<Нет даты>";
            Mask = "00/00/0000";
            InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.Size = new Size(75,this.Height);
            Application.DoEvents();
            this.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(OnTypeValidationCompleted);
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



    }
}
