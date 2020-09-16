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
            _logger.LogInformation("Get discussion with id: {0}", id);

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Something went wrong. Model state is not valid.");
                return RedirectToAction("Index", "Home");
            }

            var discussion = await _discussionService.GetDiscussionAsync(id);

            if (discussion is null)
            {
                _logger.LogWarning("Discussion with id: {0} does not exist.", id);
                return RedirectToAction("Index", "Home");
            }

            var viewModel = _mapper.Map<DiscussionViewModel>(discussion);

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(int id, MessageViewModel message)
        {
            _logger.LogInformation("User: {0} tries to leave a message: {1} in the discussion: {2}", User.Identity.Name, message.Text, id);
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserAsync(User);
                await _discussionService.AddMessageAsync(id, message.Text, user);

                _logger.LogInformation("Message was saved.");
            }
            else
            {
                _logger.LogInformation("Validation error, the message was not saved.");
            }

            return RedirectToAction("Index", "Discussion", id);
        }
    }
}
