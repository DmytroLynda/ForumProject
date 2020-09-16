using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using ForumProject.Data;
using ForumProject.Interfaces;
using ForumProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ForumProject.Models.Services
{
    public class DiscussionService : IDiscussionService
    {
        private readonly ILogger<DiscussionService> _logger;
        private readonly ApplicationDbContext _context;
        public DiscussionService(ILogger<DiscussionService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<Discussion> GetDiscussionAsync(int id)
        {
            var discussion = await _context.Discussions
                .Include(d => d.Messages)
                .ThenInclude(d => d.Author)
                .Include(d => d.Author)
                .SingleOrDefaultAsync(x => x.DiscussionId == id);
            return discussion;
        }

        public async Task AddMessageAsync(int discussionId, string message, User user)
        {
            var userMessage = new Message()
            {
                Author = user,
                Text = message,
                Created = DateTime.Now
            };

            var discussion = await _context.Discussions
                .Include(d => d.Messages)
                .SingleOrDefaultAsync(d => d.DiscussionId == discussionId);
            discussion.Messages.Add(userMessage);
            await _context.SaveChangesAsync();
        }
    }
}
