using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TX_Text_Control_Words.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => Settings.defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		public StringCollection RecentFiles
		{
			get
			{
				return (StringCollection)this["RecentFiles"];
			}
			set
			{
				this["RecentFiles"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10")]
		public int RecentFilesMaxItemCount
		{
			get
			{
				return (int)this["RecentFilesMaxItemCount"];
			}
			set
			{
				this["RecentFilesMaxItemCount"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("Inherit")]
		public RightToLeft RightToLeft
		{
			get
			{
				return (RightToLeft)this["RightToLeft"];
			}
			set
			{
				this["RightToLeft"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		public StringCollection QuickAccessToolbarContent
		{
			get
			{
				return (StringCollection)this["QuickAccessToolbarContent"];
			}
			set
			{
				this["QuickAccessToolbarContent"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		public List<UserInfo> KnownUsers
		{
			get
			{
				return (List<UserInfo>)this["KnownUsers"];
			}
			set
			{
				this["KnownUsers"] = value;
			}
		}
	}
}
