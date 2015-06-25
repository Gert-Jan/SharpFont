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
		public static T ReadUsingReference<T>(IntPtr reference) where T : new()
		{
			byte[] referenceArray = new byte[FaceRec.SizeInBytes];
			Marshal.Copy(reference, referenceArray, 0, FaceRec.SizeInBytes);
			return ReadUsingData<T>(referenceArray);
		}

		public static T ReadUsingData<T>(byte[] data) where T : new()
		{
			using (BinaryReader reader = new BinaryReader(new MemoryStream(data, false)))
			{
				return ReadUsingBinaryReader<T>(reader);
			}
		}

		public static T ReadUsingBinaryReader<T>(BinaryReader reader) where T : new()
		{
			T rec = new T();

			if (reader == null)
				return rec;

			Type classType = typeof(T);
			foreach (FieldInfo field in classType.GetFields(BindingFlags.Public | BindingFlags.Instance))
			{
				//TODO: Change for 32 bit
				if (field.FieldType == typeof(IntPtr))
					field.SetValue(rec, new IntPtr(reader.ReadInt64()));
				else if (field.FieldType == typeof(int))
					field.SetValue(rec, (int)reader.ReadInt64());
				else if (field.FieldType == typeof(uint))
					field.SetValue(rec, (uint)reader.ReadUInt64());
				else if (field.FieldType == typeof(ushort))
					field.SetValue(rec, (ushort)reader.ReadUInt32());
				else if (field.FieldType == typeof(short))
					field.SetValue(rec, (short)reader.ReadInt32());
				else if (field.FieldType == typeof(BitmapGlyphRec))
					field.SetValue(rec, ReadUsingBinaryReader<BitmapGlyphRec>(reader));
				else if (field.FieldType == typeof(BitmapRec))
					field.SetValue(rec, ReadUsingBinaryReader<BitmapRec>(reader));
				else if (field.FieldType == typeof(BitmapSizeRec))
					field.SetValue(rec, ReadUsingBinaryReader<BitmapSizeRec>(reader));
				else if (field.FieldType == typeof(CharMapRec))
					field.SetValue(rec, ReadUsingBinaryReader<CharMapRec>(reader));
				else if (field.FieldType == typeof(FaceRec))
					field.SetValue(rec, ReadUsingBinaryReader<FaceRec>(reader));
				else if (field.FieldType == typeof(GenericRec))
					field.SetValue(rec, ReadUsingBinaryReader<GenericRec>(reader));
				else if (field.FieldType == typeof(GlyphMetricsRec))
					field.SetValue(rec, ReadUsingBinaryReader<GlyphMetricsRec>(reader));
				else if (field.FieldType == typeof(GlyphRec))
					field.SetValue(rec, ReadUsingBinaryReader<GlyphRec>(reader));
				else if (field.FieldType == typeof(GlyphSlotRec))
					field.SetValue(rec, ReadUsingBinaryReader<GlyphSlotRec>(reader));
				else if (field.FieldType == typeof(GlyphToScriptMapPropertyRec))
					field.SetValue(rec, ReadUsingBinaryReader<GlyphToScriptMapPropertyRec>(reader));
				else if (field.FieldType == typeof(IncreaseXHeightPropertyRec))
					field.SetValue(rec, ReadUsingBinaryReader<IncreaseXHeightPropertyRec>(reader));
				else if (field.FieldType == typeof(ListNodeRec))
					field.SetValue(rec, ReadUsingBinaryReader<ListNodeRec>(reader));
				else if (field.FieldType == typeof(ListRec))
					field.SetValue(rec, ReadUsingBinaryReader<ListRec>(reader));
				else if (field.FieldType == typeof(MemoryRec))
					field.SetValue(rec, ReadUsingBinaryReader<MemoryRec>(reader));
				else if (field.FieldType == typeof(ModuleClassRec))
					field.SetValue(rec, ReadUsingBinaryReader<ModuleClassRec>(reader));
				else if (field.FieldType == typeof(OpenArgsRec))
					field.SetValue(rec, ReadUsingBinaryReader<OpenArgsRec>(reader));
				else if (field.FieldType == typeof(OutlineFuncsRec))
					field.SetValue(rec, ReadUsingBinaryReader<OutlineFuncsRec>(reader));
				else if (field.FieldType == typeof(OutlineGlyphRec))
					field.SetValue(rec, ReadUsingBinaryReader<OutlineGlyphRec>(reader));
				else if (field.FieldType == typeof(OutlineRec))
					field.SetValue(rec, ReadUsingBinaryReader<OutlineRec>(reader));
				else if (field.FieldType == typeof(ParameterRec))
					field.SetValue(rec, ReadUsingBinaryReader<ParameterRec>(reader));
				else if (field.FieldType == typeof(RasterFuncsRec))
					field.SetValue(rec, ReadUsingBinaryReader<RasterFuncsRec>(reader));
				else if (field.FieldType == typeof(RasterParamsRec))
					field.SetValue(rec, ReadUsingBinaryReader<RasterParamsRec>(reader));
				else if (field.FieldType == typeof(RendererClassRec))
					field.SetValue(rec, ReadUsingBinaryReader<RendererClassRec>(reader));
				else if (field.FieldType == typeof(SizeMetricsRec))
					field.SetValue(rec, ReadUsingBinaryReader<SizeMetricsRec>(reader));
				else if (field.FieldType == typeof(SizeRec))
					field.SetValue(rec, ReadUsingBinaryReader<SizeRec>(reader));
				else if (field.FieldType == typeof(SizeRequestRec))
					field.SetValue(rec, ReadUsingBinaryReader<SizeRequestRec>(reader));
				else if (field.FieldType == typeof(SpanRec))
					field.SetValue(rec, ReadUsingBinaryReader<SpanRec>(reader));
				else if (field.FieldType == typeof(StreamDescRec))
					field.SetValue(rec, ReadUsingBinaryReader<StreamDescRec>(reader));
				else if (field.FieldType == typeof(StreamRec))
					field.SetValue(rec, ReadUsingBinaryReader<StreamRec>(reader));
				else if (field.FieldType == typeof(BBox))
					field.SetValue(rec, BBox.ReadUsingBinaryReader(reader));

			}
			Console.WriteLine("ReadUsingBinaryReader 2" );
			return rec;
		}
	}
}
