//
// ThreadPoolTests.cs
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
using System.Threading;
using NUnit.Framework;
using Windows.Foundation;
using Windows.System.Threading;
using ThreadPool = Windows.System.Threading.ThreadPool;

namespace WinRTNET.Tests.Windows.System.Threading
{
	[TestFixture]
	public class ThreadPoolTests
	{
		[Test]
		public void RunAsync_InvalidArgs()
		{
			Assert.Throws<ArgumentException> (() => ThreadPool.RunAsync (null));
		}

		[Test]
		public void RunAsync_Completed()
		{
			bool handlerCompleted = false, actionCompleted = false;

			IAsyncAction action = null;
			action = ThreadPool.RunAsync(a =>
			{
				Assert.AreEqual (AsyncStatus.Started, a.Status);
				handlerCompleted = true;
			});

			action.Completed = a =>
			{
				Assert.AreEqual (AsyncStatus.Completed, a.Status);
				actionCompleted = true;
			};

			action.Start();
			Assert.IsTrue (SpinWait.SpinUntil (() => handlerCompleted && actionCompleted, millisecondsTimeout: 5000));
			Assert.AreEqual (AsyncStatus.Completed, action.Status);
			Assert.IsNull (action.ErrorCode);
		}

		[Test]
		public void RunAsync_Cancel()
		{
			bool handlerCompleted = false, actionCompleted = false;

			IAsyncAction action = null;
			action = ThreadPool.RunAsync (a =>
			{
				Assert.AreEqual (AsyncStatus.Started, a.Status);
				handlerCompleted = true;
				Thread.Sleep (2000);
			});

			action.Completed = a =>
			{
				Assert.AreEqual (AsyncStatus.Canceled, a.Status);
				actionCompleted = true;
			};

			action.Start();

			Assert.IsTrue (SpinWait.SpinUntil(() => handlerCompleted, 1000));
			action.Cancel();

			Assert.IsTrue (SpinWait.SpinUntil(() => handlerCompleted && actionCompleted, millisecondsTimeout: 4000));
			Assert.AreEqual (AsyncStatus.Canceled, action.Status);
			Assert.IsNull (action.ErrorCode);
		}

		[Test]
		public void RunAsync_Error()
		{
			bool handlerCompleted = false, actionCompleted = false;

			IAsyncAction action = null;
			action = ThreadPool.RunAsync(a =>
			{
				throw new Exception ("error");
			});

			action.Completed = a =>
			{
				// WinRT ignores errors in thread pool actions
				Assert.AreEqual (AsyncStatus.Completed, a.Status);
				Assert.IsNull (a.ErrorCode);
				actionCompleted = true;
			};

			action.Start();
			Assert.IsTrue (!SpinWait.SpinUntil(() => handlerCompleted && actionCompleted, millisecondsTimeout: 5000));
			Assert.AreEqual (AsyncStatus.Completed, action.Status);
			Assert.IsNull (action.ErrorCode);
		}
	}
}