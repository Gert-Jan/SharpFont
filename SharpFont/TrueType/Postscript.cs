﻿#region MIT License
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

using SharpFont.TrueType.Internal;
using SharpFont.Internal;

namespace SharpFont.TrueType
{
	/// <summary>
	/// A structure used to model a TrueType PostScript table. All fields comply to the TrueType specification. This
	/// structure does not reference the PostScript glyph names, which can be nevertheless accessed with the ‘ttpost’
	/// module.
	/// </summary>
	public class Postscript
	{
		#region Fields

		private IntPtr reference;
		private PostscriptRec rec;

		#endregion

		#region Constructors

		internal Postscript(IntPtr reference)
		{
			Reference = reference;
		}

		#endregion

		#region Properties

		public int FormatType
		{
			get
			{
				return (int)rec.FormatType;
			}
		}
		
		public int ItalicAngle
		{
			get
			{
				return (int)rec.italicAngle;
			}
		}
		
		public short UnderlinePosition
		{
			get
			{
				return rec.underlinePosition;
			}
		}
		
		public short UnderlineThickness
		{
			get
			{
				return rec.underlineThickness;
			}
		}

		[CLSCompliant(false)]
		public uint IsFixedPitch
		{
			get
			{
				return (uint)rec.isFixedPitch;
			}
		}

		[CLSCompliant(false)]
		public uint MinimumMemoryType42
		{
			get
			{
				return (uint)rec.minMemType42;
			}
		}

		[CLSCompliant(false)]
		public uint MaximumMemoryType42
		{
			get
			{
				return (uint)rec.maxMemType42;
			}
		}

		[CLSCompliant(false)]
		public uint MinimumMemoryType1
		{
			get
			{
				return (uint)rec.minMemType1;
			}
		}

		[CLSCompliant(false)]
		public uint MaximumMemoryType1
		{
			get
			{
				return (uint)rec.maxMemType1;
			}
		}

		internal IntPtr Reference
		{
			get
			{
				return reference;
			}

			set
			{
				reference = value;
#if AOT
				rec = RecReader.ReadUsingReference<PostscriptRec>(reference, null);
#else
				rec = PInvokeHelper.PtrToStructure<PostscriptRec>(reference);
#endif
			}
		}

		#endregion
	}
}
