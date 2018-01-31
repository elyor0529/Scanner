using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SC.Web.Filters
{
    public class WhiteSpaceFilter : Stream
    {
        private readonly Stream _sink;

        public WhiteSpaceFilter(Stream sink)
        {
            _sink = sink;
        }

        #region Properites

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => true;

        public override void Flush()
        {
            _sink.Flush();
        }

        public override long Length => 0;

        public override long Position { get; set; }

        #endregion

        #region Methods

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _sink.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _sink.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _sink.SetLength(value);
        }

        public override void Close()
        {
            _sink.Close();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var data = new byte[count];
            Buffer.BlockCopy(buffer, offset, data, 0, count);
            var html = Encoding.Default.GetString(data);

            html = Regex.Replace(html, @">\s+<", "><");
            html = Regex.Replace(html, @"\s+", " ");

            var outdata = Encoding.Default.GetBytes(html.Trim());
            _sink.Write(outdata, 0, outdata.Length);
        }

        #endregion
    }
}