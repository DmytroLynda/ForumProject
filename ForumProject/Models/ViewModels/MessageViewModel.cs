using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;

namespace ForumProject.Models.ViewModels
{
    public class MessageViewModel
    {
        [Required]
        public User Author { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
