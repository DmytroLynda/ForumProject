using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;
using ForumProject.Interfaces;
using ForumProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ForumProject.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        private readonly ILogger<CreateController> _logger;
        private readonly ICreatePostService _createService;
        private readonly UserManager<User> _userService;

        public CreateController(ILogger<CreateController> logger, ICreatePostService createService, UserManager<User> userService)
        {
            _logger = logger;
            _createService = createService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            _logger.LogInformation("Load the create discussion view.");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostViewModel post)
        {
            _logger.LogInformation("User: {0} tries to create a new post", User.Identity.Name);

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Validation error! {0}", ModelState);
                return View(post);
            }

            var user = await _userService.GetUserAsync(User);

            var id = await _createService.CreatePostAsync(post, user);

            _logger.LogInformation("New post with id: {0} was created successfully", id);

            return RedirectToAction("Index", "Discussion", new {id = id});
        }
    }
}
