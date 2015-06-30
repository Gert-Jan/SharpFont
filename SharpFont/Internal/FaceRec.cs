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

		public IntPtr @internal;

		public static int SizeInBytes { get { return Marshal.SizeOf(typeof(FaceRec)); } }
	}
}
