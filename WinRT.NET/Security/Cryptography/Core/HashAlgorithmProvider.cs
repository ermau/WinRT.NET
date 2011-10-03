//
// HashAlgorithmProvider.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Windows.Security.Cryptography.Core
{
	public sealed class HashAlgorithmProvider
	{
		internal HashAlgorithmProvider (string name, HashAlgorithm algorithm)
		{
			this.context = algorithm;
			AlgorithmName = name;
		}

		public string AlgorithmName
		{
			get;
			private set;
		}

		public uint HashLength
		{
			get { return (uint)this.context.HashSize / 8; }
		}

		public CryptographicHash CreateHash()
		{
			throw new NotSupportedException();
		}

		public IBuffer HashData (IBuffer data)
		{
			if (data == null)
				return new byte[HashLength].AsBuffer();

			return this.context.ComputeHash (data.AsStream()).AsBuffer();
		}

		private readonly HashAlgorithm context;

		public static IReadOnlyList<string> EnumerateAlgorithms()
		{
			return new ReadOnlyList<string> (Algorithms.Keys.ToList());
		}

		public static HashAlgorithmProvider OpenAlgorithm (string algorithm)
		{
			if (algorithm == null)
				throw new ArgumentNullException ("algorithm");

			Func<HashAlgorithm> algCtor;
			if (!Algorithms.TryGetValue (algorithm, out algCtor))
				throw new COMException ("Algorithm not found", -1073741275);

			return new HashAlgorithmProvider(algorithm, algCtor());
		}

		private static readonly Dictionary<string, Func<HashAlgorithm>> Algorithms = new Dictionary<string, Func<HashAlgorithm>>
		{
			{ "MD5", () => new MD5CryptoServiceProvider() },
			{ "SHA1", () => new SHA1CryptoServiceProvider() },
			{ "SHA256", () => new SHA256CryptoServiceProvider() },
			{ "SHA384", () => new SHA384CryptoServiceProvider() },
			{ "SHA512", () => new SHA512CryptoServiceProvider() }
		};
	}
}