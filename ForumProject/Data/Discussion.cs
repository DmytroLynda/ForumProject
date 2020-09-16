using System;
using System.Collections.Generic;

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
