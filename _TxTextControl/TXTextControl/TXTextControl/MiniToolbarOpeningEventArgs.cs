using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns21;
using TXTextControl.DataVisualization;

namespace TXTextControl
{
	/// <summary>The MiniToolbarOpeningEventArgs class provides data for the TextControl.MiniToolbarOpening event of a Windows Forms TextControl.</summary>
	public class MiniToolbarOpeningEventArgs : CancelEventArgs
	{
		private TextControlCore textControlCore_0;

		private TextControl textControl_0;

		private ContextMenuLocation contextMenuLocation_0;

		private Struct77 struct77_0 = default(Struct77);

		private MiniToolbar miniToolbar_0;

		private bool bool_0;

		/// <summary>Gets the context in the document for which a mini toolbar will be opened.</summary>
		public ContextMenuLocation MiniToolbarContext => this.contextMenuLocation_0;

		/// <summary>Gets the location, in pixels, where the mini toolbar is displayed.</summary>
		public Point Location => new Point(this.struct77_0.struct82_0.int_0, this.struct77_0.struct82_0.int_1);

		/// <summary>Gets or sets the mini toolbar, which will be shown.</summary>
		public MiniToolbar MiniToolbar
		{
			get
			{
				if (this.miniToolbar_0 == null && !this.bool_0)
				{
					this.miniToolbar_0 = this.method_0(this.contextMenuLocation_0);
				}
				if (this.miniToolbar_0 != null)
				{
					this.miniToolbar_0.Boolean_1 = this.struct77_0.ushort_2 == 1;
				}
				return this.miniToolbar_0;
			}
			set
			{
				this.miniToolbar_0 = value;
				this.bool_0 = true;
			}
		}

		internal MiniToolbarOpeningEventArgs(ContextMenuLocation iContext, TextControl textcontrol, TextControlCore textControlCore_1)
		{
			this.contextMenuLocation_0 = iContext;
			this.textControl_0 = textcontrol;
			this.textControlCore_0 = textControlCore_1;
			this.struct77_0.method_0();
			this.textControlCore_0.method_60(TextPart.Auto, Enum83.const_297, 1, ref this.struct77_0);
		}

		private MiniToolbar method_0(ContextMenuLocation contextMenuLocation_1)
		{
			MiniToolbar miniToolbar = (((contextMenuLocation_1 & ContextMenuLocation.SelectedFrame) != 0) ? this.method_1() : (((contextMenuLocation_1 & (ContextMenuLocation.TextSelection | ContextMenuLocation.TextInputPosition)) != 0) ? this.method_2(contextMenuLocation_1) : null));
			if (miniToolbar != null && this.textControlCore_0.Boolean_2)
			{
				miniToolbar.RightToLeft = RightToLeft.Yes;
			}
			return miniToolbar;
		}

		private MiniToolbar method_1()
		{
			FrameBase item;
			if ((item = this.textControl_0.Frames.GetItem()) != null && !(item is ChartFrame) && !(item is Image))
			{
				(this.textControl_0.MiniToolbar_1 as ObjectMiniToolbar).method_8(item);
				return this.textControl_0.MiniToolbar_1;
			}
			return null;
		}

		private MiniToolbar method_2(ContextMenuLocation contextMenuLocation_1)
		{
			(this.textControl_0.MiniToolbar_0 as TextMiniToolbar).method_8(contextMenuLocation_1);
			return this.textControl_0.MiniToolbar_0;
		}
	}
}
