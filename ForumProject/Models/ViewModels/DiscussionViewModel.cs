using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ForumProject.Data;

namespace ForumProject.Models.ViewModels
{
    public class DiscussionViewModel
    {
        public int DiscussionId { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required, MinLength(1)]
        public ICollection<Message> Messages { get; set; }
    }
}
