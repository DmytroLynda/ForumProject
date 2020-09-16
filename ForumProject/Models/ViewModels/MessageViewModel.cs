using System;
using System.ComponentModel.DataAnnotations;
using ForumProject.Data;

namespace ForumProject.Models.ViewModels
{
    public class MessageViewModel
    {
        public User Author { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 1)]
        public string Text { get; set; }
        public DateTime Created { get; set; }
    }
}
