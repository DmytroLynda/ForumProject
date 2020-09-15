using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ForumProject.Data;
using ForumProject.Models.ViewModels;
using Microsoft.AspNetCore.Session;

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
