using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using ForumProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumProject.Models;
using ForumProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ForumProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Get the discussions list.");

            var discussions = _context.Discussions.Include(d => d.Author).ToList();

            var discussionsView = _mapper.Map<List<DiscussionViewModel>>(discussions);

            return View(discussionsView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
