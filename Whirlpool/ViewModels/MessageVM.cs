using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whirlpool.ViewModels
{
    public class MessageVM
    {
        public int MessageViewId { get; set; }
        public string MessageViewContent { get; set; }
        public string TimePosted { get; set; }
        public UserInfo User { get; set; }
    }
}
