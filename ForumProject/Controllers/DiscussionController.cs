using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;
using ForumProject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ForumProject.Controllers
{
    public class DiscussionController : Controller
    {
        private readonly ILogger<DiscussionController> _logger;
        private readonly IDiscussionService _discussionService;
        private readonly UserManager<User> _userService;

        public DiscussionController(ILogger<DiscussionController> logger, IDiscussionService discussionService, UserManager<User> userService)
        {
            _logger = logger;
            _discussionService = discussionService;
            _userService = userService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var discussion = await _discussionService.GetDiscussionAsync(id);

            if (discussion is null)
            {
                View();
            }

            return View(discussion);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(int id, [FromForm] string message)
        {
            var user = await _userService.GetUserAsync(User);

            await _discussionService.AddMessageAsync(id, message, user);

            return RedirectToAction("Index", "Discussion", id);
        }
    }
}
