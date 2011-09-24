//
// WindowsRuntimeBufferExtensionsTests.cs
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
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using Windows.Storage.Streams;

namespace WinRTNET.Tests.Streams
{
	[TestFixture]
	public class WindowsRuntimeBufferExtensionsTests
	{
		[Test]
		public void AsBuffer_Null()
		{
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeBufferExtensions.AsBuffer (null));
			Assert.Throws<ArgumentNullException>(() => WindowsRuntimeBufferExtensions.AsBuffer (null, 0, 0));
		}

		[Test]
		public void AsBuffer()
		{
			byte[] array = new byte[5];
			IBuffer buffer = array.AsBuffer();

			Assert.IsNotNull (buffer);
			Assert.AreEqual (array.Length, buffer.Length);
			Assert.AreEqual (array.Length, buffer.Capacity);
		}

		[Test]
		public void AsBuffer_OffsetLength()
		{
			byte[] array = new byte[5];
			IBuffer buffer = array.AsBuffer (1, 2);
			
			Assert.IsNotNull (buffer);
			Assert.AreEqual ((uint)2, buffer.Length);
			Assert.AreEqual ((uint)2, buffer.Capacity);
		}

		[TestCase (6, 0)]
		[TestCase (6, 1)]
		[TestCase (6, 6)]
		[TestCase (3, 3)]
		public void AsBuffer_OffsetLength_Invalid (int offset, int length)
		{
			byte[] array = new byte[5];
			Assert.Throws<ArgumentOutOfRangeException>(() => array.AsBuffer (offset, length));
		}

		[Test]
		public void AsBuffer_OffsetLengthCapacity()
		{
			byte[] array = new byte[5];
			IBuffer buffer = array.AsBuffer (1, 2, 3);

			Assert.IsNotNull (buffer);
			Assert.AreEqual ((uint)2, buffer.Length);
			Assert.AreEqual ((uint)3, buffer.Capacity);
		}

		[TestCase (6, 0, 0)]
		[TestCase (6, 0, 1)]
		[TestCase (6, 1, 1)]
		[TestCase (6, 6, 6)]
		[TestCase (3, 3, 3)]
		[TestCase (0, 3, 2)]
		[TestCase (4, 1, 1)]
		public void AsBuffer_OffsetLengthCapacity_Invalid (int offset, int length, int capacity)
		{
			byte[] array = new byte[5];
			Assert.Throws<ArgumentOutOfRangeException>(() => array.AsBuffer (offset, length, capacity));
		}

		[Test]
		public void AsStream_Invalid()
		{
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeBufferExtensions.AsStream (null));
			Assert.Throws<InvalidCastException> (() => new FakeBuffer().AsStream());
		}

		[Test]
		public void AsStream()
		{
			byte[] buffer = new byte[5];
			Stream s = buffer.AsBuffer(1, 2, 3).AsStream();

			Assert.IsTrue (s.CanRead);
			Assert.IsTrue (s.CanWrite);
			Assert.AreEqual (0, s.Position);
			Assert.AreEqual (3, s.Length);
		}

		[Test]
		public void CopyTo_ByteToBuffer_Invalid()
		{
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeBufferExtensions.CopyTo (null, new WindowsRuntimeBuffer(new byte[1])));
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeBufferExtensions.CopyTo (new byte[1], null));
			Assert.Throws<InvalidCastException> (() => WindowsRuntimeBufferExtensions.CopyTo (new byte[1], new FakeBuffer()));
			Assert.Throws<ArgumentException> (() => WindowsRuntimeBufferExtensions.CopyTo (new byte[6], new byte[5].AsBuffer()));
		}

		[Test]
		public void CopyTo_ByteToBuffer()
		{
			byte[] source = new byte[] { 1, 2, 3 };
			byte[] destination = new byte[4];

			WindowsRuntimeBufferExtensions.CopyTo (source, destination.AsBuffer());
			Assert.AreEqual (1, destination[0]);
			Assert.AreEqual (2, destination[1]);
			Assert.AreEqual (3, destination[2]);
			Assert.AreEqual (0, destination[3]);
		}

		[Test]
		public void CopyTo_BufferToByte_Invalid()
		{
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeBufferExtensions.CopyTo (null, new byte[1]));
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeBufferExtensions.CopyTo (new byte[1].AsBuffer(), null));
			Assert.Throws<InvalidCastException> (() => WindowsRuntimeBufferExtensions.CopyTo (new FakeBuffer(), new byte[1]));
			Assert.Throws<ArgumentException>(() => WindowsRuntimeBufferExtensions.CopyTo (new byte[6].AsBuffer(), new byte[5]));
		}

		[Test]
		public void CopyTo_BufferToByte()
		{
			byte[] source = new byte[] { 1, 2, 3 };
			byte[] destination = new byte[4];

			WindowsRuntimeBufferExtensions.CopyTo(source.AsBuffer(), destination);
			Assert.AreEqual(1, destination[0]);
			Assert.AreEqual(2, destination[1]);
			Assert.AreEqual(3, destination[2]);
			Assert.AreEqual(0, destination[3]);
		}

		[Test]
		public void CopyTo_BufferToByte_LargerCapacity()
		{
			byte[] source = new byte[] { 1, 2, 3 };
			byte[] destination = new byte[4];

			WindowsRuntimeBufferExtensions.CopyTo(source.AsBuffer(), destination);
			Assert.AreEqual(1, destination[0]);
			Assert.AreEqual(2, destination[1]);
			Assert.AreEqual(3, destination[2]);
			Assert.AreEqual(0, destination[3]);
		}

		private class FakeBuffer
			: IBuffer
		{
			public uint Capacity
			{
				get { return 1; }
			}

			public uint Length
			{
				get;
				set;
			}
		}

	}
}
