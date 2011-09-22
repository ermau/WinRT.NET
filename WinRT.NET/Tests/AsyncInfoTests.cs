//
// IAsyncInfo.cs
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
using NUnit.Framework;
using Windows.Foundation;

namespace WinRTNET.Tests
{
	[TestFixture]
	public class AsyncInfoTests
	{
		[Test]
		public void GetNextInfoId()
		{
			uint id = AsyncInfo.GetNextInfoId();
			Assert.Greater (AsyncInfo.GetNextInfoId(), id);
		}

		//[Test] Takes far too long to prove
		public void GetNextInfoId_Max()
		{
			uint lastId = AsyncInfo.GetNextInfoId();
			ulong count = UInt32.MaxValue - lastId;
			for (ulong i = 0; i < count; ++i)
			{
				uint next = AsyncInfo.GetNextInfoId();
				Assert.Greater (next, lastId);
				lastId = next;
			}

			Assert.AreEqual (1, AsyncInfo.GetNextInfoId());
		}
	}
}