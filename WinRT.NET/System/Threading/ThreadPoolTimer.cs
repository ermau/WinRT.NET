//
// ThreadPoolTimer.cs
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
using System.Threading.Tasks;

namespace Windows.System.Threading
{
	public delegate void TimeElapsedHandler (ThreadPoolTimer timer);

	public sealed class ThreadPoolTimer
		: IThreadPoolTimer
	{
		private ThreadPoolTimer (TimeElapsedHandler handler, TimeSpan delay, bool isPeriodic)
		{
			Delay = delay;
			if (isPeriodic)
				Period = delay;

			this.handler = handler;

			this.realTimer = new Timer (t =>
			{
				var ltimer = (ThreadPoolTimer)t;

				if (!ltimer.isCanceled)
				{
					Task.Factory.StartNew (o =>
					{
						ThreadPoolTimer taskedTimer = (ThreadPoolTimer)o;
						taskedTimer.handler (taskedTimer);
					}, ltimer);
				}
			}, this, (int)delay.TotalMilliseconds, (isPeriodic) ? (int)delay.TotalMilliseconds : Timeout.Infinite);
		}

		public TimeSpan Delay
		{
			get;
			private set;
		}

		public TimeSpan Period
		{
			get;
			private set;
		}

		public void Cancel()
		{
			this.isCanceled = true;
			this.realTimer.Dispose();
		}

		private volatile bool isCanceled;
		private readonly TimeElapsedHandler handler;
		private readonly Timer realTimer;

		public static ThreadPoolTimer CreatePeriodicTimer (TimeElapsedHandler handler, TimeSpan period)
		{
			if (handler == null)
				throw new ArgumentException ("handler");

			return new ThreadPoolTimer (handler, period, isPeriodic: true);
		}

		public static ThreadPoolTimer CreateTimer (TimeElapsedHandler handler, TimeSpan delay)
		{
			if (handler == null)
				throw new ArgumentException ("handler");

			return new ThreadPoolTimer (handler, delay, isPeriodic: false);
		}
	}
}