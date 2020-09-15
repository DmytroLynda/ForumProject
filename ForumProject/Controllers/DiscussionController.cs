using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class DiscussionController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
