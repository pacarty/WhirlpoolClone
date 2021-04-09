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
            /*
            List<SubForumVM> subVMList = new List<SubForumVM>();

            SubForumVM subVM1 = new SubForumVM
            {
                SubForumName = "SubOne"
            };

            SubForumVM subVM2 = new SubForumVM
            {
                SubForumName = "SubTwo"
            };

            subVMList.Add(subVM1);
            subVMList.Add(subVM2);

            return View(subVMList);
            */

            /*
            List<SubForumVM> subVMList = new List<SubForumVM>();

            for (int i = 0; i < _context.SubForums.Count(); i++)
            {
                subVMList.Add(
                    new SubForumVM
                    {
                         SubForumName = _context.SubForums.ElementAt(i).SubName
                    });
            }
            */

            List<SubForumVM> subVMList = new List<SubForumVM>();

            List<SubForum> dataList = _context.SubForums.ToList();

            foreach (SubForum item in dataList)
            {
                SubForumVM subVM = new SubForumVM();
                subVM.SubForumName = item.SubName;

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
