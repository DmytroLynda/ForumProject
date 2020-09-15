using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ForumProject.Data
{
    public class Discussion
    {
        public int DiscussionId { get; set; }
        public string Topic { get; set; }
        public User Author { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
