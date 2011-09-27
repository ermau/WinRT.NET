//
// ThreadPoolTimerTests.cs
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
using Windows.System.Threading;

namespace WinRTNET.Tests.Windows.System.Threading
{
	[TestFixture]
	public class ThreadPoolTimerTests
	{
		[Test]
		public void CreatePeriodicTimer_Null()
		{
			Assert.Throws<ArgumentException> (() => ThreadPoolTimer.CreatePeriodicTimer (null, TimeSpan.FromSeconds (1)));
		}

		[Test]
		public void CreatePeriodicTimer_Period()
		{
			TimeSpan period = TimeSpan.FromSeconds (10);

			ThreadPoolTimer timer = ThreadPoolTimer.CreatePeriodicTimer (t => t.ToString(), period);
			Assert.IsNotNull (timer);
			Assert.AreEqual (period, timer.Period);
		}

		[Test]
		public void CreatePeriodicTimer_Delay()
		{
			TimeSpan period = TimeSpan.FromSeconds(10);

			ThreadPoolTimer timer = ThreadPoolTimer.CreatePeriodicTimer (t => t.ToString(), period);
			Assert.IsNotNull(timer);
			Assert.AreEqual(period, timer.Delay);
		}

		[Test]
		public void CreatePeriodTimer_HandlerCalledRepeatedly()
		{
			int called = 0;
			ThreadPoolTimer.CreatePeriodicTimer (t => called++, TimeSpan.FromMilliseconds (100));

			if (!SpinWait.SpinUntil (() => called >= 10, 1200))
				Assert.Fail ("Did not call handler 10 times in 1.2 seconds");
		}

		[Test]
		public void CreatePeriodTimer_Canceled()
		{
			bool called = false;
			var timer = ThreadPoolTimer.CreatePeriodicTimer (t => called = true, TimeSpan.FromMilliseconds (500));
			timer.Cancel();

			Thread.Sleep (600);
			Assert.IsFalse (called);
		}

		[Test]
		public void CreateTimer_Null()
		{
			Assert.Throws<ArgumentException>(() => ThreadPoolTimer.CreateTimer (null, TimeSpan.FromSeconds(1)));
		}

		[Test]
		public void CreateTimer_Period()
		{
			TimeSpan period = TimeSpan.FromSeconds(10);

			ThreadPoolTimer timer = ThreadPoolTimer.CreateTimer(t => t.ToString(), period);
			Assert.IsNotNull (timer);
			Assert.AreEqual (default(TimeSpan), timer.Period);
		}

		[Test]
		public void CreateTimer_Delay()
		{
			TimeSpan period = TimeSpan.FromSeconds(10);

			ThreadPoolTimer timer = ThreadPoolTimer.CreateTimer (t => t.ToString(), period);
			Assert.IsNotNull (timer);
			Assert.AreEqual (period, timer.Delay);
		}

		[Test]
		public void CreateTimer_HandlerCalled()
		{
			bool called = false;
			ThreadPoolTimer.CreateTimer (t => called = true, TimeSpan.FromMilliseconds(100));

			if (!SpinWait.SpinUntil (() => called, 200))
				Assert.Fail ("Did not call handler in under 200ms");
		}

		[Test]
		public void CreateTimer_Canceled()
		{
			bool called = false;
			var timer = ThreadPoolTimer.CreateTimer (t => called = true, TimeSpan.FromMilliseconds (500));
			timer.Cancel();

			Thread.Sleep (600);
			Assert.IsFalse (called);
		}
	}
}