﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ForumProject.Data
{
    public class Discussion
    {
        public User Author { get; set; }
        public ICollection<Message> Messages { get; set; }
        public DateTime Created { get; set; }
    }
}