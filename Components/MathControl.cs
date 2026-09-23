using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using info.lundin.math;

namespace DataExplorer
{
    public partial class MathControl : TextBox
    {
        string результат = "";
        
        public string Результат
        {   get
            {
                return результат;
            }
            set
            {
                результат = value;
            }
        }

        public MathControl()
        {
            InitializeComponent();
        }

        protected override void OnTextChanged(System.EventArgs args) 
        {
            ExpressionParser oParser = new ExpressionParser();
            oParser.RequireParentheses = true;     // chkParant.Checked;
            oParser.ImplicitMultiplication = true; // chkImplicit.Checked;
            string sFunction = this.Text.Trim();
            double fResult = 0f;
            try
            {
                fResult = oParser.Parse(sFunction);
                Expression expression = oParser.Expressions[sFunction];
                fResult = oParser.EvalExpression(expression);
                //this.Text = "Результат: " + fResult + "\r\n";
            }
            catch /*(Exception ex)*/
            {
                //this.Text = ex.Message;
            }
            результат = fResult.ToString();
            if (результат == "0") результат = "";
            base.OnTextChanged(args);
        }        
    }
}
