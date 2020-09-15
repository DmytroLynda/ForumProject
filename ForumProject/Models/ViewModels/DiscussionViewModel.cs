using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;

namespace ForumProject.Models.ViewModels
{
    public class DiscussionViewModel
    {
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
