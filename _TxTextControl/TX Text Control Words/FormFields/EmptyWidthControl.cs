/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using TXTextControl;
using System.Globalization;
using TX_Text_Control_Words.Utils;

namespace TX_Text_Control_Words.FormFields {

	/*----------------------------------------------------------------------------------------------------------
	** class EmptyWidthControl
	**		A control for editing an empty width.
	**--------------------------------------------------------------------------------------------------------*/
	public partial class EmptyWidthControl : UserControl {

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		MeasuringUnit m_measuringUnit;
		int m_dValueMultiplicator;

		/*-------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** Value
		**		Empty width's value.
		**-----------------------------------------------------------------------------------------------------*/
		public int Value {
			get {
				var decDotNetValue = numWidth.Value;
				return TwipsConverter.DotNet2Twips(Convert.ToDouble(decDotNetValue), m_measuringUnit);
			}
			set {
				var iTwipsValue = value;
				numWidth.Value = Convert.ToDecimal(TwipsConverter.Twips2DotNet(iTwipsValue, m_measuringUnit, numWidth.DecimalPlaces) / m_dValueMultiplicator);
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------*/
		public EmptyWidthControl() {
			InitializeComponent();

			// Helpers for converting the value
			m_measuringUnit = RegionInfo.CurrentRegion.IsMetric ? MeasuringUnit.Millimeter : MeasuringUnit.CentiInch;
			m_dValueMultiplicator = RegionInfo.CurrentRegion.IsMetric ? 1 : 100;

			// Show the value of empty width in millimeter when region supports metric values
			// otherwise show value in inch.
			bool isMetric = RegionInfo.CurrentRegion.IsMetric;
			numWidth.Maximum = decimal.MaxValue;
			numWidth.DecimalPlaces = isMetric ? 1 : 3;
			numWidth.Increment = isMetric ? 1 : 0.1m;

			// Show measuring unit
			lblWidthMeasurementUnit.Text = isMetric ? "mm" : "inch";
		}
	}
}
