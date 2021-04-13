using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whirlpool.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public int ThreadId { get; set; }
        public string UserId { get; set; }
    }
}
