using System;
using System.Threading.Tasks;
using ForumProject.Data;
using ForumProject.Interfaces;
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
            _logger.LogInformation("Get discussion: {0}", id);

            var discussion = await _context.Discussions
                .Include(d => d.Messages)
                .ThenInclude(d => d.Author)
                .Include(d => d.Author)
                .SingleOrDefaultAsync(x => x.DiscussionId == id);
            return discussion;
        }

        public async Task AddMessageAsync(int discussionId, string message, User user)
        {
            _logger.LogInformation("Add a new message: {0} to the discussion: {1} by user: {2}", message, discussionId, user.UserName);

            var userMessage = new Message
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
