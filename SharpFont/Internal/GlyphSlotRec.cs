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

namespace SharpFont.Internal
{
	/// <summary>
	/// Internally represents a GlyphSlot.
	/// </summary>
	/// <remarks>
	/// Refer to <see cref="GlyphSlot"/> for FreeType documentation.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	public class GlyphSlotRec
	{
		public IntPtr library;
		public IntPtr face;
		public IntPtr next;
		public uint reserved;
		public GenericRec generic;

		public GlyphMetricsRec metrics;
		public FT_Long linearHoriAdvance;
		public FT_Long linearVertAdvance;
		public FTVector26Dot6 advance;

		public GlyphFormat format;

		public BitmapRec bitmap;
		public int bitmap_left;
		public int bitmap_top;

		public OutlineRec outline;

		public uint num_subglyphs;
		public IntPtr subglyphs;

		public IntPtr control_data;
		public FT_Long control_len;

		public FT_Long lsb_delta;
		public FT_Long rsb_delta;

		public IntPtr other;

		public IntPtr @public;
	}
}
