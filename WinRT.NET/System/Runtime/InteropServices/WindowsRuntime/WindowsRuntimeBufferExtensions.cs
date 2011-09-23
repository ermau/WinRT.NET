//
// WindowsRuntimeBufferExtensions.cs
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
using System.IO;
using Windows.Storage.Streams;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	public static class WindowsRuntimeBufferExtensions
	{
		public static IBuffer AsBuffer (this byte[] source)
		{
			if (source == null)
				throw new ArgumentNullException ("source");

			return new WindowsRuntimeBuffer (source);
		}

		public static IBuffer AsBuffer (this byte[] source, int offset, int length)
		{
			if (source == null)
				throw new ArgumentNullException("source");
			if (length + offset > source.Length || offset >= source.Length)
				throw new ArgumentOutOfRangeException ("offet");

			return new WindowsRuntimeBuffer (source, offset, length);
		}

		public static IBuffer AsBuffer (this byte[] source, int offset, int length, int capacity)
		{
			if (source == null)
				throw new ArgumentNullException("source");
			if (capacity < length + offset || capacity > source.Length)
				throw new ArgumentOutOfRangeException ("capacity");
			if (length + offset > source.Length || offset >= source.Length)
				throw new ArgumentOutOfRangeException ("offet");

			return new WindowsRuntimeBuffer (source, offset, length, capacity);
		}

		public static Stream AsStream (this IBuffer source)
		{
			if (source == null)
				throw new ArgumentNullException ("source");

			WindowsRuntimeBuffer b = (WindowsRuntimeBuffer)source;
			return new MemoryStream (b.Buffer, 0, (int)b.Capacity);
		}
	}
}