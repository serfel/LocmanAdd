using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonProofingTab class represents a Windows Forms ribbon tab for setting proofing options such as spelling, hyphenation or language settings.</summary>
	[ToolboxBitmap(typeof(RibbonProofingTab))]
	public class RibbonProofingTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonProofingTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_SpellingAndHyphenationGroup ribbon group inside the RibbonProofingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_SpellingAndHyphenationGroup,
			/// <summary>Identifies the TXITEM_EnableSpellChecking ribbon item inside the TXITEM_SpellingAndHyphenationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EnableSpellChecking,
			/// <summary>Identifies the TXITEM_EnableHyphenations ribbon item inside the TXITEM_SpellingAndHyphenationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EnableHyphenations,
			/// <summary>Identifies the TXITEM_Thesaurus ribbon item inside the TXITEM_SpellingAndHyphenationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Thesaurus,
			/// <summary>Identifies the TXITEM_Spelling ribbon item inside the TXITEM_SpellingAndHyphenationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Spelling,
			/// <summary>Identifies the TXITEM_ProofingSettingsGroup ribbon group inside the RibbonProofingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ProofingSettingsGroup,
			/// <summary>Identifies the TXITEM_LoadDictionary ribbon item inside the TXITEM_ProofingSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_LoadDictionary,
			/// <summary>Identifies the TXITEM_LoadThesaurusFile ribbon item inside the TXITEM_ProofingSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_LoadThesaurusFile,
			/// <summary>Identifies the TXITEM_SpellingOptions ribbon item inside the TXITEM_ProofingSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SpellingOptions,
			/// <summary>Identifies the TXITEM_TrackChangesGroup ribbon group inside the RibbonProofingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TrackChangesGroup,
			/// <summary>Identifies the TXITEM_TrackChanges ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TrackChanges,
			/// <summary>Identifies the TXITEM_AcceptTrackedChange ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AcceptTrackedChange,
			/// <summary>Identifies the TXITEM_RejectTrackedChange ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_RejectTrackedChange,
			/// <summary>Identifies the TXITEM_TrackedChanges ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TrackedChanges,
			/// <summary>Identifies the TXITEM_TrackedChanges_Sidebars ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TrackedChanges_Sidebars,
			/// <summary>Identifies the TXITEM_PreviousTrackedChange ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PreviousTrackedChange,
			/// <summary>Identifies the TXITEM_NextTrackedChange ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_NextTrackedChange,
			/// <summary>Identifies the TXITEM_ShowMarkup ribbon item inside the TXITEM_TrackChangesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowMarkup,
			/// <summary>Identifies the TXITEM_LanguageGroup ribbon group inside the RibbonProofingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_LanguageGroup,
			/// <summary>Identifies the TXITEM_DetectLanguages ribbon item inside the TXITEM_LanguageGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DetectLanguages,
			/// <summary>Identifies the TXITEM_SetLanguage ribbon item inside the TXITEM_LanguageGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SetLanguage
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonProofingTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_AcceptTrackedChange_AcceptAndMoveToNext drop-down item inside the TXITEM_AcceptTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_AcceptTrackedChange_AcceptAndMoveToNext,
			/// <summary>Identifies the TXITEM_AcceptTrackedChange_AcceptThisChange drop-down item inside the TXITEM_AcceptTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_AcceptTrackedChange_AcceptThisChange,
			/// <summary>Identifies the TXITEM_AcceptTrackedChange_AcceptAllChanges drop-down item inside the TXITEM_AcceptTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_AcceptTrackedChange_AcceptAllChanges,
			/// <summary>Identifies the TXITEM_AcceptTrackedChange_AcceptAllChangesAndStopTracking drop-down item inside the TXITEM_AcceptTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_AcceptTrackedChange_AcceptAllChangesAndStopTracking,
			/// <summary>Identifies the TXITEM_RejectTrackedChange_RejectAndMoveToNext drop-down item inside the TXITEM_RejectTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RejectTrackedChange_RejectAndMoveToNext,
			/// <summary>Identifies the TXITEM_RejectTrackedChange_RejectThisChange drop-down item inside the TXITEM_RejectTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RejectTrackedChange_RejectThisChange,
			/// <summary>Identifies the TXITEM_RejectTrackedChange_RejectAllChanges drop-down item inside the TXITEM_RejectTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RejectTrackedChange_RejectAllChanges,
			/// <summary>Identifies the TXITEM_RejectTrackedChange_RejectAllChangesAndStopTracking drop-down item inside the TXITEM_RejectTrackedChange's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RejectTrackedChange_RejectAllChangesAndStopTracking,
			/// <summary>Identifies the TXITEM_TrackedChanges_Sidebars_Vertical drop-down item inside the TXITEM_TrackedChanges_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TrackedChanges_Sidebars_Vertical,
			/// <summary>Identifies the TXITEM_TrackedChanges_Sidebars_Horizontal drop-down item inside the TXITEM_TrackedChanges_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TrackedChanges_Sidebars_Horizontal,
			/// <summary>Identifies the TXITEM_ShowMarkup_AllReviewers drop-down item inside the TXITEM_ShowMarkup's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ShowMarkup_AllReviewers
		}

		internal enum InternalRibbonItem
		{
			TXITEM_SpellingAndHyphenationGroup,
			TXITEM_EnableSpellChecking,
			TXITEM_EnableHyphenations,
			TXITEM_Thesaurus,
			TXITEM_Spelling,
			TXITEM_ProofingSettingsGroup,
			TXITEM_LoadDictionary,
			TXITEM_LoadThesaurusFile,
			TXITEM_SpellingOptions,
			TXITEM_TrackChangesGroup,
			TXITEM_TrackChanges,
			TXITEM_AcceptTrackedChange,
			TXITEM_AcceptTrackedChange_AcceptAndMoveToNext,
			TXITEM_AcceptTrackedChange_AcceptThisChange,
			TXITEM_AcceptTrackedChange_AcceptAllChanges,
			TXITEM_AcceptTrackedChange_AcceptAllChangesAndStopTracking,
			TXITEM_RejectTrackedChange,
			TXITEM_RejectTrackedChange_RejectAndMoveToNext,
			TXITEM_RejectTrackedChange_RejectThisChange,
			TXITEM_RejectTrackedChange_RejectAllChanges,
			TXITEM_RejectTrackedChange_RejectAllChangesAndStopTracking,
			TXITEM_TrackedChanges,
			TXITEM_TrackedChanges_Dialog,
			TXITEM_TrackedChanges_Sidebars,
			TXITEM_TrackedChanges_Sidebars_Vertical,
			TXITEM_TrackedChanges_Sidebars_Horizontal,
			TXITEM_PreviousTrackedChange,
			TXITEM_NextTrackedChange,
			TXITEM_ShowMarkup,
			TXITEM_ShowMarkup_AllReviewers,
			TXITEM_ShowMarkupSeperator1,
			TXITEM_LanguageGroup,
			TXITEM_DetectLanguages,
			TXITEM_SetLanguage
		}

		private Class509 class509_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		private Sidebar sidebar_0;

		private Sidebar sidebar_1;

		/// <summary>Gets or sets the horizontal sidebar that is connected to the RibbonProofingTab's TXITEM_TrackedChanges button.</summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Attribute3("PROP_TRACKEDCHANGESHORIZONTALSIDEBAR")]
		public Sidebar TrackedChangesHorizontalSidebar
		{
			get
			{
				return this.sidebar_1;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_1) != (this.sidebar_1 = value))
				{
					if (this.sidebar_1 != null)
					{
						this.sidebar_1.TextControl = this.TextControl_0;
					}
					(this.class509_0.BindingAdapter_0 as Class480).method_35(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the vertical sidebar that is connected to the RibbonProofingTab's TXITEM_TrackedChanges button.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_TRACKEDCHANGESSIDEBAR")]
		[DefaultValue(null)]
		public Sidebar TrackedChangesSidebar
		{
			get
			{
				return this.sidebar_0;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_0) != (this.sidebar_0 = value))
				{
					if (this.sidebar_0 != null)
					{
						this.sidebar_0.TextControl = this.TextControl_0;
					}
					(this.class509_0.BindingAdapter_0 as Class480).method_35(sidebar);
				}
			}
		}

		protected override Padding DefaultPadding => new Padding(0);

		protected override Padding DefaultMargin => new Padding(0);

		public override string KeyTip
		{
			get
			{
				if (base.KeyTip == string.Empty)
				{
					return this.resourceManager_0.GetString("KEYTIP_ProofingTab");
				}
				return base.KeyTip;
			}
			set
			{
				base.KeyTip = value;
			}
		}

		public override string Text
		{
			get
			{
				if (base.Text == string.Empty)
				{
					return this.resourceManager_0.GetString("HEADER_RibbonProofingTab");
				}
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		internal override TextControl TextControl_0
		{
			get
			{
				return base.TextControl_0;
			}
			set
			{
				if (base.TextControl_0 == value)
				{
					return;
				}
				if (base.TextControl_0 != null)
				{
					this.class509_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class509_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class509_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class509_0.BindingAdapter_0.TextControl = value));
				if (this.sidebar_1 != null)
				{
					this.sidebar_1.TextControl = value;
				}
				if (this.sidebar_0 != null)
				{
					this.sidebar_0.TextControl = value;
				}
				if (base.TextControl_0 != null)
				{
					this.class509_0.BindingAdapter_0.OnTextControlConnected();
					(this.class509_0.BindingAdapter_0 as Class480).method_34();
					if (this.class509_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class509_0.BindingAdapter_0.TextControl.PropertyChanged += this.class509_0.vmethod_0;
				}
				this.class509_0.method_5();
				(this.class509_0.BindingAdapter_0 as Class480).method_35(null);
			}
		}

		/// <summary>Initializes a new instance of the RibbonProofingTab class.</summary>
		public RibbonProofingTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class509_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class509_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class509_0.BindingAdapter_0.AwareOfDPI(base.method_0());
		}

		public Control FindItem(RibbonItem ribbonItem)
		{
			object value = null;
			foreach (Dictionary<string, object> item in this.list_0)
			{
				if (item.TryGetValue(ribbonItem.ToString(), out value))
				{
					return value as Control;
				}
			}
			return null;
		}

		public bool ShouldSerializeKeyTip()
		{
			return base.KeyTip != string.Empty;
		}

		public void ResetKeyTip()
		{
			this.KeyTip = string.Empty;
		}

		public bool ShouldSerializeText()
		{
			return base.Text != string.Empty;
		}

		private void method_2()
		{
			this.class509_0 = new Class509(this, new Class480());
			this.class509_0.method_10(base.RibbonGroups);
			this.class509_0.method_11(base.RibbonGroups);
			this.class509_0.method_12(base.RibbonGroups);
			this.class509_0.method_13(base.RibbonGroups);
			this.list_0.Add(this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items);
			this.list_0.Add(this.class509_0.TXITEM_ProofingSettingsGroup_Items);
			this.list_0.Add(this.class509_0.TXITEM_TrackChangesGroup_Items);
			this.list_0.Add(this.class509_0.TXITEM_LanguageGroup_Items);
		}
	}
}
