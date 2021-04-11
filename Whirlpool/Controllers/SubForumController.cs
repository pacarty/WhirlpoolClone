using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Whirlpool.ForumData;
using Whirlpool.Models;
using Whirlpool.ViewModels;

namespace Whirlpool.Controllers
{
    public class SubForumController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumContext _context;

        public SubForumController(
            ILogger<HomeController> logger,
            ForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<SubForumVM> subVMList = new List<SubForumVM>();
            List<SubForum> dataList = _context.SubForums.ToList();

            foreach (SubForum item in dataList)
            {
                SubForumVM subVM = new SubForumVM();
                List<TopicVM> topicVMList = new List<TopicVM>();

                subVM.SubForumName = item.SubName;

                List<Topic> topics = _context.Topics.Where(x => x.SubForumId == item.SubForumId).ToList();

                foreach (Topic t in topics)
                {
                    topicVMList.Add(
                        new TopicVM
                        {
                            TopicViewId = t.TopicId,
                            TopicViewName = t.TopicName
                        });
                }

                subVM.Topics = topicVMList;

                subVMList.Add(subVM);
            }

            return View(subVMList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
