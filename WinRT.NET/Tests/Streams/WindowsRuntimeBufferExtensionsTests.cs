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
	}
}
