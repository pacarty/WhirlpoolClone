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
    [Route("SubForum/Topic/{controller}/{action}/{id}")]
    public class ThreadController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumContext _context;

        public ThreadController(
            ILogger<HomeController> logger,
            ForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            Thread thread = _context.Threads.Find(id);

            ThreadVM threadVM = new ThreadVM
            {
                ThreadViewId = thread.ThreadId,
                ThreadViewName = thread.ThreadName
            };

            return View(threadVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
