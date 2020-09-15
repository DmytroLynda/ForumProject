using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.Models.ViewModels
{
    public class CreatePostViewModel
    {
        [Required]
        [Display(Name = "Topic:")]
        [MaxLength(150)]
        public string Topic { get; set; }
        [Required]
        [Display(Name = "First message:")]
        [MaxLength()]
        public string Message { get; set; }
    }
}
