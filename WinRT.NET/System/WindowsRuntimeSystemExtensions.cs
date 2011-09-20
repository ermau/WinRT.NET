//
// WindowsRuntimeSystemExtensions.cs
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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace System
{
	public static class WindowsRuntimeSystemExtensions
	{
		public static Task StartAsTask (this IAsyncAction source)
		{
			if (source == null)
				throw new ArgumentNullException ("source");
			if (source.Status != AsyncStatus.Created)
				throw new InvalidOperationException("The async operation has been previously started");

			var tcs = new TaskCompletionSource<bool>();

			source.Completed = a =>
			{
				switch (a.Status)
				{
					case AsyncStatus.Completed:
						tcs.SetResult (true);
						break;

					case AsyncStatus.Canceled:
						tcs.SetCanceled();
						break;

					case AsyncStatus.Error:
						tcs.SetException (a.ErrorCode);
						break;
				}

				tcs.SetResult (true);
			};

			source.Start();

			return tcs.Task;
		}
	}
}