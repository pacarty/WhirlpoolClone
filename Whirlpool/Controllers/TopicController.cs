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
    // [Route("SubForum/{controller}/{action}/{id}")]
    public class TopicController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumContext _context;

        public TopicController(
            ILogger<HomeController> logger,
            ForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            Topic topic = _context.Topics.Find(id);

            TopicVM topicVM = new TopicVM
            {
                TopicViewId = topic.TopicId,
                TopicViewName = topic.TopicName
            };

            List<ThreadVM> threadVMList = new List<ThreadVM>();

            List<Thread> threads = _context.Threads.Where(x => x.TopicId == id).ToList();

            foreach (Thread t in threads)
            {
                threadVMList.Add(
                    new ThreadVM
                    {
                        ThreadViewId = t.ThreadId,
                        ThreadViewName = t.ThreadName
                    });
            }

            topicVM.Threads = threadVMList;

            return View(topicVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
