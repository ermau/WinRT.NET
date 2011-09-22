//
// DataReader.cs
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

namespace Windows.Storage.Streams
{
	public sealed class DataReader
		: IDataReader
	{
		public DataReader (IInputStream inputStream)
		{
			if (inputStream == null)
				throw new ArgumentNullException ("inputStream");

			throw new NotImplementedException();
		}

		public ByteOrder ByteOrder
		{
			get;
			set;
		}

		public InputStreamOptions InputStreamOptions
		{
			get;
			set;
		}

		public uint UnconsumedBufferLength
		{
			get { throw new NotImplementedException(); }
		}

		public UnicodeEncoding UnicodeEncoding
		{
			get;
			set;
		}

		public IBuffer DetachBuffer()
		{
			throw new NotImplementedException();
		}

		public IInputStream DetatchStream()
		{
			throw new NotImplementedException();
		}

		public DataReaderLoadOperation LoadAsync (uint count)
		{
			throw new NotImplementedException();
		}

		public bool ReadBoolean()
		{
			throw new NotImplementedException();
		}

		public IBuffer ReadBuffer()
		{
			throw new NotImplementedException();
		}

		public byte ReadByte()
		{
			throw new NotImplementedException();
		}

		public void ReadBytes (out byte[] value)
		{
			throw new NotImplementedException();
		}

		public DateTimeOffset ReadDateTime()
		{
			throw new NotImplementedException();
		}

		public double ReadDouble()
		{
			throw new NotImplementedException();
		}

		public Guid ReadGuid()
		{
			throw new NotImplementedException();
		}

		public short ReadInt16()
		{
			throw new NotImplementedException();
		}

		public ushort ReadUInt16()
		{
			throw new NotImplementedException();
		}

		public int ReadInt32()
		{
			throw new NotImplementedException();
		}

		public uint ReadUInt32()
		{
			throw new NotImplementedException();
		}

		public long ReadInt64()
		{
			throw new NotImplementedException();
		}

		public ulong ReadUInt64()
		{
			throw new NotImplementedException();
		}

		public float ReadSingle()
		{
			throw new NotImplementedException();
		}

		public string ReadString()
		{
			throw new NotImplementedException();
		}

		public TimeSpan ReadTimeSpan()
		{
			throw new NotImplementedException();
		}
	}
}
