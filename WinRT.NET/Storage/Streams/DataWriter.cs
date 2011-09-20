//
// DataWriter.cs
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
	public sealed class DataWriter
		: IDataWriter
	{
		public DataWriter()
		{
			throw new System.NotImplementedException();
		}

		public DataWriter (IOutputStream outputStream)
		{
			throw new System.NotImplementedException();
		}

		public ByteOrder ByteOrder
		{
			get;
			set;
		}

		public UnicodeEncoding UnicodeEncoding
		{
			get;
			set;
		}

		public uint UnstoredBufferLength
		{
			get { throw new System.NotImplementedException(); }
		}

		public IBuffer DetatchBuffer()
		{
			throw new System.NotImplementedException();
		}

		public IOutputStream DetatchStream()
		{
			throw new System.NotImplementedException();
		}

		public uint MeasureString(string value)
		{
			throw new System.NotImplementedException();
		}

		public DataWriterStoreOperation StoreAsync()
		{
			throw new System.NotImplementedException();
		}

		public void WriteBoolean(bool value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteBuffer(IBuffer value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteBuffer(IBuffer value, uint start, uint count)
		{
			throw new System.NotImplementedException();
		}

		public void WriteByte(byte value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteBytes(byte[] value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteDateTime(System.DateTimeOffset value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteDouble(double value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteGuid(System.Guid value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteInt16(short value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteUInt16(ushort value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteInt32(int value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteUInt32(ushort value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteInt64(long value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteUInt64(ulong value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteSingle(float value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteTimeSpan(System.TimeSpan value)
		{
			throw new System.NotImplementedException();
		}

		public void WriteString(string value)
		{
			throw new System.NotImplementedException();
		}
	}
}