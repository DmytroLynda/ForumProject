using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Models.ViewModels;

namespace ForumProject.Interfaces
{
    public interface IDiscussionService
    {
        Task<DiscussionViewModel> GetDiscussionAsync(int id);
    }
}
