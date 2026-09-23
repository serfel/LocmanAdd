using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TX_Text_Control_Words.Utils;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields
{
	public class EmptyWidthControl : UserControl
	{
		private MeasuringUnit m_measuringUnit;

		private int m_dValueMultiplicator;

		private IContainer components;

		private NumericUpDown numWidth;

		private Label lblWidthMeasurementUnit;

		private TableLayoutPanel tableLayoutPanel1;

		private Label lblWidth;

		public int Value
		{
			get
			{
				decimal value = this.numWidth.Value;
				return TwipsConverter.DotNet2Twips(Convert.ToDouble(value), this.m_measuringUnit);
			}
			set
			{
				this.numWidth.Value = Convert.ToDecimal(TwipsConverter.Twips2DotNet(value, this.m_measuringUnit, this.numWidth.DecimalPlaces) / (double)this.m_dValueMultiplicator);
			}
		}

		public EmptyWidthControl()
		{
			this.InitializeComponent();
			this.m_measuringUnit = ((!RegionInfo.CurrentRegion.IsMetric) ? MeasuringUnit.CentiInch : MeasuringUnit.Millimeter);
			this.m_dValueMultiplicator = (RegionInfo.CurrentRegion.IsMetric ? 1 : 100);
			bool isMetric = RegionInfo.CurrentRegion.IsMetric;
			this.numWidth.Maximum = decimal.MaxValue;
			this.numWidth.DecimalPlaces = (isMetric ? 1 : 3);
			this.numWidth.Increment = (isMetric ? 1m : 0.1m);
			this.lblWidthMeasurementUnit.Text = (isMetric ? "mm" : "inch");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TX_Text_Control_Words.FormFields.EmptyWidthControl));
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.lblWidthMeasurementUnit = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblWidth = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.numWidth).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.numWidth, "numWidth");
			this.numWidth.Name = "numWidth";
			this.numWidth.Tag = "";
			this.numWidth.Value = new decimal(new int[4] { 18, 0, 0, 65536 });
			resources.ApplyResources(this.lblWidthMeasurementUnit, "lblWidthMeasurementUnit");
			this.lblWidthMeasurementUnit.Name = "lblWidthMeasurementUnit";
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.numWidth, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblWidth, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblWidthMeasurementUnit, 2, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			resources.ApplyResources(this.lblWidth, "lblWidth");
			this.lblWidth.Name = "lblWidth";
			resources.ApplyResources(this, "$this");
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.Name = "EmptyWidthControl";
			((System.ComponentModel.ISupportInitialize)this.numWidth).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
