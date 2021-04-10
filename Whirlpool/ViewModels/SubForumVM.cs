using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whirlpool.Models;

namespace Whirlpool.ViewModels
{
    public class SubForumVM
    {
        public string SubForumName { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
