#region MIT License
/*Copyright (c) 2012-2013 Robert Rouhani <robert.rouhani@gmail.com>

SharpFont based on Tao.FreeType, Copyright (c) 2003-2007 Tao Framework Team

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;
using System.Runtime.InteropServices;

using FT_Long = System.IntPtr;
using FT_ULong = System.UIntPtr;
using System.IO;
using System.Reflection;

namespace SharpFont.Internal
{
	/// <summary>
	/// Internally represents a Face.
	/// </summary>
	/// <remarks>
	/// Refer to <see cref="Face"/> for FreeType documentation.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	public class FaceRec
	{
		public FT_Long num_faces;
		public FT_Long face_index;

		public FT_Long face_flags;
		public FT_Long style_flags;

		public FT_Long num_glyphs;

		public IntPtr family_name;
		public IntPtr style_name;

		public int num_fixed_sizes;
		public IntPtr available_sizes;

		public int num_charmaps;
		public IntPtr charmaps;

		public GenericRec generic;

		public BBox bbox;

		public ushort units_per_EM;
		public short ascender;
		public short descender;
		public short height;

		public short max_advance_width;
		public short max_advance_height;

		public short underline_position;
		public short underline_thickness;

		public IntPtr glyph;
		public IntPtr size;
		public IntPtr charmap;

		public IntPtr driver;
		public IntPtr memory;
		public IntPtr stream;

		public IntPtr sizes_list;
		public GenericRec autohint;
		public IntPtr extensions;

		public IntPtr @public;

		public static int SizeInBytes { get { return Marshal.SizeOf(typeof(FaceRec)); } }

		/*public static FaceRec ReadUsingBinaryReader(byte[] data)
		{
			FaceRec rec = new FaceRec();
			using (BinaryReader reader = new BinaryReader(new MemoryStream(data, false)))
			{
				rec.num_faces = new IntPtr(reader.ReadUInt32());
				rec.face_index = new IntPtr(reader.ReadUInt32());
				rec.face_flags = new IntPtr(reader.ReadUInt32());
				rec.style_flags = new IntPtr(reader.ReadUInt32());
				rec.num_glyphs = new IntPtr(reader.ReadUInt32());
				rec.family_name = new IntPtr(reader.ReadUInt32());
				rec.style_name = new IntPtr(reader.ReadUInt32());
				rec.num_fixed_sizes = reader.ReadInt32();
				rec.available_sizes = new IntPtr(reader.ReadUInt32());
				rec.num_charmaps = reader.ReadInt32();
				rec.charmaps = new IntPtr(reader.ReadUInt32());
				rec.generic = GenericRec.ReadUsingBinaryReader(reader);
				rec.bbox = BBox.ReadUsingBinaryReader(reader);
				rec.units_per_EM = reader.ReadUInt16();
				rec.ascender = reader.ReadInt16();
				rec.descender = reader.ReadInt16();
				rec.height = reader.ReadInt16();
				rec.max_advance_width = reader.ReadInt16();
				rec.max_advance_height = reader.ReadInt16();
				rec.underline_position = reader.ReadInt16();
				rec.underline_thickness = reader.ReadInt16();
				rec.glyph = new IntPtr(reader.ReadUInt32());
				rec.size = new IntPtr(reader.ReadUInt32());
				rec.charmap = new IntPtr(reader.ReadUInt32());
				rec.driver = new IntPtr(reader.ReadUInt32());
				rec.memory = new IntPtr(reader.ReadUInt32());
				rec.stream = new IntPtr(reader.ReadUInt32());
				rec.sizes_list = new IntPtr(reader.ReadUInt32());
				rec.autohint = GenericRec.ReadUsingBinaryReader(reader);
				rec.extensions = new IntPtr(reader.ReadUInt32());
				rec.@public = new IntPtr(reader.ReadUInt32());   
				
				Type classType = typeof(FaceRec);
				foreach (FieldInfo field in classType.GetFields(BindingFlags.Public | BindingFlags.Instance))
				{
					if (field.FieldType == typeof(IntPtr))
					{
						field.SetValue(rec, reader.ReadUInt32());
					}
					else if (field.FieldType == typeof(int))
					{
						field.SetValue(rec, reader.ReadInt32());
					}
					else if (field.FieldType == typeof(ushort))
					{
						field.SetValue(rec, reader.ReadUInt16());
					}
					else if (field.FieldType == typeof(short))
					{
						field.SetValue(rec, reader.ReadInt16());
					}
					else if (field.FieldType == typeof(BBox))
					{
						field.SetValue(rec, BBox.ReadUsingBinaryReader(reader));
					}
					else if (field.FieldType == typeof(GenericRec))
					{
						field.SetValue(rec, GenericRec.ReadUsingBinaryReader(reader));
					}
				}
			}
			return rec;
		}*/
	}
}
