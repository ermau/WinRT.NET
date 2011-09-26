//
// WindowsRuntimeStreamExtensions.cs
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

using Windows.Storage.Streams;
namespace System.IO
{
	public static class WindowsRuntimeStreamExtensions
	{
		public static IInputStream AsInputStream (this Stream source)
		{
			throw new NotImplementedException();
		}

		public static IOutputStream AsOutputStream (this Stream source)
		{
			throw new NotImplementedException();
		}

		public static Stream AsStream (this IInputStream source)
		{
			throw new NotImplementedException();
		}

		public static Stream AsStream (this IOutputStream source)
		{
			throw new NotImplementedException();
		}

		public static Stream OpenRead (this IRandomAccessStream streamProvider)
		{
			throw new NotImplementedException();
		}

		public static Stream OpenRead (this IRandomAccessStream source, long offset)
		{
			throw new NotImplementedException();
		}
		
		public static Stream OpenWrite (this IRandomAccessStream source)
		{
			throw new NotImplementedException();
		}

		public static Stream OpenWrite (this IRandomAccessStream source, long offset)
		{
			throw new NotImplementedException();
		}
	}
}