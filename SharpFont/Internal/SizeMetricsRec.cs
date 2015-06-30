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

namespace SharpFont.Internal
{
	[StructLayout(LayoutKind.Sequential)]
	public struct SizeMetricsRec
	{
		public IntPtr x_scale;
		public IntPtr y_scale;
		public IntPtr ascender;
		public IntPtr descender;
		public IntPtr height;
		public IntPtr max_advance;
		
		public ushort x_ppem;
		public ushort y_ppem;

		public static SizeMetricsRec ReadUsingBinaryReader(BinaryReader reader)
		{
			SizeMetricsRec rec = new SizeMetricsRec();
			
			rec.x_scale = new IntPtr(reader.ReadInt64());
			UnityEngine.Debug.LogError("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! just a test: " + rec.x_scale + "       !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			rec.y_scale = new IntPtr(reader.ReadInt64());
			rec.ascender = new IntPtr(reader.ReadInt64());
			rec.descender = new IntPtr(reader.ReadInt64());
			rec.height = new IntPtr(reader.ReadInt64());
			rec.max_advance = new IntPtr(reader.ReadInt64());
			rec.x_ppem = reader.ReadUInt16();
			rec.y_ppem = reader.ReadUInt16();
			return rec;
		}
	}
}
