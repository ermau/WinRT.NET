//
// StreamSocket.cs
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

namespace Windows.Networking.Sockets
{
	public class StreamSocket
		: IStreamSocket
	{
		public StreamSocketControl Control
		{
			get { throw new System.NotImplementedException(); }
		}

		public StreamSocketInformation Information
		{
			get { throw new System.NotImplementedException(); }
		}

		public IInputStream InputStream
		{
			get { throw new System.NotImplementedException(); }
		}

		public IOutputStream OutputStream
		{
			get { throw new System.NotImplementedException(); }
		}

		public StreamSocketConnectOperation ConnectAsync (HostName hostName, string remoteServiceName, SocketProtectionLevel protectionLevel)
		{
			throw new System.NotImplementedException();
		}

		public UpgradeToSslOperation UpgradeToSslAsync (SocketProtectionLevel protectionlevel, HostName validationHostName)
		{
			throw new System.NotImplementedException();
		}

		public void Close()
		{
			throw new System.NotImplementedException();
		}
	}
}
