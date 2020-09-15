using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ForumProject.Data
{
    public class Message
    {
        public int MessageId { get; set; }
        public User Author { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
    }
}
