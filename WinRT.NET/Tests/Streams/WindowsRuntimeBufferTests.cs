//
// WindowsRuntimeBufferTests.cs
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
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;

namespace WinRTNET.Tests.Streams
{
	[TestFixture]
	public class WindowsRuntimeBufferTests
	{
		[Test]
		public void Capacity()
		{
			byte[] array = new byte[5];
			var buffer = new WindowsRuntimeBuffer (array);

			Assert.AreEqual (array.Length, buffer.Capacity);
		}

		[Test]
		public void Capacity_CtorSet()
		{
			byte[] array = new byte[5];
			var buffer = new WindowsRuntimeBuffer (array, 0, 2, 4);

			Assert.AreEqual (4, buffer.Capacity);
		}

		[Test]
		public void Length()
		{
			byte[] array = new byte[5];
			var buffer = new WindowsRuntimeBuffer (array);

			Assert.AreEqual (5, buffer.Length);
		}

		[Test]
		public void Length_CtorSet()
		{
			byte[] array = new byte[5];
			var buffer = new WindowsRuntimeBuffer (array, 0, 3);

			Assert.AreSame (3, buffer.Length);
		}

		[Test]
		public void Length_Get()
		{
			byte[] array = new byte[5];
			var buffer = new WindowsRuntimeBuffer (array);

			Assert.AreEqual (array.Length, buffer.Length);
		}

		[Test]
		public void Length_Set()
		{
			byte[] array = new byte[5];
			var buffer = new WindowsRuntimeBuffer (array);

			buffer.Length = 4;
			Assert.AreEqual (4, buffer.Length);
		}

		[Test]
		public void Length_OutOfRange()
		{
			byte[] array = new byte[5];
			var buffer = new WindowsRuntimeBuffer (array);

			Assert.Throws<ArgumentOutOfRangeException> (() => buffer.Length = 6);
		}

		[Test]
		public void Capacity_SameAsLength_BiggerSourceArray()
		{
			byte[] array = new byte[6];
			var buffer = new WindowsRuntimeBuffer (array, 0, 4);
			
			Assert.AreEqual (4, buffer.Capacity);
		}

		[Test]
		public void Resize_Length_SameBuffer()
		{
			byte[] array = new byte[6];
			var buffer = new WindowsRuntimeBuffer (array, 0, 1);

			Assert.AreSame (array, buffer.Buffer);
		}

		[Test]
		public void Resize_Capacity_SameBuffer()
		{
			byte[] array = new byte[6];
			var buffer = new WindowsRuntimeBuffer (array, 0, 1, 5);

			Assert.AreSame (array, buffer.Buffer);
		}
	}
}