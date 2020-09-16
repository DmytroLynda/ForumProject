using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using ForumProject.Data;
using ForumProject.Interfaces;
using ForumProject.Models.ViewModels;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.Extensions.Logging;

namespace ForumProject.Models
{
    public class CreatePostService : ICreatePostService
    {
        private readonly ILogger<CreatePostService> _logger;
        private readonly ApplicationDbContext _context;

        public CreatePostService(ILogger<CreatePostService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<int> CreatePostAsync(CreatePostViewModel post, User creator)
        {
            var message = new Message()
            {
                Author = creator,
                Text = post.Message,
                Created = DateTime.Now
            };

            var discussion = new Discussion()
            {
                Author = creator,
                Topic = post.Topic,
                Created = DateTime.Now, 
                Messages = new List<Message>()
                {
                    message
                }
            };

            var entry = await _context.Discussions.AddAsync(discussion);
            await _context.SaveChangesAsync();

            return entry.Entity.DiscussionId;
        }
    }
}
