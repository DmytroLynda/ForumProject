using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using ForumProject.Data;
using ForumProject.Interfaces;
using ForumProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;

namespace ForumProject.Models.Services
{
    public class DiscussionService : IDiscussionService
    {
        private readonly ILogger<DiscussionService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DiscussionService(ILogger<DiscussionService> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        public async Task<DiscussionViewModel> GetDiscussionAsync(int id)
        {
            var discussion = await _context.Discussions.FindAsync(id);
            return _mapper.Map<DiscussionViewModel>(discussion);
        }

        public async Task AddMessageAsync(int id, string message, User user)
        {
            var userMessage = new Message()
            {
                Author = user,
                Text = message,
                Created = DateTime.Now
            };

            var discussion = await _context.Discussions.FindAsync(id);
            discussion.Messages.Add(userMessage);
            await _context.SaveChangesAsync();
        }
    }
}
