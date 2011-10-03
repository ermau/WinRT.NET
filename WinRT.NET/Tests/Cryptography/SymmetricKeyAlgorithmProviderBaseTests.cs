//
// SymmetricKeyAlgorithmProviderBaseTests.cs
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
using System.Runtime.InteropServices;
using NUnit.Framework;
using Windows.Security.Cryptography.Core;
using WinRTNET.Tests.Streams;

namespace WinRTNET.Tests.Cryptography
{
	public abstract class SymmetricKeyAlgorithmProviderBaseTests
	{
		public abstract string Name
		{
			get;
		}

		public abstract CryptographicPadding Padding
		{
			get;
		}

		[Test]
		public void Open()
		{
			SymmetricKeyAlgorithmProvider provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm (Name);
			Assert.IsNotNull (provider);
			Assert.Greater (provider.BlockLength, 0);
			Assert.AreEqual (Name, provider.AlgorithmName);
			Assert.AreEqual (Padding, provider.Padding);
		}

		[Test]
		public void EnumerateAlgorithms_Contains()
		{
			Assert.IsTrue (SymmetricKeyAlgorithmProvider.EnumerateAlgorithms().Contains (Name));
		}

		[Test]
		public void CreateSymmetricKey_Invalid()
		{
			var provider = OpenAlgorithm();

			COMException c = Assert.Throws<COMException> (() => provider.CreateSymmetricKey (null));
			Assert.AreEqual (-1073741811, c.ErrorCode);

			Assert.Throws<InvalidCastException> (() => provider.CreateSymmetricKey (new FakeBuffer()));
		}

		[Test]
		public void ImportKey_Invalid()
		{
			var provider = OpenAlgorithm();

			COMException c = Assert.Throws<COMException>(() => provider.ImportKey (null));
			Assert.AreEqual (-1073741811, c.ErrorCode);

			Assert.Throws<InvalidCastException> (() => provider.ImportKey (new FakeBuffer()));
		}

		private SymmetricKeyAlgorithmProvider OpenAlgorithm()
		{
			return SymmetricKeyAlgorithmProvider.OpenAlgorithm (Name);
		}
	}
}