using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whirlpool.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int SubForumId { get; set; }
    }
}
