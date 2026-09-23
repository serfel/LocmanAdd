using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ns20;

namespace TXTextControl.DataVisualization
{
	internal abstract class ControlList : Dictionary<int, ControlProxy>
	{
		private const int ControlDataVersion = 100;

		private const int ControlDataHeaderSize = 16;

		internal TextControlCore m_tx;

		private int m_iObjID;

		private MemoryStream m_ControlData;

		internal ControlList(TextControlCore textControlCore_0)
		{
			this.m_tx = textControlCore_0;
		}

		internal abstract ControlProxy CreateControlProxy(object control);

		internal bool IsControlHandle(IntPtr handle)
		{
			foreach (KeyValuePair<int, ControlProxy> item in this)
			{
				if (item.Value.Handle == handle)
				{
					return true;
				}
			}
			return false;
		}

		internal IntPtr CreateControl(int iObjID)
		{
			ControlProxy controlProxy = null;
			IntPtr result = IntPtr.Zero;
			try
			{
				controlProxy = this.CreateControlProxy(null);
				controlProxy.CreateControl();
				controlProxy.Visible = false;
				base.Add(iObjID, controlProxy);
				result = controlProxy.Handle;
				return result;
			}
			catch
			{
				if (controlProxy != null)
				{
					controlProxy.Dispose();
					return result;
				}
				return result;
			}
		}

		internal IntPtr GetControlDataSize(int iObjID)
		{
			int value = 0;
			try
			{
				this.EnsureControlData(iObjID);
				value = (int)this.m_ControlData.Length;
			}
			catch
			{
			}
			return new IntPtr(value);
		}

		internal IntPtr GetControlData(int iObjID, IntPtr pBuffer)
		{
			long value = 0L;
			try
			{
				this.EnsureControlData(iObjID);
				Marshal.Copy(this.m_ControlData.GetBuffer(), 0, pBuffer, (int)this.m_ControlData.Length);
				value = pBuffer.ToInt64() + this.m_ControlData.Length;
				this.m_iObjID = 0;
				this.m_ControlData.Close();
				this.m_ControlData = null;
			}
			catch
			{
			}
			return new IntPtr(value);
		}

		internal IntPtr PasteControlData(int iObjID, IntPtr pBuffer)
		{
			int num = 0;
			long value = 0L;
			try
			{
				byte[] array = new byte[16];
				Marshal.Copy(pBuffer, array, 0, 16);
				MemoryStream input = new MemoryStream(array);
				BinaryReader binaryReader = new BinaryReader(input);
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				num = binaryReader.ReadInt32();
				binaryReader.Close();
				array = new byte[num];
				IntPtr source = new IntPtr(pBuffer.ToInt64() + 16L);
				Marshal.Copy(source, array, 0, num);
				input = new MemoryStream(array);
				base[iObjID].Load(input);
				input.Close();
				value = pBuffer.ToInt64() + 16L + num;
			}
			catch
			{
			}
			return new IntPtr(value);
		}

		internal IntPtr PrintControl(int iObjID, IntPtr hdc, Rectangle rBounds, bool bActivated)
		{
			Graphics graphics = null;
			IntPtr result = IntPtr.Zero;
			try
			{
				graphics = Graphics.FromHdc(hdc);
				graphics.PageUnit = GraphicsUnit.Point;
				graphics.PageScale = 0.05f;
				Point[] array = new Point[2]
				{
					new Point(rBounds.X, rBounds.Y),
					new Point(rBounds.X + rBounds.Width, rBounds.Y + rBounds.Height)
				};
				graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, array);
				Rectangle rectangle = new Rectangle(array[0].X, array[0].Y, array[1].X - array[0].X, array[1].Y - array[0].Y);
				if (bActivated && base[iObjID] is Control10)
				{
					((Control10)base[iObjID]).PrintPaint(graphics, rectangle, bool_0: true);
				}
				else
				{
					base[iObjID].PrintPaint(graphics, rectangle);
				}
				result = new IntPtr(1);
				return result;
			}
			catch
			{
				return result;
			}
			finally
			{
				graphics?.Dispose();
			}
		}

