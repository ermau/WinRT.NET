﻿//
// WindowsRuntimeBuffer.cs
//
// Author:
//   Eric Maupin <me@ermau.com>
//
// Copyright (c) 2011 Eric Maupin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	public sealed class WindowsRuntimeBuffer
		: IBuffer
	{
		internal WindowsRuntimeBuffer (byte[] buffer)
		{
			this.Buffer = buffer;
			this.length = (uint)buffer.Length;
		}

		internal WindowsRuntimeBuffer (byte[] buffer, int offset, int length)
		{
			byte[] buff = new byte[length];
			Array.Copy (buffer, offset, buff, 0, length);
			this.Buffer = buff;
			this.length = (uint)length;
		}

		internal WindowsRuntimeBuffer (byte[] buffer, int offset, int length, int capacity)
		{
			byte[] buff = new byte[length];
			Array.Copy (buffer, offset, buff, 0, capacity);
			this.Buffer = buff;
			this.length = (uint)length;
		}

		public uint Capacity
		{
			get { return (uint)this.Buffer.Length; }
		}

		public uint Length
		{
			get { return this.length; }
			set
			{
				if (value > this.Buffer.Length)
					throw new ArgumentOutOfRangeException ("value");

				this.length = value;
			}
		}

		private uint length;
		internal readonly byte[] Buffer;
	}
}
