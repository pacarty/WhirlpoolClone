using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whirlpool.ViewModels
{
    public class ThreadVM
    {
        public int ThreadViewId { get; set; }
        public string ThreadViewName { get; set; }
        public List<MessageVM> MessageViews { get; set; }
        public string MessageContent { get; set; }
    }
}