		internal IntPtr DrawControlBitmapToMetafile(int iObjID, IntPtr hdcMeta, Rectangle rBounds)
		{
			Graphics graphics = null;
			Graphics graphics2 = null;
			IntPtr result = IntPtr.Zero;
			try
			{
				Bitmap bitmap = new Bitmap(rBounds.Width, rBounds.Height);
				Rectangle position = new Rectangle(0, 0, rBounds.Width, rBounds.Height);
				bitmap.SetResolution(1440f, 1440f);
				graphics2 = Graphics.FromImage(bitmap);
				graphics2.PageUnit = GraphicsUnit.Pixel;
				graphics2.PageScale = 1f;
				base[iObjID].PrintPaint(graphics2, position);
				graphics = Graphics.FromHdc(hdcMeta);
				graphics.PageUnit = GraphicsUnit.Pixel;
				graphics.PageScale = 1f;
				graphics.DrawImage(bitmap, rBounds);
				result = new IntPtr(1);
				return result;
			}
			catch
			{
				return result;
			}
			finally
			{
				graphics2?.Dispose();
				graphics?.Dispose();
			}
		}

		internal IntPtr DrawControlToMetafile(int iObjID, IntPtr hdcMeta, Rectangle rBounds)
		{
			Graphics graphics = null;
			Graphics graphics2 = null;
			IntPtr result = IntPtr.Zero;
			try
			{
				ControlProxy controlProxy = base[iObjID];
				Metafile image = new Metafile(new MemoryStream(), hdcMeta);
				graphics2 = Graphics.FromImage(image);
				Rectangle position = new Rectangle(0, 0, controlProxy.Width, controlProxy.Height);
				controlProxy.PrintPaint(graphics2, position);
				graphics2.Dispose();
				graphics2 = null;
				graphics = Graphics.FromHdc(hdcMeta);
				graphics.PageUnit = GraphicsUnit.Pixel;
				graphics.PageScale = 1f;
				graphics.DrawImage(image, rBounds);
				result = new IntPtr(1);
				return result;
			}
			catch
			{
				return result;
			}
			finally
			{
				graphics2?.Dispose();
				graphics?.Dispose();
			}
		}

		private MemoryStream CreateControlData(ControlProxy control)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			int num = 0;
			binaryWriter.Write(100);
			binaryWriter.Write(16);
			binaryWriter.Write(0);
			binaryWriter.Write(0);
			control.Save(memoryStream);
			num = (int)memoryStream.Length - 16;
			memoryStream.Seek(8L, SeekOrigin.Begin);
			binaryWriter.Write(num);
			return memoryStream;
		}

		private void EnsureControlData(int iObjID)
		{
			if (this.m_iObjID != iObjID || this.m_ControlData == null)
			{
				this.m_iObjID = 0;
				if (this.m_ControlData != null)
				{
					this.m_ControlData.Close();
					this.m_ControlData = null;
				}
				this.m_ControlData = this.CreateControlData(base[iObjID]);
				this.m_iObjID = iObjID;
			}
		}

		internal IntPtr GetControlImageData(int iObjID, int iFilterIndex)
		{
			IntPtr intPtr = IntPtr.Zero;
			ImageFormat format = iFilterIndex switch
			{
				2 => ImageFormat.Tiff, 
				3 => ImageFormat.Wmf, 
				4 => ImageFormat.Png, 
				5 => ImageFormat.Jpeg, 
				6 => ImageFormat.Gif, 
				7 => ImageFormat.Emf, 
				_ => ImageFormat.Bmp, 
			};
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				base[iObjID].SaveImage(memoryStream, format);
				intPtr = Marshal.AllocHGlobal((int)memoryStream.Length);
				Marshal.Copy(memoryStream.GetBuffer(), 0, intPtr, (int)memoryStream.Length);
				return intPtr;
			}
			catch
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
				return IntPtr.Zero;
			}
		}

		internal bool RemoveControl(int iObjID)
		{
			bool result = false;
			try
			{
				if (this.m_iObjID == iObjID && this.m_ControlData != null)
				{
					this.m_iObjID = 0;
					this.m_ControlData = null;
				}
				base[iObjID].Dispose();
				result = base.Remove(iObjID);
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
