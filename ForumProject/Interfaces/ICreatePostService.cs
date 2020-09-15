using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;
using ForumProject.Models.ViewModels;

namespace ForumProject.Interfaces
{
    public interface ICreatePostService
    {
        Task<int> CreatePostAsync(CreatePostViewModel post, User creator);
    }
}
