using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace FineCraft.Network
{
    class AwesomeWriteBuffer : Stream
    {
        public AwesomeWriteBuffer(Stream underlying)
        {
            this.underlying = underlying;
            buffer = new byte[65536];
            HelpfulStuff.RunPeriodic(() => HelpfulStuff.Try(Flush), 300);
        }

        int index;
        byte[] buffer;
        Stream underlying;

        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            lock (this)
                if (index != 0)
                {
                    underlying.Write(buffer, 0, index);
                    underlying.Flush();
                    index = 0;
                }
            //Thread.Sleep(0);
        }

        public override long Length
        {
            get { throw new InvalidOperationException(); }
        }
        public override long Position
        {
            get
            {
                throw new InvalidOperationException();
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new InvalidOperationException();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new InvalidOperationException();
        }
        public override void SetLength(long value)
        {
            throw new InvalidOperationException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (index + count > this.buffer.Length)
            {
                if (count > this.buffer.Length)
                    throw new InvalidOperationException("I can`t take it anymore.");
                Flush();
            }
            lock (this)
            {
                Array.Copy(buffer, offset, this.buffer, index, count);
                index += count;
            }
        }
    }
}
