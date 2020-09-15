using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;
using ForumProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ForumProject.Controllers
{
    public class DiscussionController : Controller
    {
        private readonly ILogger<DiscussionController> _logger;
        private readonly IDiscussionService _service;

        public DiscussionController(ILogger<DiscussionController> logger, IDiscussionService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<IActionResult> Index(int id)
        {
            var discussion = await _service.GetDiscussionAsync(id);

            if (discussion is null)
            {
                View();
            }

            return View(discussion);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id, Message message)
        {
            return View();
        }
    }
}
