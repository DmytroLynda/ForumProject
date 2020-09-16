using System.ComponentModel.DataAnnotations;

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
        [MaxLength(5000)]
        public string Message { get; set; }
    }
}
