using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Whirlpool.ForumData;
using Whirlpool.IdentityData;
using Whirlpool.Models;
using Whirlpool.ViewModels;

namespace Whirlpool.Controllers
{
    // [Route("SubForum/Topic/{controller}/{action}/{id}")]
    public class ThreadController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ThreadController(
            ILogger<HomeController> logger,
            ForumContext context,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Create(ThreadVM threadVM)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userId = user.Id;

            Message msg = new Message
            {
                Content = threadVM.MessageContent,
                ThreadId = threadVM.ThreadViewId,
                UserId = userId
            };

            user.TotalPosts++;
            await _userManager.UpdateAsync(user);

            await _context.Messages.AddAsync(msg);
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> Index(int id)
        {
            Thread thread = _context.Threads.Find(id);

            ThreadVM threadVM = new ThreadVM
            {
                ThreadViewId = thread.ThreadId,
                ThreadViewName = thread.ThreadName
            };

            List<MessageVM> messageVMList = new List<MessageVM>();
            List<Message> messages = _context.Messages.Where(x => x.ThreadId == id).ToList();

            foreach (Message m in messages)
            {
                var user = await _userManager.FindByIdAsync(m.UserId);

                messageVMList.Add(
                    new MessageVM
                    {
                        MessageViewId = m.MessageId,
                        MessageViewContent = m.Content,
                        User = new UserInfo
                        {
                            UserName = user.UserName,
                            UserDateCreated = user.CreatedDate?.ToString("d"),
                            UserTotalPosts = user.TotalPosts
                        }       
                    });
            }

            threadVM.MessageViews = messageVMList;

            return View(threadVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
