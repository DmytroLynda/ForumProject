using System.Threading.Tasks;
using ForumProject.Data;

namespace ForumProject.Interfaces
{
    public interface IDiscussionService
    {
        Task<Discussion> GetDiscussionAsync(int id);
        Task AddMessageAsync(int discussionId, string message, User user);
    }
}
