using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SharpFont.Internal
{
	class RecReader
	{
		public static T ReadUsingReference<T>(IntPtr reference, T obj, bool print = true) where T : new()
		{
			int size = Marshal.SizeOf(typeof(T));
			byte[] referenceArray = new byte[size];
			Marshal.Copy(reference, referenceArray, 0, size);

			Type classType = typeof(T);
			Console.WriteLine("TYPE: " + classType.Name);
			Console.WriteLine(BitConverter.ToString(referenceArray));

			return ReadUsingData<T>(referenceArray, obj, print);
		}

		public static T ReadUsingData<T>(byte[] data, T obj, bool print = true) where T : new()
		{
			using (BinaryReader reader = new BinaryReader(new MemoryStream(data, false)))
			{
				return ReadUsingBinaryReader<T>(reader, obj, print);
			}
		}

		public static void PrintSomething<T>(T obj1)
		{
			Type classType = typeof(T);
			T rec = obj1;
			UnityEngine.Debug.Log("Print TYPE: " + classType.Name);
			foreach (FieldInfo field in classType.GetFields(BindingFlags.Public | BindingFlags.Instance))
			{
				if (field.FieldType == typeof(BitmapGlyphRec))
					PrintSomething<BitmapGlyphRec>((BitmapGlyphRec) field.GetValue(obj1));
				else if (field.FieldType == typeof(BitmapRec))
					PrintSomething<BitmapRec>((BitmapRec) field.GetValue(obj1));
				else if (field.FieldType == typeof(BitmapSizeRec))
					PrintSomething<BitmapSizeRec>((BitmapSizeRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(CharMapRec))
					PrintSomething<CharMapRec>((CharMapRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(FaceRec))
					PrintSomething<FaceRec>((FaceRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(GenericRec))
					PrintSomething<GenericRec>((GenericRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(GlyphMetricsRec))
					PrintSomething<GlyphMetricsRec>((GlyphMetricsRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(GlyphRec))
					PrintSomething<GlyphRec>((GlyphRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(GlyphSlotRec))
					PrintSomething<GlyphSlotRec>((GlyphSlotRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(GlyphToScriptMapPropertyRec))
					PrintSomething<GlyphToScriptMapPropertyRec>((GlyphToScriptMapPropertyRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(IncreaseXHeightPropertyRec))
					PrintSomething<IncreaseXHeightPropertyRec>((IncreaseXHeightPropertyRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(ListNodeRec))
					PrintSomething<ListNodeRec>((ListNodeRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(ListRec))
					PrintSomething<ListRec>((ListRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(MemoryRec))
					PrintSomething<MemoryRec>((MemoryRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(ModuleClassRec))
					PrintSomething<ModuleClassRec>((ModuleClassRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(OpenArgsRec))
					PrintSomething<OpenArgsRec>((OpenArgsRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(OutlineFuncsRec))
					PrintSomething<OutlineFuncsRec>((OutlineFuncsRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(OutlineGlyphRec))
					PrintSomething<OutlineGlyphRec>((OutlineGlyphRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(OutlineRec))
					PrintSomething<OutlineRec>((OutlineRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(ParameterRec))
					PrintSomething<ParameterRec>((ParameterRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(RasterFuncsRec))
					PrintSomething<RasterFuncsRec>((RasterFuncsRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(RasterParamsRec))
					PrintSomething<RasterParamsRec>((RasterParamsRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(RendererClassRec))
					PrintSomething<RendererClassRec>((RendererClassRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(SizeMetricsRec))
					PrintSomething<SizeMetricsRec>((SizeMetricsRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(SizeRec))
					PrintSomething<SizeRec>((SizeRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(SizeRequestRec))
					PrintSomething<SizeRequestRec>((SizeRequestRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(SpanRec))
					PrintSomething<SpanRec>((SpanRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(StreamDescRec))
					PrintSomething<StreamDescRec>((StreamDescRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(StreamRec))
					PrintSomething<StreamRec>((StreamRec)field.GetValue(obj1));
				else if (field.FieldType == typeof(BBox))
					PrintSomething<BBox>((BBox)field.GetValue(obj1));
				else if (field.FieldType == typeof(PixelMode))
					PrintSomething<PixelMode>((PixelMode)field.GetValue(obj1));
				else if (field.FieldType == typeof(Encoding))
					PrintSomething<Encoding>((Encoding)field.GetValue(obj1));
				else if (field.FieldType == typeof(TrueType.PlatformId))
					PrintSomething<TrueType.PlatformId>((TrueType.PlatformId)field.GetValue(obj1));
				else if (field.FieldType == typeof(FTVector26Dot6))
					PrintSomething<FTVector26Dot6>((FTVector26Dot6)field.GetValue(obj1));
				else if (field.FieldType == typeof(FTVector))
					PrintSomething<FTVector>((FTVector)field.GetValue(obj1));
				else if (field.FieldType == typeof(OpenFlags))
					PrintSomething<OpenFlags>((OpenFlags)field.GetValue(obj1));
				else if (field.FieldType == typeof(OutlineFlags))
					PrintSomething<OutlineFlags>((OutlineFlags)field.GetValue(obj1));
				else if (field.FieldType == typeof(GlyphFormat))
					PrintSomething<GlyphFormat>((GlyphFormat)field.GetValue(obj1));
				else
					UnityEngine.Debug.Log(field.Name + ": " + field.GetValue(obj1));
			}
		}

		public static void PrintSomething<T>(T obj1, T obj2)
		{
			Type classType = typeof(T);
			
			foreach (FieldInfo field in classType.GetFields(BindingFlags.Public | BindingFlags.Instance))
			{
				if (field.GetValue(obj1).ToString() != field.GetValue(obj2).ToString())
				{ 
					UnityEngine.Debug.Log("Print TYPE: " + classType.Name);
					UnityEngine.Debug.Log(field.Name + ": " + field.GetValue(obj1) + " vs. " + field.GetValue(obj2));
				}
			}
		}

		public static T ReadUsingBinaryReader<T>(BinaryReader reader, T obj, bool print = true) where T : new()
		{
			T rec = new T();

			if (reader == null)
				return rec;

			Type classType = typeof(T);
			object box = rec;
			UnityEngine.Debug.Log("RecReader START reading bytes for " + classType.Name);
			foreach (FieldInfo field in classType.GetFields(BindingFlags.Public | BindingFlags.Instance))
			{
				//TODO: Change for 32 bit
				if (field.FieldType == typeof(IntPtr))
					field.SetValue(box, new IntPtr(reader.ReadInt64()));
				else if (field.FieldType == typeof(UIntPtr))
					field.SetValue(box, new UIntPtr(reader.ReadUInt64()));
				else if (field.FieldType == typeof(int))
					field.SetValue(box, (int)reader.ReadInt64());
				else if (field.FieldType == typeof(uint))
					field.SetValue(box, (uint)reader.ReadUInt64());
				else if (field.FieldType == typeof(ushort))
					field.SetValue(box, (ushort)reader.ReadUInt16());
				else if (field.FieldType == typeof(short))
					field.SetValue(box, (short)reader.ReadInt16());
				else if (field.FieldType == typeof(byte))
					field.SetValue(box, reader.ReadByte());
				else if (field.FieldType == typeof(string))
					field.SetValue(box, reader.ReadString());
				else if (field.FieldType == typeof(BitmapGlyphRec))
					field.SetValue(box, ReadUsingBinaryReader<BitmapGlyphRec>(reader, (BitmapGlyphRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(BitmapRec))
					field.SetValue(box, ReadUsingBinaryReader<BitmapRec>(reader, (BitmapRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(BitmapSizeRec))
					field.SetValue(box, ReadUsingBinaryReader<BitmapSizeRec>(reader, (BitmapSizeRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(CharMapRec))
					field.SetValue(box, ReadUsingBinaryReader<CharMapRec>(reader, (CharMapRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(FaceRec))
					field.SetValue(box, ReadUsingBinaryReader<FaceRec>(reader, (FaceRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(GenericRec))
					field.SetValue(box, ReadUsingBinaryReader<GenericRec>(reader, (GenericRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(GlyphMetricsRec))
					field.SetValue(box, ReadUsingBinaryReader<GlyphMetricsRec>(reader, (GlyphMetricsRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(GlyphRec))
					field.SetValue(box, ReadUsingBinaryReader<GlyphRec>(reader, (GlyphRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(GlyphSlotRec))
					field.SetValue(box, ReadUsingBinaryReader<GlyphSlotRec>(reader, (GlyphSlotRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(GlyphToScriptMapPropertyRec))
					field.SetValue(box, ReadUsingBinaryReader<GlyphToScriptMapPropertyRec>(reader, (GlyphToScriptMapPropertyRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(IncreaseXHeightPropertyRec))
					field.SetValue(box, ReadUsingBinaryReader<IncreaseXHeightPropertyRec>(reader, (IncreaseXHeightPropertyRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(ListNodeRec))
					field.SetValue(box, ReadUsingBinaryReader<ListNodeRec>(reader, (ListNodeRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(ListRec))
					field.SetValue(box, ReadUsingBinaryReader<ListRec>(reader, (ListRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(MemoryRec))
					field.SetValue(box, ReadUsingBinaryReader<MemoryRec>(reader, (MemoryRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(ModuleClassRec))
					field.SetValue(box, ReadUsingBinaryReader<ModuleClassRec>(reader, (ModuleClassRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(OpenArgsRec))
					field.SetValue(box, ReadUsingBinaryReader<OpenArgsRec>(reader, (OpenArgsRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(OutlineFuncsRec))
					field.SetValue(box, ReadUsingBinaryReader<OutlineFuncsRec>(reader, (OutlineFuncsRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(OutlineGlyphRec))
					field.SetValue(box, ReadUsingBinaryReader<OutlineGlyphRec>(reader, (OutlineGlyphRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(OutlineRec))
					field.SetValue(box, ReadUsingBinaryReader<OutlineRec>(reader, (OutlineRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(ParameterRec))
					field.SetValue(box, ReadUsingBinaryReader<ParameterRec>(reader, (ParameterRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(RasterFuncsRec))
					field.SetValue(box, ReadUsingBinaryReader<RasterFuncsRec>(reader, (RasterFuncsRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(RasterParamsRec))
					field.SetValue(box, ReadUsingBinaryReader<RasterParamsRec>(reader, (RasterParamsRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(RendererClassRec))
					field.SetValue(box, ReadUsingBinaryReader<RendererClassRec>(reader, (RendererClassRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(SizeMetricsRec))
				{
					UnityEngine.Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
					field.SetValue(box, ReadUsingBinaryReader<SizeMetricsRec>(reader, (SizeMetricsRec)field.GetValue(obj)));
					//field.SetValue(box, SizeMetricsRec.ReadUsingBinaryReader(reader));
				}
				else if (field.FieldType == typeof(SizeRec))
					field.SetValue(box, ReadUsingBinaryReader<SizeRec>(reader, (SizeRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(SizeRequestRec))
					field.SetValue(box, ReadUsingBinaryReader<SizeRequestRec>(reader, (SizeRequestRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(SpanRec))
					field.SetValue(box, ReadUsingBinaryReader<SpanRec>(reader, (SpanRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(StreamDescRec))
					field.SetValue(box, ReadUsingBinaryReader<StreamDescRec>(reader, (StreamDescRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(StreamRec))
					field.SetValue(box, ReadUsingBinaryReader<StreamRec>(reader, (StreamRec)field.GetValue(obj)));
				else if (field.FieldType == typeof(BBox))
					field.SetValue(box, new BBox(reader));
				else if (field.FieldType == typeof(PixelMode))
					field.SetValue(box, (PixelMode)reader.ReadByte());
				else if (field.FieldType == typeof(Encoding))
					field.SetValue(box, (Encoding)reader.ReadUInt64());
				else if (field.FieldType == typeof(TrueType.PlatformId))
					field.SetValue(box, (TrueType.PlatformId)reader.ReadUInt32());
				else if (field.FieldType == typeof(FTVector26Dot6))
					field.SetValue(box, new FTVector26Dot6(reader, (FTVector26Dot6)field.GetValue(obj)));
				else if (field.FieldType == typeof(FTVector))
					field.SetValue(box, new FTVector(reader));
				else if (field.FieldType == typeof(OpenFlags))
					field.SetValue(box, (OpenFlags)reader.ReadByte());
				else if (field.FieldType == typeof(OutlineFlags))
					field.SetValue(box, (OutlineFlags)reader.ReadByte());
				//else if (field.FieldType == typeof(GlyphFormat))
					//field.SetValue(box, reader.ReadUInt32());
				else if (field.FieldType == typeof(AllocFunc) || field.FieldType == typeof(FreeFunc) || field.FieldType == typeof(ReallocFunc) || field.FieldType == typeof(ModuleConstructor) ||
					field.FieldType == typeof(ModuleDestructor) || field.FieldType == typeof(ModuleRequester) || field.FieldType == typeof(RasterNewFunc) || field.FieldType == typeof(RasterResetFunc) ||
					field.FieldType == typeof(RasterSetModeFunc) || field.FieldType == typeof(RasterRenderFunc) || field.FieldType == typeof(RasterDoneFunc) || field.FieldType == typeof(RasterFlags) ||
					field.FieldType == typeof(RasterSpanFunc) || field.FieldType == typeof(RasterBitTestFunc) || field.FieldType == typeof(RasterBitSetFunc) || field.FieldType == typeof(SizeRequestType) ||
					field.FieldType == typeof(StreamDescRec) || field.FieldType == typeof(StreamIOFunc) || field.FieldType == typeof(StreamCloseFunc))
				{
					UnityEngine.Debug.Log("RecReader - setting delegate function: Field " + field.Name + " with type " + field.FieldType);
					field.SetValue(box, Marshal.GetDelegateForFunctionPointer(new IntPtr(reader.ReadInt64()), field.FieldType));
				}
				else
				{
					UnityEngine.Debug.Log("RecReader: Field " + field.Name + " with type " + field.FieldType + " not included!");
				}

				if (obj != null)
				{
					/*UnityEngine.Debug.Log("Read " + field.Name + " with type " + field.FieldType + " from BYTES: " + field.GetValue(box) + " vs. " + field.GetValue(obj));
					if (field.GetValue(box).ToString() != field.GetValue(obj).ToString())
					{
						UnityEngine.Debug.Log("VALUES differ in " + classType.Name + ":" + field.Name);
					}*/
				}
				else
				{
					UnityEngine.Debug.Log("No comparer defined for " +  classType.Name);
				}

				UnityEngine.Debug.Log("Read: " + field.Name + " Type: " + field.FieldType + " Bytes: " + field.GetValue(box));
				
			}
			rec = (T)box;
			UnityEngine.Debug.Log("RecReader STOP reading bytes for " + classType.Name);
			return rec;
		}
	}
}
