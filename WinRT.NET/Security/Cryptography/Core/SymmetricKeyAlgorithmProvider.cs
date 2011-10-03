//
// SymmetricKeyAlgorithmProvider.cs
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
using System.Security.Cryptography;
using Windows.Storage.Streams;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Windows.Security.Cryptography.Core
{
	public sealed class SymmetricKeyAlgorithmProvider
	{
		internal SymmetricKeyAlgorithmProvider (string name, SymmetricAlgorithm algorithm)
		{
			AlgorithmName = name;
			this.context = algorithm;

			KeySizes s = algorithm.LegalKeySizes[0];
			
			SupportedKeyLengths = new SupportedKeyLengths
			{
				Increment = (uint)s.SkipSize,
				Max = (uint)s.MaxSize,
				Min = (uint)s.MinSize
			};
		}

		public string AlgorithmName
		{
			get;
			private set;
		}

		public uint BlockLength
		{
			get { return (uint)this.context.BlockSize; }
		}

		public CipherChainingMode CipherChainingMode
		{
			get { return this.context.Mode.ToChainingMode(); }
		}

		public CryptographicPadding Padding
		{
			get { return (this.context.Padding == PaddingMode.PKCS7) ? CryptographicPadding.Block : CryptographicPadding.None; }
		}

		public SupportedKeyLengths SupportedKeyLengths
		{
			get;
			private set;
		}

		public CryptographicKey CreateSymmetricKey (IBuffer keyMaterial)
		{
			if (keyMaterial == null)
				throw new COMException ("Invalid key material", -1073741811);

			WindowsRuntimeBuffer buffer = (WindowsRuntimeBuffer)keyMaterial;

			throw new NotImplementedException();
		}

		public CryptographicKey ImportKey (IBuffer keyBlob)
		{
			if (keyBlob == null)
				throw new COMException ("Invalid key blob", -1073741811);

			WindowsRuntimeBuffer buffer = (WindowsRuntimeBuffer)keyBlob;

			throw new NotImplementedException();
		}

		private SymmetricAlgorithm context;

		public static SymmetricKeyAlgorithmProvider OpenAlgorithm (string algorithm)
		{
			if (algorithm == null)
				throw new ArgumentNullException();

			Func<SymmetricAlgorithm> factory;
			if (!Algorithms.TryGetValue (algorithm, out factory))
				throw new COMException ("Algorithm not found", -1073741275);

			return new SymmetricKeyAlgorithmProvider (algorithm, factory());
		}

		public static IReadOnlyList<string> EnumerateAlgorithms()
		{
			return new ReadOnlyList<string> (AlgorithmNames);
		}

		private static readonly Dictionary<string, Func<SymmetricAlgorithm>> Algorithms = new Dictionary<string, Func<SymmetricAlgorithm>>
		{
			{ "AES_CBC", () => { var a = new AesCryptoServiceProvider(); a.Mode = CipherMode.CBC; a.Padding = PaddingMode.None; return a; } },
			{ "AES_ECB", () => { var a = new AesCryptoServiceProvider(); a.Mode = CipherMode.ECB; a.Padding = PaddingMode.None; return a; } },
			{ "AES_CBC_PKCS7", () => { var a = new AesCryptoServiceProvider(); a.Mode = CipherMode.CBC; a.Padding = PaddingMode.PKCS7; return a; } },
			{ "AES_ECB_PKCS7", () => { var a = new AesCryptoServiceProvider(); a.Mode = CipherMode.ECB; a.Padding = PaddingMode.PKCS7; return a; } },
		};

		private static readonly string[] AlgorithmNames = Algorithms.Keys.ToArray();
	}
}
