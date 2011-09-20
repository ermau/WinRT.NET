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
		public void IAsyncAction_StartAsTask_Canceled()
		{
			var action = new MockAsyncAction();
			Task t = action.StartAsTask();

			action.Cancel();

			Assert.Throws<AggregateException> (() => t.Wait());
			Assert.AreEqual (TaskStatus.Canceled, t.Status);
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