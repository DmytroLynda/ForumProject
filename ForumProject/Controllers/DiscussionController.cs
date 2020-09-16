using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ForumProject.Data;
using ForumProject.Interfaces;
using ForumProject.Models.ViewModels;
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
        private readonly IMapper _mapper;

        public DiscussionController(
            ILogger<DiscussionController> logger, 
            IDiscussionService discussionService,
            UserManager<User> userService,
            IMapper mapper)
        {
            _logger = logger;
            _discussionService = discussionService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var discussion = await _discussionService.GetDiscussionAsync(id);

            if (discussion is null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = _mapper.Map<DiscussionViewModel>(discussion);

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(int id, MessageViewModel message)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserAsync(User);
                await _discussionService.AddMessageAsync(id, message.Text, user);
            }

            return RedirectToAction("Index", "Discussion", id);
        }
    }
}
