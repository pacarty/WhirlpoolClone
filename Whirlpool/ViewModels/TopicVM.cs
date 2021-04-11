using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whirlpool.ViewModels
{
    public class TopicVM
    {
        public int TopicViewId { get; set; }
        public string TopicViewName { get; set; }
        public List<ThreadVM> Threads { get; set; }
    }
}
