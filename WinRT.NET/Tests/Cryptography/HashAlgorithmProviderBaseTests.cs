//
// HashAlgorithmProviderBaseTests.cs
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
using System.Linq;
using NUnit.Framework;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using WinRTNET.Tests.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace WinRTNET.Tests.Cryptography
{
	public abstract class HashAlgorithmProviderBaseTests
	{
		public abstract string Name
		{
			get;
		}

		[Test]
		public void Open()
		{
			HashAlgorithmProvider provider = HashAlgorithmProvider.OpenAlgorithm (Name);
			Assert.IsNotNull (provider);
			Assert.Greater (provider.HashLength, 0);
			Assert.AreEqual (Name, provider.AlgorithmName);
		}

		[Test]
		public void EnumerateAlgorithms_Contains()
		{
			Assert.IsTrue (HashAlgorithmProvider.EnumerateAlgorithms().Contains (Name));
		}

		[Test]
		public void HashData_Null()
		{
			HashAlgorithmProvider provider = OpenAlgorithm();
			IBuffer buffer = provider.HashData (null);
			Assert.IsNotNull (buffer);
			Assert.AreEqual (provider.HashLength, buffer.Length);
			Assert.AreEqual (provider.HashLength, buffer.Capacity);
		}

		[Test]
		public void HashData_FakeBuffer()
		{
			HashAlgorithmProvider provider = OpenAlgorithm();
			Assert.Throws<InvalidCastException> (() => provider.HashData (new FakeBuffer()));
		}

		[Test]
		public void HashData()
		{
			HashAlgorithmProvider provider = OpenAlgorithm();

			IBuffer buffer = provider.HashData (new byte[] { 1, 2, 3, 4 }.AsBuffer());
			Assert.IsNotNull (buffer);
			Assert.AreEqual (provider.HashLength, buffer.Length);
			Assert.AreEqual (provider.HashLength, buffer.Capacity);
		}

		[Test]
		public void CreateHash_NotSupported()
		{
			var alg = OpenAlgorithm();
			Assert.Throws<NotSupportedException>(() => alg.CreateHash());
		}

		//[Test]
		public void CreateHash()
		{
			CryptographicHash hash = OpenAlgorithm().CreateHash();
			Assert.IsNotNull (hash);
		}

		//[Test]
		public void CryptographicHash_GetValue_Empty()
		{
			CryptographicHash hash = OpenAlgorithm().CreateHash();
			IBuffer buffer = hash.GetValue();

			byte[] data; int offset;
			Assert.IsFalse (buffer.TryGetUnderlyingData (out data, out offset));
		}

		//[Test]
		public void CryptographicHash_Append_Null()
		{
			CryptographicHash hash = OpenAlgorithm().CreateHash();
			Assert.DoesNotThrow (() => hash.Append (null));
		}

		//[Test]
		public void CryptographicHash_Append_FakeBuffer()
		{
			CryptographicHash hash = OpenAlgorithm().CreateHash();
			Assert.Throws<InvalidCastException> (() => hash.Append (new FakeBuffer()));
		}

		private HashAlgorithmProvider OpenAlgorithm()
		{
			return HashAlgorithmProvider.OpenAlgorithm (Name);
		}
	}
}
