using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;
using ns25;
using ns27;
using TXTextControl;
using TXTextControl.DataVisualization;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class517
	{
		private const string string_0 = "Images.Small_16x16.";

		private const string string_1 = "Images.Large_32x32.";

		private static ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private static PointF pointF_0 = PointF.Empty;

		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>
		{
			{ "EventAutoSizeChanged", "AutoSizeChanged" },
			{ "EventBackColor", "BackColorChanged" },
			{ "EventBackgroundImage", "BackgroundImageChanged" },
			{ "EventBackgroundImageLayout", "BackgroundImageLayoutChanged" },
			{ "EventBindingContext", "BindingContextChanged" },
			{ "EventCausesValidation", "CausesValidationChanged" },
			{ "EventClick", "Click" },
			{ "EventClientSize", "ClientSizeChanged" },
			{ "EventContextMenu", "ContextMenuChanged" },
			{ "EventContextMenuStrip", "ContextMenuStripChanged" },
			{ "EventCursor", "CursorChanged" },
			{ "EventDock", "DockChanged" },
			{ "EventDoubleClick", "DoubleClick" },
			{ "EventDragLeave", "DragLeave" },
			{ "EventEnabled", "EnabledChanged" },
			{ "EventEnter", "Enter" },
			{ "EventFont", "FontChanged" },
			{ "EventForeColor", "ForeColorChanged" },
			{ "EventGotFocus", "GotFocus" },
			{ "EventHandleCreated", "HandleCreated" },
			{ "EventHandleDestroyed", "HandleDestroyed" },
			{ "EventLeave", "Leave" },
			{ "EventLocation", "LocationChanged" },
			{ "EventLostFocus", "LostFocus" },
			{ "EventMarginChanged", "MarginChanged" },
			{ "EventMouseCaptureChanged", "MouseCaptureChanged" },
			{ "EventMouseDown", "MouseDown" },
			{ "EventMouseEnter", "MouseEnter" },
			{ "EventMouseHover", "MouseHover" },
			{ "EventMouseLeave", "MouseLeave" },
			{ "EventMouseUp", "MouseUp" },
			{ "EventMove", "Move" },
			{ "EventPaddingChanged", "PaddingChanged" },
			{ "EventParent", "ParentChanged" },
			{ "EventRegionChanged", "RegionChanged" },
			{ "EventResize", "Resize" },
			{ "EventRightToLeft", "RightToLeftChanged" },
			{ "EventSize", "SizeChanged" },
			{ "EventStyleChanged", "StyleChanged" },
			{ "EventSystemColorsChanged", "SystemColorsChanged" },
			{ "EventTabIndex", "TabIndexChanged" },
			{ "EventTabStop", "TabStopChanged" },
			{ "EventText", "TextChanged" },
			{ "EventValidated", "Validated" },
			{ "EventVisible", "VisibleChanged" },
			{ "EventDownButtonClicked", "DownButtonClicked" },
			{ "EventTextValidated", "TextValidated" },
			{ "EventUpButtonClicked", "UpButtonClicked" },
			{ "CheckedChangedEvent", "CheckedChanged" },
			{ "ButtonClickEvent", "ButtonClick" },
			{ "DropDownOpeningEvent", "DropDownOpening" },
			{ "DropDownClosedEvent", "DropDownClosed" },
			{ "EventItemClick", "ItemClick" },
			{ "EventItemMouseDown", "ItemMouseDown" },
			{ "EventItemMouseEnter", "ItemMouseEnter" },
			{ "EventItemMouseLeave", "ItemMouseLeave" },
			{ "EventItemMouseUp", "ItemMouseUp" },
			{ "EVENT_DATASOURCECHANGED ", "DataSourceChanged" },
			{ "EVENT_DISPLAYMEMBERCHANGED", "DisplayMemberChanged" },
			{ "EVENT_DRAWITEM", "DrawItem" },
			{ "EVENT_DROPDOWN", "DropDown" },
			{ "EVENT_DROPDOWNCLOSED", "DropDownClosed" },
			{ "EVENT_DROPDOWNSTYLE", "DropDownStyleChanged" },
			{ "EVENT_FORMAT", "Format" },
			{ "EVENT_FORMATINFOCHANGED", "FormatInfoChanged" },
			{ "EVENT_FORMATSTRINGCHANGED", "FormatStringChanged" },
			{ "EVENT_FORMATTINGENABLEDCHANGED", "FormattingEnabledChanged" },
			{ "EVENT_MEASUREITEM ", "MeasureItem" },
			{ "EVENT_SELECTEDINDEXCHANGED", "SelectedIndexChanged" },
			{ "EVENT_SELECTEDVALUECHANGED", "SelectedValueChanged" },
			{ "EVENT_SELECTIONCHANGECOMMITTED", "SelectionChangeCommitted" },
			{ "EVENT_TEXTUPDATE", "TextUpdate" },
			{ "EVENT_VALUEMEMBERCHANGED", "ValueMemberChanged" }
		};

		private static Bitmap bitmap_0 = null;

		private static Bitmap bitmap_1 = null;

		private static Bitmap bitmap_2 = null;

		private static Bitmap bitmap_3 = null;

		private static Bitmap bitmap_4 = null;

		private static Bitmap bitmap_5 = null;

		private static Bitmap bitmap_6 = null;

		private static Bitmap bitmap_7 = null;

		private static Bitmap bitmap_8 = null;

		private static Bitmap bitmap_9 = null;

		private static Bitmap bitmap_10 = null;

		private static Bitmap bitmap_11 = null;

		private static Bitmap bitmap_12 = null;

		private static Bitmap bitmap_13 = null;

		internal static Bitmap Bitmap_0
		{
			get
			{
				if (Class517.bitmap_0 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_0.Clone();
			}
		}

		internal static Bitmap Bitmap_1
		{
			get
			{
				if (Class517.bitmap_1 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_1.Clone();
			}
		}

		internal static Bitmap Bitmap_2
		{
			get
			{
				if (Class517.bitmap_2 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_2.Clone();
			}
		}

		internal static Bitmap Bitmap_3
		{
			get
			{
				if (Class517.bitmap_3 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_3.Clone();
			}
		}

		internal static Bitmap Bitmap_4
		{
			get
			{
				if (Class517.bitmap_5 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_5.Clone();
			}
		}

		internal static Bitmap Bitmap_5
		{
			get
			{
				if (Class517.bitmap_4 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_4.Clone();
			}
		}

		internal static Bitmap Bitmap_6
		{
			get
			{
				if (Class517.bitmap_6 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_6.Clone();
			}
		}

		internal static Bitmap Bitmap_7
		{
			get
			{
				if (Class517.bitmap_7 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_7.Clone();
			}
		}

		internal static Bitmap Bitmap_8
		{
			get
			{
				if (Class517.bitmap_8 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_8.Clone();
			}
		}

		internal static Bitmap Bitmap_9
		{
			get
			{
				if (Class517.bitmap_9 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_9.Clone();
			}
		}

		internal static Bitmap Bitmap_10
		{
			get
			{
				if (Class517.bitmap_10 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_10.Clone();
			}
		}

		internal static Bitmap Bitmap_11
		{
			get
			{
				if (Class517.bitmap_11 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_11.Clone();
			}
		}

		internal static Bitmap Bitmap_12
		{
			get
			{
				if (Class517.bitmap_12 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_12.Clone();
			}
		}

		internal static Bitmap Bitmap_13
		{
			get
			{
				if (Class517.bitmap_13 == null)
				{
					return null;
				}
				return (Bitmap)Class517.bitmap_13.Clone();
			}
		}

		internal static void smethod_0(PointF pointF_1)
		{
			if (pointF_1.X != Class517.pointF_0.X || pointF_1.Y != Class517.pointF_0.Y)
			{
				Class517.pointF_0 = pointF_1;
				Class517.bitmap_0 = Class517.smethod_53(Sidebar.FindAndReplaceItem.TXITEM_FindNext.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_1 = Class517.smethod_53(Sidebar.FindAndReplaceItem.TXITEM_SearchUp.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_2 = Class517.smethod_53(ResourceProvider.GeneralItem.TXITEM_Checkmark.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_4 = Class517.smethod_53(ResourceProvider.GeneralItem.TXITEM_Launcher.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_6 = Class517.smethod_53(RibbonInsertTab.RibbonItem.TXITEM_InsertTable.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_7 = Class517.smethod_53(ResourceProvider.GeneralItem.TXITEM_Minus.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_8 = Class517.smethod_53(ResourceProvider.GeneralItem.TXITEM_Plus.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_9 = Class517.smethod_53(ResourceProvider.GeneralItem.TXITEM_Close.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_10 = Class517.smethod_53(ResourceProvider.GeneralItem.TXITEM_Pinned.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_11 = Class517.smethod_53(ResourceProvider.GeneralItem.TXITEM_Unpinned.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_12 = Class517.smethod_53(RibbonReportingTab.RibbonItem.TXITEM_InsertMergeField.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Class517.bitmap_13 = Class517.smethod_53(RibbonReportingTab.RibbonItem.TXITEM_InsertMergeBlock.ToString(), ImageProvider.ImageKind.Small_16x16, pointF_1);
				Size size_ = Class466.smethod_3((uint)pointF_1.X);
				Class517.bitmap_3 = Class517.smethod_55(ResourceProvider.GeneralItem.TXITEM_Checked.ToString(), ImageProvider.ImageKind.Small_16x16, size_, pointF_1);
				Class517.bitmap_5 = Class517.smethod_55(ResourceProvider.GeneralItem.TXITEM_Unchecked.ToString(), ImageProvider.ImageKind.Small_16x16, size_, pointF_1);
			}
		}

		internal static RibbonDropDown smethod_1(Control control_0)
		{
			if (control_0 != null)
			{
				if (control_0 is RibbonDropDown)
				{
					return (RibbonDropDown)control_0;
				}
				return Class517.smethod_1(control_0.Parent);
			}
			return null;
		}

		internal static void smethod_2(RibbonDropDown ribbonDropDown_0, RibbonItemCollection ribbonItemCollection_0)
		{
			bool flag;
			if (!(flag = ribbonDropDown_0.Items.Count != ribbonItemCollection_0.Count))
			{
				for (int i = 0; i < ribbonDropDown_0.Items.Count; i++)
				{
					if (((ToolStripControlHost)ribbonDropDown_0.Items[i]).Control != ribbonItemCollection_0[i])
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			ribbonDropDown_0.Items.Clear();
			foreach (Control item in ribbonItemCollection_0)
			{
				if (item.Visible)
				{
					ToolStripControlHost toolStripControlHost = new ToolStripControlHost(item);
					toolStripControlHost.Font = item.Font;
					ToolStripControlHost toolStripControlHost2 = toolStripControlHost;
					toolStripControlHost2.Dock = item.Dock;
					ribbonDropDown_0.Items.Add(toolStripControlHost2);
				}
			}
		}

		internal static void smethod_3(object object_0, object object_1)
		{
			if (object_0 is IContentItem)
			{
				((IContentItem)object_1).Original = (IRibbonItem)object_0;
			}
			Class517.smethod_4(object_0, object_1);
			Class517.smethod_7(object_0, object_1);
			if (object_1 is IRibbonItem)
			{
				(object_1 as IRibbonItem).IsUpdatingItemEnabled = true;
			}
		}

		private static void smethod_4(object object_0, object object_1)
		{
			PropertyInfo[] properties = object_0.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.CanWrite)
				{
					if (propertyInfo.Name != "Parent" && propertyInfo.Name != "ItemsSource" && propertyInfo.Name != "SelectedIndices" && propertyInfo.Name != "SelectedItems" && propertyInfo.Name != "WindowTarget" && propertyInfo.Name != "Clone" && (propertyInfo.Name != "Visible" || object_1 is DialogBoxLauncher) && propertyInfo.Name != "LayoutSettings" && propertyInfo.Name != "SelectedItems" && propertyInfo.Name != "IsSelected" && propertyInfo.Name != "IsScalable")
					{
						propertyInfo.SetValue(object_1, propertyInfo.GetValue(object_0, null), null);
					}
				}
				else
				{
					if (!(propertyInfo.Name != "ParentCollection") || !(propertyInfo.Name != "RibbonListViewItems") || object_0 is RibbonTextBox)
					{
						continue;
					}
					object value;
					if ((value = propertyInfo.GetValue(object_0, null)) is IList)
					{
						IList list = (IList)propertyInfo.GetValue(object_1, null);
						foreach (object item in (IList)value)
						{
							if (item is RibbonListView.Class555 || item is RibbonListView.Control14)
							{
								continue;
							}
							if (item is Control)
							{
								object obj = Activator.CreateInstance(item.GetType(), item is RibbonTextBox.Class562);
								Class517.smethod_3(item, obj);
								if (list is RibbonItemCollection)
								{
									RibbonItemCollection ribbonItemCollection = list as RibbonItemCollection;
									ribbonItemCollection.Object_0 = (value as RibbonItemCollection).Object_0;
									ribbonItemCollection.Add(obj as Control);
								}
								else
								{
									list.Add(obj);
								}
							}
							else
							{
								list.Add(item);
							}
						}
					}
					else if (propertyInfo.PropertyType == typeof(RibbonToolTip))
					{
						RibbonToolTip ribbonToolTip = propertyInfo.GetValue(object_1, null) as RibbonToolTip;
						RibbonToolTip ribbonToolTip2 = propertyInfo.GetValue(object_0, null) as RibbonToolTip;
						ribbonToolTip.Title = ribbonToolTip2.Title;
						ribbonToolTip.Description = ribbonToolTip2.Description;
					}
				}
			}
			if (object_1 is IRibbonItem)
			{
				((IRibbonItem)object_1).IsDefaultRibbonTabItem = ((IRibbonItem)object_0).IsDefaultRibbonTabItem;
				((IRibbonItem)object_1).RibbonGroup = ((IRibbonItem)object_0).RibbonGroup;
			}
			if (object_1 is IRibbonToolStripItemProvider)
			{
				((IRibbonToolStripItemProvider)object_1).ToolStripItem = ((IRibbonToolStripItemProvider)object_0).ToolStripItem;
			}
			if (object_1 is RibbonListView)
			{
				RibbonListView ribbonListView = object_1 as RibbonListView;
				RibbonListView ribbonListView2 = object_0 as RibbonListView;
				if (!ribbonListView.Boolean_5 && ribbonListView.RibbonListViewItems.Count > 0)
				{
					ribbonListView.ScrollTo(ribbonListView.RibbonListViewItems[ribbonListView2.Class553_0.Int32_0]);
				}
				ribbonListView.Font = ribbonListView2.Font;
				ribbonListView.ItemsSource = Class517.smethod_5(ribbonListView2, ribbonListView);
				ribbonListView.SelectedIndices = ribbonListView2.SelectedIndices;
			}
			if (object_1 is RibbonTextBox)
			{
				RibbonTextBox ribbonTextBox = object_1 as RibbonTextBox;
				RibbonTextBox ribbonTextBox2 = object_0 as RibbonTextBox;
				ribbonTextBox.Nullable_0 = ribbonTextBox2.Nullable_0;
				ribbonTextBox.DisplayMode = ((IScalable)ribbonTextBox2).DefaultDisplayMode;
				ribbonTextBox2.RibbonTextBox_0 = ribbonTextBox;
			}
		}

		internal static RibbonListView.RibbonListViewItem[] smethod_5(RibbonListView ribbonListView_0, RibbonListView ribbonListView_1)
		{
			RibbonListView.RibbonListViewItem[] array = new RibbonListView.RibbonListViewItem[ribbonListView_0.RibbonListViewItems.Count];
			Type typeFromHandle = typeof(RibbonListView.RibbonListViewItem);
			bool flag = (ribbonListView_0.ViewMode & RibbonListView.ListViewMode.DropDown) == RibbonListView.ListViewMode.DropDown;
			((IRibbonItem)ribbonListView_1).AwareOfDPI(((IRibbonItem)ribbonListView_0).DPI);
			for (int i = 0; i < array.Length; i++)
			{
				RibbonListView.RibbonListViewItem ribbonListViewItem = ribbonListView_0.RibbonListViewItems[i];
				RibbonListView.RibbonListViewItem ribbonListViewItem2 = Activator.CreateInstance(typeFromHandle) as RibbonListView.RibbonListViewItem;
				Class517.smethod_3(ribbonListViewItem, ribbonListViewItem2);
				if (flag)
				{
					ribbonListViewItem2.RibbonListView_0 = ribbonListView_1;
					ribbonListViewItem2.RibbonListViewItem_0 = ribbonListViewItem;
					ribbonListViewItem2.DropDown.Items = ribbonListViewItem.DropDown.Items;
					ribbonListViewItem2.DropDown.SelectedItem = ribbonListViewItem.DropDown.SelectedItem;
					ribbonListViewItem2.DropDown.Text = ribbonListViewItem.DropDown.Text;
					ribbonListViewItem2.DropDown.ShowCheckMargin = ribbonListViewItem.DropDown.ShowCheckMargin;
					ribbonListViewItem2.DropDown.ShowText = ribbonListViewItem.DropDown.ShowText;
					ribbonListViewItem2.method_3(flag);
				}
				array[i] = ribbonListViewItem2;
			}
			return array;
		}

		internal static void smethod_6(IRibbonItem iribbonItem_0, RibbonGroup ribbonGroup_0)
		{
			iribbonItem_0.AwareOfDPI(ribbonGroup_0.PointF_0);
			iribbonItem_0.RibbonGroup = ribbonGroup_0;
			bool flag = true;
			if (!(flag = iribbonItem_0 is RibbonMenuButton) && !(iribbonItem_0 is RibbonListView))
			{
				return;
			}
			RibbonItemCollection ribbonItemCollection = (flag ? ((RibbonMenuButton)iribbonItem_0).DropDownItems : ((RibbonListView)iribbonItem_0).DropDownItems);
			foreach (IRibbonItem item in ribbonItemCollection)
			{
				Class517.smethod_6(item, ribbonGroup_0);
			}
		}

		internal static void smethod_7(object object_0, object object_1)
		{
			if (!(object_0 is Component))
			{
				return;
			}
			EventHandlerList object_2 = (EventHandlerList)object_0.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(object_0, null);
			FieldInfo field = typeof(EventHandlerList).GetField("head", BindingFlags.Instance | BindingFlags.NonPublic);
			Dictionary<object, Delegate[]> dictionary = Class517.smethod_9(field, object_2);
			foreach (object key in dictionary.Keys)
			{
				FieldInfo fieldInfo_;
				string text = Class517.smethod_11(object_0, key, out fieldInfo_);
				if (text != null)
				{
					Dictionary<string, Dictionary<object, Delegate[]>> dictionary2 = new Dictionary<string, Dictionary<object, Delegate[]>>();
					dictionary2.Add(text, dictionary);
					Dictionary<string, Dictionary<object, Delegate[]>> dictionary_ = dictionary2;
					Class517.smethod_8(dictionary_, object_1, fieldInfo_, text, key);
				}
			}
		}

		private static void smethod_8(Dictionary<string, Dictionary<object, Delegate[]>> dictionary_1, object object_0, FieldInfo fieldInfo_0, string string_2, object object_1)
		{
			object value = fieldInfo_0.GetValue(object_0);
			Type type = object_0.GetType();
			PropertyInfo property = type.GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
			EventHandlerList eventHandlerList = (EventHandlerList)property.GetValue(object_0, null);
			foreach (KeyValuePair<object, Delegate[]> item in dictionary_1[string_2])
			{
				Delegate[] value2 = item.Value;
				foreach (Delegate value3 in value2)
				{
					if (item.Key == object_1)
					{
						eventHandlerList.AddHandler(value, value3);
					}
				}
			}
		}

		private static Dictionary<object, Delegate[]> smethod_9(FieldInfo fieldInfo_0, object object_0)
		{
			Dictionary<object, Delegate[]> dictionary = new Dictionary<object, Delegate[]>();
			object value = fieldInfo_0.GetValue(object_0);
			if (value != null)
			{
				Type type = value.GetType();
				FieldInfo field = type.GetField("handler", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field2 = type.GetField("key", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field3 = type.GetField("next", BindingFlags.Instance | BindingFlags.NonPublic);
				dictionary = Class517.smethod_10(dictionary, value, field, field2, field3);
			}
			return dictionary;
		}

		private static Dictionary<object, Delegate[]> smethod_10(Dictionary<object, Delegate[]> dictionary_1, object object_0, FieldInfo fieldInfo_0, FieldInfo fieldInfo_1, FieldInfo fieldInfo_2)
		{
			if (object_0 != null)
			{
				Delegate @delegate = (Delegate)fieldInfo_0.GetValue(object_0);
				object value = fieldInfo_1.GetValue(object_0);
				object value2 = fieldInfo_2.GetValue(object_0);
				if ((object)@delegate != null)
				{
					Delegate[] invocationList = @delegate.GetInvocationList();
					if (invocationList.Length > 0)
					{
						dictionary_1.Add(value, invocationList);
					}
				}
				if (value2 != null)
				{
					dictionary_1 = Class517.smethod_10(dictionary_1, value2, fieldInfo_0, fieldInfo_1, fieldInfo_2);
				}
			}
			return dictionary_1;
		}

		private static string smethod_11(object object_0, object object_1, out FieldInfo fieldInfo_0)
		{
			Type type = object_0.GetType();
			foreach (string key in Class517.dictionary_0.Keys)
			{
				fieldInfo_0 = Class517.smethod_12(key, type);
				if (fieldInfo_0 != null)
				{
					object value = fieldInfo_0.GetValue(object_0);
					if (value == object_1)
					{
						return Class517.dictionary_0[key];
					}
				}
			}
			fieldInfo_0 = null;
			return null;
		}

		private static FieldInfo smethod_12(string string_2, Type type_0)
		{
			FieldInfo result = null;
			if (type_0 != null && (result = type_0.GetField(string_2, BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField)) == null)
			{
				return Class517.smethod_12(string_2, type_0.BaseType);
			}
			return result;
		}

		internal static VisualStyleElement smethod_13(bool bool_0)
		{
			if (!bool_0)
			{
				return VisualStyleElement.ToolBar.Button.Normal;
			}
			return VisualStyleElement.ToolBar.Button.Checked;
		}

		internal static VisualStyleElement smethod_14(bool bool_0)
		{
			if (!bool_0)
			{
				return VisualStyleElement.ToolBar.Button.Hot;
			}
			return VisualStyleElement.ToolBar.Button.HotChecked;
		}

		internal static int smethod_15(int int_0)
		{
			int_0 += ((int_0 % 2 != 0) ? 1 : 0);
			return int_0;
		}

		private static Point[] smethod_16(Rectangle rectangle_0, ArrowDirection arrowDirection_0, PointF pointF_1)
		{
			Point point = new Point(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			Point[] array = null;
			int num = Class517.smethod_45(2, pointF_1.X);
			int num2 = Class517.smethod_45(2, pointF_1.Y);
			int num3 = Class517.smethod_45(2, pointF_1.X);
			int num4 = Class517.smethod_45(4, pointF_1.Y);
			return arrowDirection_0 switch
			{
				ArrowDirection.Right => new Point[3]
				{
					new Point(point.X - num, point.Y - num4),
					new Point(point.X - num, point.Y + num4),
					new Point(point.X + num3, point.Y)
				}, 
				ArrowDirection.Left => new Point[3]
				{
					new Point(point.X + num, point.Y - num4),
					new Point(point.X + num, point.Y + num4),
					new Point(point.X - num3, point.Y)
				}, 
				ArrowDirection.Up => new Point[3]
				{
					new Point(point.X - num - 1, point.Y + 1),
					new Point(point.X + num + 1, point.Y + 1),
					new Point(point.X, point.Y - num2 - 1)
				}, 
				_ => new Point[3]
				{
					new Point(point.X - num, point.Y - 1),
					new Point(point.X + num + 1, point.Y - 1),
					new Point(point.X, point.Y + num2)
				}, 
			};
		}

		internal static void smethod_17(Graphics graphics_0, Rectangle rectangle_0, Color color_0, ArrowDirection arrowDirection_0, PointF pointF_1)
		{
			using SolidBrush brush = new SolidBrush(color_0);
			Point[] points = Class517.smethod_16(rectangle_0, arrowDirection_0, pointF_1);
			graphics_0.FillPolygon(brush, points);
		}

		internal static void smethod_18(Graphics graphics_0, Rectangle rectangle_0, Color color_0, PointF pointF_1)
		{
			using SolidBrush brush = new SolidBrush(color_0);
			Point point = new Point(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			graphics_0.DrawLine(new Pen(brush, Class517.smethod_45(1, pointF_1.X)), point.X - Class517.smethod_45(3, pointF_1.X), point.Y - Class517.smethod_45(3, pointF_1.Y), point.X + Class517.smethod_45(3, pointF_1.X), point.Y - Class517.smethod_45(3, pointF_1.Y));
			Point[] points = Class517.smethod_16(rectangle_0, ArrowDirection.Down, new PointF(pointF_1.X, pointF_1.Y));
			graphics_0.FillPolygon(brush, points);
		}

		internal static RibbonTab smethod_19(object object_0)
		{
			if (object_0 is IRibbonItem)
			{
				IRibbonItem ribbonItem = object_0 as IRibbonItem;
				if (ribbonItem.RibbonGroup != null && ribbonItem.RibbonGroup.Class498_0 != null)
				{
					return ribbonItem.RibbonGroup.Class498_0.Control_0 as RibbonTab;
				}
				return null;
			}
			if (object_0 is DialogBoxLauncher)
			{
				DialogBoxLauncher dialogBoxLauncher = object_0 as DialogBoxLauncher;
				return dialogBoxLauncher.RibbonGroup_0.Class498_0.Control_0 as RibbonTab;
			}
			return null;
		}

		internal static ImageAttributes smethod_20(int int_0)
		{
			ColorMatrix colorMatrix = new ColorMatrix();
			colorMatrix.Matrix33 = 1f - (float)int_0 / 100f;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			return imageAttributes;
		}

		internal static Point? smethod_21(IRibbonItem iribbonItem_0)
		{
			if (iribbonItem_0.IsRibbonDropDownItem)
			{
				return null;
			}
			int x = 0;
			int num = ((iribbonItem_0.RibbonGroup is HorizontalRibbonGroup) ? (iribbonItem_0 as Control).Parent.Location.Y : (iribbonItem_0 as Control).Location.Y);
			int y = iribbonItem_0.RibbonGroup.Height - num;
			return new Point(x, y);
		}

		internal static string smethod_22(int int_0, string string_2)
		{
			string text = AppDomain.CurrentDomain.BaseDirectory + string_2 + "\\";
			if (!Directory.Exists(text))
			{
				RegistryKey registryKey = null;
				string text2 = null;
				string text3 = null;
				string[] string_3 = TextControlCore.string_2;
				foreach (string text4 in string_3)
				{
					text2 = text4 + "TX Spell " + int_0 + ".0 .NET for Windows Forms";
					if ((registryKey = Registry.LocalMachine.OpenSubKey(text2)) != null)
					{
						text3 = (string)registryKey.GetValue(null) + "\\" + string_2 + "\\";
						break;
					}
				}
				if (text3 != null && Directory.Exists(text3))
				{
					text = text3;
				}
			}
			return text;
		}

		internal static void smethod_23(object object_0, string string_2, string string_3, object object_1)
		{
			if (string_2 != null && string_3 != null)
			{
				EventInfo @event = object_0.GetType().GetEvent(string_2);
				if (@event != null)
				{
					MethodInfo method = object_1.GetType().GetMethod(string_3, BindingFlags.Instance | BindingFlags.NonPublic);
					Delegate handler = Delegate.CreateDelegate(@event.EventHandlerType, object_1, method, throwOnBindFailure: true);
					@event.RemoveEventHandler(object_0, handler);
					@event.AddEventHandler(object_0, handler);
				}
			}
		}

		internal static void smethod_24(object object_0, string string_2, string string_3, object object_1)
		{
			if (string_2 != null && string_3 != null)
			{
				EventInfo @event = object_0.GetType().GetEvent(string_2);
				if (@event != null)
				{
					MethodInfo method = object_1.GetType().GetMethod(string_3, BindingFlags.Instance | BindingFlags.NonPublic);
					Delegate handler = Delegate.CreateDelegate(@event.EventHandlerType, object_1, method, throwOnBindFailure: true);
					@event.RemoveEventHandler(object_0, handler);
				}
			}
		}

		internal static void smethod_25(RibbonGroup ribbonGroup_0)
		{
			if (ribbonGroup_0 == null || ribbonGroup_0.Boolean_0)
			{
				return;
			}
			if (ribbonGroup_0.Class498_0 != null && ribbonGroup_0.Class498_0.Visible)
			{
				if (ribbonGroup_0.Class498_0.Control_0 is MiniToolbar)
				{
					ribbonGroup_0.Boolean_3 = true;
					ribbonGroup_0.Class498_0.method_4();
				}
				else if (ribbonGroup_0.Class498_0.Boolean_0)
				{
					ribbonGroup_0.method_5();
					ribbonGroup_0.Class498_0.method_5();
					ribbonGroup_0.Class498_0.method_7(ribbonGroup_0.Class498_0.Width);
				}
			}
			else
			{
				ribbonGroup_0.Boolean_3 = true;
			}
		}

		internal static RibbonButton smethod_26(Dictionary<string, object> dictionary_1, BindingAdapter.Enum133 enum133_0, IconTextRelation iconTextRelation_0, bool bool_0, string string_2, string string_3, BindingAdapter bindingAdapter_0)
		{
			RibbonButton ribbonButton;
			switch (enum133_0)
			{
			default:
				return null;
			case BindingAdapter.Enum133.const_0:
				ribbonButton = new RibbonButton();
				break;
			case BindingAdapter.Enum133.const_1:
				ribbonButton = new RibbonMenuButton();
				break;
			case BindingAdapter.Enum133.const_2:
				ribbonButton = new RibbonSplitButton();
				break;
			case BindingAdapter.Enum133.const_3:
				ribbonButton = new RibbonToggleButton();
				break;
			}
			ribbonButton.Name = string_2;
			ribbonButton.DisplayMode = iconTextRelation_0;
			ribbonButton.Text = Class517.resourceManager_0.GetString(string_2.Replace("TXITEM", "HEADER"));
			Class517.smethod_23(ribbonButton, string_3, string_2 + "_Handler", bindingAdapter_0);
			IRibbonItem ribbonItem = ribbonButton;
			if (bool_0)
			{
				if (iconTextRelation_0 == IconTextRelation.LargeIconLabeled)
				{
					ribbonItem.HasLargeIcon = true;
				}
				ribbonItem.HasSmallIcon = true;
			}
			ribbonItem.IsDefaultRibbonTabItem = true;
			dictionary_1?.Add(ribbonButton.Name, ribbonButton);
			return ribbonButton;
		}

		internal static int smethod_27(float float_0, int int_0)
		{
			return (int)((double)int_0 * 0.00069444444444444447 * (double)float_0);
		}

		internal static void smethod_28(Control control_0)
		{
			if (control_0 == null)
			{
				return;
			}
			Control topLevelControl = control_0.TopLevelControl;
			for (ToolStripDropDown toolStripDropDown = topLevelControl as ToolStripDropDown; toolStripDropDown != null; toolStripDropDown = ((toolStripDropDown is RibbonDropDown) ? (toolStripDropDown as RibbonDropDown).Owner : null))
			{
				if (!(toolStripDropDown is MiniToolbar))
				{
					toolStripDropDown.Close();
				}
			}
		}

		internal static void smethod_29(Dictionary<string, object> dictionary_1)
		{
			foreach (object value in dictionary_1.Values)
			{
				PropertyInfo property = value.GetType().GetProperty("ToolTip");
				PropertyInfo property2 = value.GetType().GetProperty("Name");
				if (property != null)
				{
					RibbonToolTip ribbonToolTip = property.GetValue(value, null) as RibbonToolTip;
					if (property2 != null && ribbonToolTip != null)
					{
						string text = (string)property2.GetValue(value, null);
						if (text != null)
						{
							string name = text.Replace("TXITEM", "TOOLTIPTITLE");
							string name2 = text.Replace("TXITEM", "TOOLTIP");
							string @string = Class517.resourceManager_0.GetString(name);
							if (@string != null)
							{
								ribbonToolTip.Title = @string;
							}
							string string2 = Class517.resourceManager_0.GetString(name2);
							if (string2 != null)
							{
								ribbonToolTip.Description = string2;
							}
						}
					}
				}
				PropertyInfo property3 = value.GetType().GetProperty("KeyTip");
				if (!(property3 != null) || !(property2 != null))
				{
					continue;
				}
				string text2 = property2.GetValue(value, null) as string;
				if (text2 != null)
				{
					string name3 = text2.Replace("TXITEM", "KEYTIP");
					string string3 = Class517.resourceManager_0.GetString(name3);
					if (string3 != null)
					{
						property3.SetValue(value, string3, null);
					}
				}
			}
		}

		internal static int smethod_30(int int_0)
		{
			int num = int_0;
			for (num %= 360; num < 0; num += 360)
			{
			}
			return num;
		}

		internal static bool? smethod_31(string string_2, Control control_0, object object_0)
		{
			Type type = control_0.GetType();
			PropertyInfo property = type.GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
			EventHandlerList eventHandlerList = (EventHandlerList)property.GetValue(control_0, null);
			FieldInfo field = type.GetField(string_2, BindingFlags.Static | BindingFlags.NonPublic);
			if (field != null)
			{
				object value = field.GetValue(null);
				Delegate @delegate = eventHandlerList[value];
				if ((object)@delegate != null)
				{
					Delegate[] invocationList = @delegate.GetInvocationList();
					foreach (Delegate delegate2 in invocationList)
					{
						if (delegate2.Target == object_0)
						{
							return true;
						}
					}
				}
				return false;
			}
			return null;
		}

		internal static int smethod_32(RibbonGroup ribbonGroup_0)
		{
			if (ribbonGroup_0 is Class497)
			{
				return ribbonGroup_0.MinimumSize.Height;
			}
			return RibbonGroup.smethod_0(ribbonGroup_0.Font, ribbonGroup_0.RowCount, ribbonGroup_0.PointF_0, ribbonGroup_0.Class498_0 != null && ribbonGroup_0.Class498_0.Control_0 is MiniToolbar);
		}

		internal static int smethod_33(RibbonGroup ribbonGroup_0, bool bool_0)
		{
			if (!(ribbonGroup_0 is Class497) && bool_0)
			{
				return ribbonGroup_0.Class515_0.Size_0.Width + ribbonGroup_0.Padding.Horizontal;
			}
			return 0;
		}

		internal static void smethod_34(TextControl textControl_0, out Class440 class440_0, out ChartFrame chartFrame_0)
		{
			class440_0 = null;
			chartFrame_0 = null;
			if (textControl_0 != null && !(Class440.Assembly_0 == null))
			{
				chartFrame_0 = textControl_0.Charts.GetItem();
				if (chartFrame_0 != null)
				{
					class440_0 = new Class440(chartFrame_0);
				}
			}
		}

		internal static bool smethod_35(Class440 class440_0)
		{
			if (class440_0.Class452_0.Count > 0)
			{
				if (class440_0.Class452_0[0].SeriesChartType_0 != Class454.SeriesChartType.Pie)
				{
					return class440_0.Class452_0[0].SeriesChartType_0 == Class454.SeriesChartType.Doughnut;
				}
				return true;
			}
			return false;
		}

		internal static Point smethod_36(Size size_0, Rectangle rectangle_0, TextControl textControl_0)
		{
			double num = (double)textControl_0.ZoomFactor / 100.0;
			Graphics graphics = Graphics.FromHwnd(textControl_0.Handle);
			Rectangle rectangle = new Rectangle(size: new Size((int)((float)(textControl_0.Width * 1440) / graphics.DpiX), (int)((float)(textControl_0.Height * 1440) / graphics.DpiY)), location: new Point(textControl_0.ScrollLocation.X, (int)((double)textControl_0.ScrollLocation.Y * num)));
			Size size2 = new Size((int)((float)(size_0.Width * 1440) / graphics.DpiX), (int)((float)(size_0.Height * 1440) / graphics.DpiY));
			graphics.Dispose();
			int y = textControl_0.ScrollLocation.Y;
			Rectangle rectangle2 = new Rectangle((int)((double)rectangle_0.X * num), (int)((double)rectangle_0.Y * num), (int)((double)rectangle_0.Width * num), (int)((double)rectangle_0.Height * num));
			if (rectangle2.Bottom > rectangle.Bottom || rectangle2.Bottom < rectangle.Top)
			{
				int num2 = ((rectangle2.Height > rectangle.Height) ? (rectangle2.Height - rectangle.Height) : size2.Height);
				y = rectangle_0.Bottom - rectangle_0.Height - (int)((double)num2 / num);
			}
			int x = textControl_0.ScrollLocation.X;
			if (rectangle2.Left < rectangle.Left || rectangle2.Left > rectangle.Right)
			{
				x = rectangle2.Left;
			}
			textControl_0.ScrollLocation = new Point(x, y);
			Rectangle bounds = Screen.FromControl(textControl_0).Bounds;
			Rectangle rectangle3 = textControl_0.DocumentToClient(rectangle_0);
			Point point = textControl_0.PointToScreen(new Point(0, 0));
			int num3 = rectangle3.Bottom + point.Y + 10;
			if (num3 + size_0.Height > bounds.Bottom)
			{
				num3 = rectangle3.Top + point.Y - size_0.Height - 10;
				if (num3 < 0)
				{
					num3 = rectangle3.Bottom + point.Y - rectangle3.Height / 2;
					if (num3 < 0)
					{
						num3 = 0;
					}
				}
			}
			int num4 = rectangle3.Left + point.X;
			if (num4 < bounds.Left)
			{
				num4 = 0;
			}
			else if (num4 + size_0.Width > bounds.Right)
			{
				num4 = bounds.Right - size_0.Width;
			}
			return new Point(num4, num3);
		}

		internal static void smethod_37(string string_2, IRibbonItem iribbonItem_0, Dictionary<string, object> dictionary_1, IRibbonItem iribbonItem_1)
		{
			RibbonItemCollection parentCollection = iribbonItem_0.ParentCollection;
			int num = 0;
			while (true)
			{
				if (num < parentCollection.Count)
				{
					if (iribbonItem_0 == parentCollection[num])
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			Control item = iribbonItem_0 as Control;
			iribbonItem_0.ParentCollection.Remove(item);
			dictionary_1.Remove(string_2);
			if (!iribbonItem_0.DPI.IsEmpty && iribbonItem_1 is RibbonButton && (iribbonItem_1 as RibbonButton).SmallIcon == null)
			{
				Class517.smethod_52(iribbonItem_1 as Control, iribbonItem_0.DPI);
			}
			parentCollection.Insert(num, iribbonItem_1 as Control);
			dictionary_1.Add(string_2, iribbonItem_1);
		}

		internal static void smethod_38(Sidebar[] sidebar_0, string string_2, object[] object_0)
		{
			Sidebar sidebar = sidebar_0[0];
			Sidebar sidebar2 = sidebar_0[1];
			Sidebar sidebar3 = sidebar_0[2];
			object obj = object_0[0];
			object obj2 = object_0[1];
			object obj3 = object_0[2];
			if ((obj as Control).Name == string_2)
			{
				if (sidebar == sidebar2)
				{
					(obj2 as RibbonToggleButton).Checked = sidebar.IsPinned;
				}
				else if (sidebar == sidebar3)
				{
					(obj3 as RibbonToggleButton).Checked = sidebar.IsPinned;
				}
			}
		}

		internal static void smethod_39(Sidebar sidebar_0, Point point_0, Size size_0, bool bool_0)
		{
			sidebar_0.DialogLocation = point_0;
			sidebar_0.DialogSize = size_0;
		}

		internal static void smethod_40(Sidebar sidebar_0, bool bool_0)
		{
			if (bool_0)
			{
				if (sidebar_0.DialogStyle == Sidebar.SidebarDialogStyle.Sidebar)
				{
					sidebar_0.DialogStyle = Sidebar.SidebarDialogStyle.SidebarSizable;
				}
				else if (sidebar_0.DialogStyle == Sidebar.SidebarDialogStyle.Standard)
				{
					sidebar_0.DialogStyle = Sidebar.SidebarDialogStyle.StandardSizable;
				}
			}
			else if (sidebar_0.DialogStyle == Sidebar.SidebarDialogStyle.SidebarSizable)
			{
				sidebar_0.DialogStyle = Sidebar.SidebarDialogStyle.Sidebar;
			}
			else if (sidebar_0.DialogStyle == Sidebar.SidebarDialogStyle.StandardSizable)
			{
				sidebar_0.DialogStyle = Sidebar.SidebarDialogStyle.Standard;
			}
		}

		internal static Bitmap smethod_41(string string_2, TextControl textControl_0, FormattingStyleCollection[] formattingStyleCollection_0, bool bool_0, Size size_0, out bool bool_1, PointF pointF_1)
		{
			Graphics graphics = Graphics.FromHwnd(textControl_0.Handle);
			float num = pointF_1.Y / graphics.DpiX;
			string @string = Class517.resourceManager_0.GetString("LABEL_StylePreviewText");
			FormattingStyle formattingStyle = null;
			ParagraphStyleCollection paragraphStyleCollection = formattingStyleCollection_0[0] as ParagraphStyleCollection;
			InlineStyleCollection inlineStyleCollection = formattingStyleCollection_0[1] as InlineStyleCollection;
			ParagraphStyleCollection paragraphStyleCollection2 = formattingStyleCollection_0[2] as ParagraphStyleCollection;
			InlineStyleCollection inlineStyleCollection2 = formattingStyleCollection_0[3] as InlineStyleCollection;
			Font font = new Font("Arial", 8f * num);
			Font font2 = new Font(font.FontFamily, font.Size - 1f);
			Padding padding_ = Class517.smethod_51(Class519.Class532.Padding_2, pointF_1);
			bool_1 = false;
			string text = null;
			bool flag = true;
			textControl_0.Selection.Text = @string;
			textControl_0.SelectAll();
			try
			{
				if ((formattingStyle = paragraphStyleCollection.GetItem(string_2)) != null)
				{
					bool_1 = true;
					text = ((formattingStyle.BaseStyle != null) ? formattingStyle.BaseStyle.Name : null);
					paragraphStyleCollection2.Add(new ParagraphStyle(formattingStyle as ParagraphStyle));
				}
				else if ((formattingStyle = inlineStyleCollection.GetItem(string_2)) != null)
				{
					text = ((formattingStyle.BaseStyle != null) ? formattingStyle.BaseStyle.Name : null);
					inlineStyleCollection2.Add(new InlineStyle(formattingStyle as InlineStyle));
				}
			}
			catch
			{
				flag = false;
				textControl_0.ResetContents();
			}
			Bitmap bitmap = null;
			if (formattingStyle == null)
			{
				bitmap = Class517.smethod_43(bool_0, string_2, size_0, num);
			}
			else
			{
				if (flag)
				{
					textControl_0.Selection.FormattingStyle = string_2;
				}
				if (textControl_0.Lines.Count > 1)
				{
					textControl_0.Selection.Start = textControl_0.Lines[2].Start - 1;
					textControl_0.Selection.Length = textControl_0.Text.Length;
					textControl_0.Selection.Text = "";
				}
				string text2 = (bool_1 ? ("¶ " + string_2) : string_2);
				Size size = TextRenderer.MeasureText(text2, font);
				int width = size.Width;
				int num2 = 0;
				int int_ = 0;
				string text3 = null;
				Size size2 = default(Size);
				if (text != null)
				{
					text3 = (bool_0 ? (" (" + text + " " + Class517.resourceManager_0.GetString("LABEL_BASEDON") + ")") : (" (" + Class517.resourceManager_0.GetString("LABEL_BASEDON") + " " + text + ")"));
					size2 = TextRenderer.MeasureText(text3, font2);
					num2 = size2.Width;
					int_ = size.Height / 2 - size2.Height / 2;
				}
				int int_2 = Math.Max(width + num2 + padding_.Horizontal, size_0.Width);
				Line line = textControl_0.Lines[1];
				int left = line.TextBounds.Left;
				int num3 = line.Baseline - 567;
				int num4 = (int)Math.Min(300.0, (double)num3 - textControl_0.PageMargins.Top);
				int_2 = Class517.smethod_42(@string, textControl_0.TextChars, pointF_1, int_2, padding_.Horizontal, out var int_3);
				Rectangle rectangle_ = new Rectangle((int)((float)Class517.smethod_27(graphics.DpiX, left) * num), (int)((float)Class517.smethod_27(graphics.DpiY, num3 - num4) * num), int_3 + 1, num4);
				Bitmap image = textControl_0.GetPages()[1].GetImage((int)(100f * num), Page.PageContent.All);
				bitmap = Class517.smethod_44(bool_0, image, rectangle_, padding_, new Size(int_2, size_0.Height), text2, text3, font, font2, width, size2.Width, int_);
				image.Dispose();
			}
			graphics.Dispose();
			textControl_0.ResetContents();
			return bitmap;
		}

		private static int smethod_42(string string_2, TextCharCollection textCharCollection_0, PointF pointF_1, int int_0, int int_1, out int int_2)
		{
			int_2 = 0;
			if (textCharCollection_0.Count > 0)
			{
				Regex regex = new Regex("\\s+|$");
				MatchCollection matchCollection = regex.Matches(string_2);
				int left = textCharCollection_0[1].Bounds.Left;
				int num = 0;
				{
					foreach (Match item in matchCollection)
					{
						int_2 = Class517.smethod_27(pointF_1.X, textCharCollection_0[item.Index].Bounds.Right - left);
						num = int_2 + int_1;
						if (int_0 < num)
						{
							return num + 1;
						}
					}
					return int_0;
				}
			}
			return int_0;
		}

		private static Bitmap smethod_43(bool bool_0, string string_2, Size size_0, float float_0)
		{
			Font font = new Font("Arial", 12f * float_0);
			Size size = TextRenderer.MeasureText(string_2, font);
			int num = Math.Max(size.Width + 8, size_0.Width);
			Bitmap bitmap = new Bitmap(num, size_0.Height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			Size size2 = TextRenderer.MeasureText(string_2, font);
			int x = (bool_0 ? (num - size2.Width) : 0);
			TextFormatFlags flags = (bool_0 ? (TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft) : TextFormatFlags.NoPrefix);
			TextRenderer.DrawText(graphics, string_2, font, new Point(x, size_0.Height / 2 - size.Height / 2), SystemColors.WindowText, Color.White, flags);
			graphics.Dispose();
			return bitmap;
		}

		private static Bitmap smethod_44(bool bool_0, Bitmap bitmap_14, Rectangle rectangle_0, Padding padding_0, Size size_0, string string_2, string string_3, Font font_0, Font font_1, int int_0, int int_1, int int_2)
		{
			Bitmap bitmap = new Bitmap(size_0.Width, size_0.Height, PixelFormat.Format32bppArgb);
			bitmap.SetResolution(bitmap_14.HorizontalResolution, bitmap_14.VerticalResolution);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, bitmap.Width, bitmap.Height);
			int x = (bool_0 ? (bitmap.Width - rectangle_0.Width - padding_0.Left) : padding_0.Left);
			graphics.DrawImage(bitmap_14, new Rectangle(x, padding_0.Top, rectangle_0.Width, rectangle_0.Height), rectangle_0, GraphicsUnit.Pixel);
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextFormatFlags flags = (bool_0 ? (TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft) : TextFormatFlags.NoPrefix);
			int x2 = (bool_0 ? (bitmap.Width - int_0) : 0);
			TextRenderer.DrawText(graphics, string_2, font_0, new Point(x2, size_0.Height - padding_0.Bottom), SystemColors.InfoText, Color.White, flags);
			if (string_3 != null)
			{
				int x3 = (bool_0 ? (bitmap.Width - int_0 - int_1 + 6) : int_0);
				TextRenderer.DrawText(graphics, string_3, font_1, new Point(x3, size_0.Height - padding_0.Bottom + int_2), SystemColors.InfoText, Color.White, flags);
			}
			graphics.Dispose();
			return bitmap;
		}

		internal static int smethod_45(int int_0, float float_0)
		{
			if (int_0 != int.MaxValue && int_0 != int.MinValue)
			{
				return (int)Math.Round((float)int_0 * (float_0 / 96f));
			}
			return int_0;
		}

		internal static double smethod_46(double double_0, float float_0)
		{
			if (double_0 != double.MaxValue && double_0 != double.MinValue)
			{
				return double_0 * (double)(float_0 / 96f);
			}
			return double_0;
		}

		internal static float smethod_47(float float_0, float float_1)
		{
			if (float_0 != float.MaxValue && float_0 != float.MinValue)
			{
				return float_0 * (float_1 / 96f);
			}
			return float_0;
		}

		internal static Size smethod_48(Size size_0, PointF pointF_1)
		{
			return new Size(Class517.smethod_45(size_0.Width, pointF_1.X), Class517.smethod_45(size_0.Height, pointF_1.Y));
		}

		internal static Point smethod_49(Point point_0, PointF pointF_1)
		{
			return new Point(Class517.smethod_45(point_0.X, pointF_1.X), Class517.smethod_45(point_0.Y, pointF_1.Y));
		}

		internal static Rectangle smethod_50(Rectangle rectangle_0, PointF pointF_1)
		{
			return new Rectangle(Class517.smethod_49(rectangle_0.Location, pointF_1), Class517.smethod_48(rectangle_0.Size, pointF_1));
		}

		internal static Padding smethod_51(Padding padding_0, PointF pointF_1)
		{
			return new Padding(Class517.smethod_45(padding_0.Left, pointF_1.X), Class517.smethod_45(padding_0.Top, pointF_1.Y), Class517.smethod_45(padding_0.Right, pointF_1.X), Class517.smethod_45(padding_0.Bottom, pointF_1.Y));
		}

		internal static void smethod_52(Control control_0, PointF pointF_1)
		{
			Type type = control_0.GetType();
			bool flag;
			string text = (((flag = control_0 is MiniToolbar) || control_0 is RibbonTab) ? type.BaseType.Name : type.Name);
			switch (text)
			{
			case "RibbonListView":
			{
				RibbonListView ribbonListView = control_0 as RibbonListView;
				foreach (Control dropDownItem in ribbonListView.DropDownItems)
				{
					Class517.smethod_52(dropDownItem, pointF_1);
				}
				return;
			}
			case "RibbonGroup":
			case "HorizontalRibbonGroup":
			{
				RibbonGroup ribbonGroup = control_0 as RibbonGroup;
				if (string.IsNullOrEmpty(ribbonGroup.String_0))
				{
					return;
				}
				if (ribbonGroup.DialogBoxLauncher.Visible)
				{
					ribbonGroup.DialogBoxLauncher.ToolStripItemImage = Class517.smethod_53(ribbonGroup.DialogBoxLauncher.String_0, ImageProvider.ImageKind.Small_16x16, pointF_1);
				}
				ribbonGroup.SmallIcon = Class517.smethod_54(ribbonGroup.String_0, pointF_1);
				ribbonGroup.LargeIcon = Class517.smethod_53(ribbonGroup.String_0, ImageProvider.ImageKind.Large_32x32, pointF_1);
				foreach (Control ribbonItem2 in ribbonGroup.RibbonItems)
				{
					Class517.smethod_52(ribbonItem2, pointF_1);
				}
				return;
			}
			case "MiniToolbar":
			case "RibbonTab":
			{
				RibbonGroupCollection ribbonGroupCollection = (flag ? (control_0 as MiniToolbar).RibbonGroups : (control_0 as RibbonTab).RibbonGroups);
				foreach (RibbonGroup item in ribbonGroupCollection)
				{
					Class517.smethod_52(item, pointF_1);
				}
				return;
			}
			}
			IRibbonItem ribbonItem = control_0 as IRibbonItem;
			if (!ribbonItem.HasSmallIcon && !ribbonItem.HasLargeIcon)
			{
				RibbonButton ribbonButton;
				if (ribbonItem is RibbonButton && (ribbonButton = ribbonItem as RibbonButton).Boolean_0)
				{
					switch (control_0.Name)
					{
					case "TXITEM_Bold":
					case "TXITEM_Italic":
					case "TXITEM_Underline":
					{
						ImageProvider.ImageSetting imageSetting = new ImageProvider.ImageSetting();
						imageSetting.CheckCulture = true;
						ImageProvider.ImageSetting imageSetting_ = imageSetting;
						ribbonButton.method_3(Class517.smethod_56(ribbonButton.String_0, ImageProvider.ImageKind.Small_16x16, imageSetting_, pointF_1), pointF_1);
						break;
					}
					}
				}
			}
			else
			{
				switch (text)
				{
				case "RibbonButton":
				case "RibbonToggleButton":
				case "RibbonSplitButton":
				case "RibbonMenuButton":
				{
					RibbonButton ribbonButton2 = ribbonItem as RibbonButton;
					if (string.IsNullOrEmpty(ribbonButton2.String_0))
					{
						break;
					}
					if (ribbonItem.HasSmallIcon)
					{
						ribbonButton2.method_3(Class517.smethod_53(ribbonButton2.String_0, ImageProvider.ImageKind.Small_16x16, pointF_1), pointF_1);
					}
					else
					{
						switch (control_0.Name)
						{
						case "TXITEM_Bold":
						case "TXITEM_Italic":
						case "TXITEM_Underline":
						{
							ImageProvider.ImageSetting imageSetting2 = new ImageProvider.ImageSetting();
							imageSetting2.CheckCulture = true;
							ImageProvider.ImageSetting imageSetting_2 = imageSetting2;
							ribbonButton2.method_3(Class517.smethod_56(ribbonButton2.String_0, ImageProvider.ImageKind.Small_16x16, imageSetting_2, pointF_1), pointF_1);
							break;
						}
						}
					}
					if (ribbonItem.HasLargeIcon)
					{
						ribbonButton2.LargeIcon = Class517.smethod_53(ribbonButton2.String_0, ImageProvider.ImageKind.Large_32x32, pointF_1);
					}
					break;
				}
				case "RibbonLabel":
				{
					RibbonLabel ribbonLabel = ribbonItem as RibbonLabel;
					if (ribbonItem.HasSmallIcon)
					{
						ribbonLabel.SmallIcon = Class517.smethod_53(ribbonLabel.String_0, ImageProvider.ImageKind.Small_16x16, pointF_1);
					}
					break;
				}
				case "RibbonTextBox":
				{
					RibbonTextBox ribbonTextBox = ribbonItem as RibbonTextBox;
					if (!string.IsNullOrEmpty(ribbonTextBox.String_0))
					{
						if (ribbonItem.HasSmallIcon)
						{
							ribbonTextBox.SmallIcon = Class517.smethod_53(ribbonTextBox.String_0, ImageProvider.ImageKind.Small_16x16, pointF_1);
						}
						if (ribbonItem.HasLargeIcon)
						{
							ribbonTextBox.LargeIcon = Class517.smethod_53(ribbonTextBox.String_0, ImageProvider.ImageKind.Large_32x32, pointF_1);
						}
					}
					break;
				}
				}
			}
			if (!(control_0 is RibbonMenuButton))
			{
				return;
			}
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			foreach (Control dropDownItem2 in ribbonMenuButton.DropDownItems)
			{
				Class517.smethod_52(dropDownItem2, pointF_1);
			}
		}

		internal static Bitmap smethod_53(string string_2, ImageProvider.ImageKind imageKind_0, PointF pointF_1)
		{
			return ImageProvider.GetBitmap(string_2, imageKind_0, pointF_1.X);
		}

		internal static Bitmap smethod_54(string string_2, PointF pointF_1)
		{
			return ImageProvider.GetBitmap(string_2, ImageProvider.ImageKind.Small_16x16, pointF_1.X, new ImageProvider.ImageSetting
			{
				DrawGroupMarker = true
			});
		}

		internal static Bitmap smethod_55(string string_2, ImageProvider.ImageKind imageKind_0, Size size_0, PointF pointF_1)
		{
			Bitmap bitmap = ImageProvider.GetBitmap(string_2, imageKind_0, pointF_1.X);
			if (bitmap.Size.Width == size_0.Width && bitmap.Size.Height == size_0.Height)
			{
				return bitmap;
			}
			Bitmap bitmap2 = new Bitmap(size_0.Width, size_0.Height);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImage(bitmap, new Rectangle(0, 0, size_0.Width, size_0.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
			graphics.Dispose();
			bitmap.Dispose();
			return bitmap2;
		}

		internal static Bitmap smethod_56(string string_2, ImageProvider.ImageKind imageKind_0, ImageProvider.ImageSetting imageSetting_0, PointF pointF_1)
		{
			return ImageProvider.GetBitmap(string_2, imageKind_0, pointF_1.X, imageSetting_0);
		}

		internal static void smethod_57(ToolStripItem toolStripItem_0, System.Drawing.Image image_0, PointF pointF_1)
		{
			Size size = Class466.smethod_3((uint)pointF_1.X);
			Bitmap bitmap = new Bitmap(size.Width, size.Height);
			if (image_0 != null)
			{
				if (pointF_1.X == 0f)
				{
					bitmap.Dispose();
					toolStripItem_0.Image = image_0;
					return;
				}
				using Graphics graphics = Graphics.FromImage(bitmap);
				graphics.DrawImage(image_0, new Rectangle(new Point(0, 0), size));
			}
			toolStripItem_0.Image = bitmap;
		}

		internal static bool smethod_58(RibbonTab ribbonTab_0)
		{
			if (ribbonTab_0 != null)
			{
				foreach (RibbonGroup ribbonGroup in ribbonTab_0.RibbonGroups)
				{
					if (ribbonGroup.List_0.Count > 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		internal static void smethod_59(RibbonMenuButton ribbonMenuButton_0, Color? nullable_0, bool bool_0, PointF pointF_1)
		{
			if (bool_0)
			{
				ribbonMenuButton_0.method_4(nullable_0, pointF_1);
			}
			else
			{
				ribbonMenuButton_0.method_5(nullable_0, pointF_1);
			}
		}

		internal static int smethod_60(int int_0, PointF pointF_1)
		{
			float num = 96f;
			if (!pointF_1.IsEmpty)
			{
				num = pointF_1.X;
			}
			return (int)((float)(1440 * int_0) / num);
		}

		internal static int smethod_61(int int_0, PointF pointF_1)
		{
			float num = 96f;
			if (!pointF_1.IsEmpty)
			{
				num = pointF_1.X;
			}
			return (int)((float)int_0 * num / 1440f);
		}
	}
}
