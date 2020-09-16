using AutoMapper;
using ForumProject.Data;
using ForumProject.Models.ViewModels;

namespace ForumProject.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Discussion, DiscussionViewModel>();
            CreateMap<DiscussionViewModel, Discussion>();

            CreateMap<Message, MessageViewModel>();
            CreateMap<MessageViewModel, Message>();
        }
    }
}
