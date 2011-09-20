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

namespace Windows.Storage.Streams
{
	public sealed class DataReader
		: IDataReader
	{
		public DataReader()
		{
			throw new System.NotImplementedException();
		}

		public DataReader(IInputStream inputStream)
		{
			throw new System.NotImplementedException();
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
			get { throw new System.NotImplementedException(); }
		}

		public UnicodeEncoding UnicodeEncoding
		{
			get;
			set;
		}

		public IBuffer DetachBuffer()
		{
			throw new System.NotImplementedException();
		}

		public IInputStream DetatchStream()
		{
			throw new System.NotImplementedException();
		}

		public DataReaderLoadOperation LoadAsync(uint count)
		{
			throw new System.NotImplementedException();
		}

		public bool ReadBoolean()
		{
			throw new System.NotImplementedException();
		}

		public IBuffer ReadBuffer()
		{
			throw new System.NotImplementedException();
		}

		public byte ReadByte()
		{
			throw new System.NotImplementedException();
		}

		public void ReadBytes(out byte[] value)
		{
			throw new System.NotImplementedException();
		}

		public System.DateTimeOffset ReadDateTime()
		{
			throw new System.NotImplementedException();
		}

		public double ReadDouble()
		{
			throw new System.NotImplementedException();
		}

		public System.Guid ReadGuid()
		{
			throw new System.NotImplementedException();
		}

		public short ReadInt16()
		{
			throw new System.NotImplementedException();
		}

		public ushort ReadUInt16()
		{
			throw new System.NotImplementedException();
		}

		public int ReadInt32()
		{
			throw new System.NotImplementedException();
		}

		public uint ReadUInt32()
		{
			throw new System.NotImplementedException();
		}

		public long ReadInt64()
		{
			throw new System.NotImplementedException();
		}

		public ulong ReadUInt64()
		{
			throw new System.NotImplementedException();
		}

		public float ReadSingle()
		{
			throw new System.NotImplementedException();
		}

		public string ReadString()
		{
			throw new System.NotImplementedException();
		}

		public System.TimeSpan ReadTimeSpan()
		{
			throw new System.NotImplementedException();
		}
	}
}
