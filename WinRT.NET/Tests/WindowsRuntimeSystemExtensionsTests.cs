//
// WindowsRuntimeSystemExtensionsTests.cs
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
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Windows.Foundation;

namespace WinRTNET.Tests
{
	[TestFixture]
	public class WindowsRuntimeSystemExtensionsTests
	{
		[Test]
		public void IAsyncAction_StartAsTask_Null()
		{
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeSystemExtensions.StartAsTask (null));
		}

		[Test]
		public void IAsyncAction_StartAsTask_CreatedOnly()
		{
			var action = new MockAsyncAction();

			action.Status = AsyncStatus.Error;
			Assert.Throws<InvalidOperationException>(() => WindowsRuntimeSystemExtensions.StartAsTask(action));

			action.Status = AsyncStatus.Started;
			Assert.Throws<InvalidOperationException>(() => WindowsRuntimeSystemExtensions.StartAsTask(action));

			action.Status = AsyncStatus.Completed;
			Assert.Throws<InvalidOperationException>(() => WindowsRuntimeSystemExtensions.StartAsTask(action));

			action.Status = AsyncStatus.Canceled;
			Assert.Throws<InvalidOperationException>(() => WindowsRuntimeSystemExtensions.StartAsTask(action));
		}

		[Test]
		public void IAsyncAction_StartAsTask_StartStatus()
		{
			var action = new MockAsyncAction();
			Task t = action.StartAsTask();

			Assert.AreEqual (TaskStatus.WaitingForActivation, t.Status);
			Assert.AreEqual (AsyncStatus.Started, action.Status);
		}

		[Test]
		public void IAsyncAction_StartAsTask_Canceled()
		{
			var action = new MockAsyncAction();
			Task t = action.StartAsTask();

			action.Cancel();

			Assert.Throws<AggregateException> (() => t.Wait());
			Assert.AreEqual (TaskStatus.Canceled, t.Status);
		}

		[Test]
		public void IAsyncAction_StartAstask_Completed()
		{
			var action = new MockAsyncAction();
			Task t = action.StartAsTask();

			action.Status = AsyncStatus.Completed;
			action.Completed (action);

			Assert.AreEqual (TaskStatus.RanToCompletion, t.Status);
		}

		[Test]
		public void IAsyncAction_StartAsTask_Error()
		{
			var error = new Exception ("error");
			var action = new MockAsyncAction();
			Task t = action.StartAsTask();

			action.ErrorCode = error;
			action.Status = AsyncStatus.Error;
			action.Completed (action);

			Assert.IsTrue (t.IsFaulted);
			Assert.AreSame (error, t.Exception.InnerExceptions.First());
			Assert.Throws<AggregateException> (() => t.Wait());
		}

		private class MockAsyncAction
			: IAsyncAction
		{
			public AsyncActionCompletedHandler Completed
			{
				get;
				set;
			}

			public void GetResults()
			{
			}

			public uint Id
			{
				get;
				set;
			}

			public Exception ErrorCode
			{
				get;
				set;
			}

			public AsyncStatus Status
			{
				get;
				set;
			}

			public void Start()
			{
				Status = AsyncStatus.Started;
			}

			public void Close()
			{
			}

			public void Cancel()
			{
				Status = AsyncStatus.Canceled;
				Completed (this);
			}
		}
	}
}