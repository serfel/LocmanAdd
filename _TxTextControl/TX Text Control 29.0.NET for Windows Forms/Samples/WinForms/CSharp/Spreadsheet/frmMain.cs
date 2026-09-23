using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TXTextControl;

namespace Spreadsheet
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // load a sample document
            textControl1.Load("cashflow.tx", StreamType.InternalUnicodeFormat);

            // add the supported functions and number formats to the UI dropdowns
            tscbFunctions.Items.AddRange(textControl1.Tables.SupportedFormulaFunctions);
            tscbFormats.Items.AddRange(textControl1.Tables.SupportedNumberFormats);
            tscbFunctions.Text = "SUM";

            // set default reference style and enable calculation
            tsBtnCalculation.Checked = textControl1.IsFormulaCalculationEnabled;
            textControl1.FormulaReferenceStyle = FormulaReferenceStyle.A1;

            // update UI
            if(textControl1.FormulaReferenceStyle == FormulaReferenceStyle.A1)
                tsBtnA1.Checked = true;
            else
                tsBtnR1C1.Checked = true;
        }

        #region UI Events
        private void tsBtnAddFunction_Click(object sender, EventArgs e)
        {
            AddFunction(tscbFunctions.Text);           
        }

        private void tsBtnAccept_Click(object sender, EventArgs e)
        {
            ApplyFormula();
        }
        
        private void tsBtnRemove_Click(object sender, EventArgs e)
        {
            textControl1.Tables.GetItem().Cells.GetItem().Formula = "";
            UpdateTableCellSettings();
        }

        private void tsBtnCalculation_Click(object sender, EventArgs e)
        {
            textControl1.IsFormulaCalculationEnabled = tsBtnCalculation.Checked;
        }

        private void tsBtnR1C1_Click(object sender, EventArgs e)
        {
            textControl1.FormulaReferenceStyle = FormulaReferenceStyle.R1C1;
            UpdateTableCellSettings();
        }

        private void tsBtnA1_Click(object sender, EventArgs e)
        {
            textControl1.FormulaReferenceStyle = FormulaReferenceStyle.A1;
            UpdateTableCellSettings();
        }

        private void tsBtnTextFormat_Click(object sender, EventArgs e)
        {
            SetCellFormat(TextType.Standard);
        }

        private void tsBtnNumberFormat_Click(object sender, EventArgs e)
        {
            SetCellFormat(TextType.Number);
        }

        private void tsBtnApplyNumberFormat_Click(object sender, EventArgs e)
        {
            textControl1.Tables.GetItem().Cells.GetItem().CellFormat.NumberFormat =
                tscbFormats.Text;
        }

        private void tstbFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                ApplyFormula();
        }

        private void tstbFormula_TextChanged(object sender, EventArgs e)
        {
            ttInfo.Hide(this);
        }

        #endregion

        #region Text Control Events

        private void textControl1_InputPositionChanged(object sender, EventArgs e)
        {
            // enable formula UI when input position is inside table and
            // a single cell is selected or active
            if (textControl1.Tables.GetItem() == null)
            {
                tsFormula.Enabled = false;
                return;
            }
            else if (textControl1.Tables.GetItem().Cells.GetItem() != null)
            {
                tsFormula.Enabled = true;
                UpdateTableCellSettings();
            }
            else
                tsFormula.Enabled = false;
        }

        #endregion

        // This method adds a function to the text box and shows a tooltip
        private void AddFunction(string Function)
        {
            tstbFormula.Text = Function + "()";
            tstbFormula.Select(Function.Length + 1, 0);
            tstbFormula.Focus();

            ttInfo.Show("Specify the cell range for the formula calculation." 
                + Environment.NewLine + Environment.NewLine
                + "For example:" 
                + Environment.NewLine 
                + "SUM(A1:A5)" 
                + Environment.NewLine 
                + "This would calculate the sum for the cell range A1 to A5.", this, tsFormula.Items["tstbFormula"].Bounds.X, tsFormula.Bounds.Y - 100);
        }

        // This method applies a formula to the cell
        private void ApplyFormula()
        {
            try
            {
                textControl1.Tables.GetItem().Cells.GetItem().Formula = tstbFormula.Text;
            }
            catch (Exception exc) // Let TX Text Control do the validation
            {
                MessageBox.Show(exc.Message, "Formula Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method updates the UI based on the current cell settings
        private void UpdateTableCellSettings()
        {
            if (textControl1.Tables.GetItem() == null)
                return;

            // get the current table cell
            TableCell tableCell = textControl1.Tables.GetItem().Cells.GetItem();

            // read the current formula
            tstbFormula.Text = tableCell.Formula;

            // set the check state of the reference style
            switch (textControl1.FormulaReferenceStyle)
            {
                case FormulaReferenceStyle.A1:
                    tsBtnA1.Checked = true;
                    tsBtnR1C1.Checked = false;
                    break;
                case FormulaReferenceStyle.R1C1:
                    tsBtnA1.Checked = false;
                    tsBtnR1C1.Checked = true;
                    break;
            }

            // set the check state of the cell format
            switch (tableCell.CellFormat.TextType)
            {
                case TextType.Standard:
                    tsBtnTextFormat.Checked = true;
                    tsBtnNumberFormat.Checked = false;
                    tscbFormats.Enabled = false;
                    tsBtnApplyNumberFormat.Enabled = false;
                    tscbFormats.Text = "";
                    break;
                case TextType.Number:
                    tsBtnTextFormat.Checked = false;
                    tsBtnNumberFormat.Checked = true;
                    tscbFormats.Enabled = true;
                    tsBtnApplyNumberFormat.Enabled = true;
                    tscbFormats.Text = tableCell.CellFormat.NumberFormat;
                    break;
            }
        }

        // This method applies a cell format 
        private void SetCellFormat(TextType textType)
        {
            TableCell curCell = textControl1.Tables.GetItem().Cells.GetItem();

            curCell.CellFormat.TextType = textType;
            UpdateTableCellSettings();
        }
    }
}

