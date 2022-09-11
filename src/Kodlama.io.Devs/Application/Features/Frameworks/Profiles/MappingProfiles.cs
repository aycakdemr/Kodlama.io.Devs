using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Commands.DeleteFramework;
using Application.Features.Frameworks.Commands.UpdateFramework;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Frameworks.Models;

namespace Application.Features.Frameworks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Framework, FrameworkListDto>().
                ForMember(c => c.ProgLanguageName, opt => opt.MapFrom(c => c.ProgLanguage.Name)).
                ReverseMap();
            CreateMap<IPaginate<Framework>, FrameworkListModel>().ReverseMap();
            CreateMap<Framework, CreatedFrameworkDto>().ReverseMap();
            CreateMap<Framework, CreateFrameworkCommand>().ReverseMap();
            CreateMap<Framework, DeletedFrameworkDto>().ReverseMap();
            CreateMap<Framework, DeleteFrameworkCommand>().ReverseMap();
            CreateMap<Framework, UpdatedFrameworkDto>().ReverseMap();
            CreateMap<Framework, UpdateFrameworkCommand>().ReverseMap();
        }
    }
}
