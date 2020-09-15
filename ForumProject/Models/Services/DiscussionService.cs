using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Interfaces;
using ForumProject.Models.ViewModels;

namespace ForumProject.Models.Services
{
    public class DiscussionService : IDiscussionService
    {
        public Task<DiscussionViewModel> GetDiscussionAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
