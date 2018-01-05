using System;

namespace Demo.Web.Html5
{
    public class MessageInfo
    {
        public MessageInfo(DateTime time, ArraySegment<byte> content)
        {
            Time = time;
            Content = content;
        }

        public DateTime Time { get; }
        public ArraySegment<byte> Content { get; }
    }
}