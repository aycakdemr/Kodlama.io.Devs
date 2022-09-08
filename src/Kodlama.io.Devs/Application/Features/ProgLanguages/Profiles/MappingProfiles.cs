using Application.Features.ProgLanguages.Commands.CreateProgLanguage;
using Application.Features.ProgLanguages.Commands.DeleteProgLanguage;
using Application.Features.ProgLanguages.Dtos;
using Application.Features.ProgLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgLanguage, CreatedProgLanguageDto>().ReverseMap();
            CreateMap<ProgLanguage, CreateProgLanguageCommand>().ReverseMap();
            CreateMap<ProgLanguage, DeletedProgLanguageDto>().ReverseMap();
            CreateMap<ProgLanguage, DeleteProgLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgLanguage>, ProgLanguageListModel>().ReverseMap();
            CreateMap<ProgLanguage, ProgLanguageListDto>().ReverseMap();
            CreateMap<ProgLanguage, ProgLanguageGetByIdDto>().ReverseMap();
        }
    }
}
