using Application.Features.ProgLanguages.Commands.DeleteProgLanguage;
using Application.Features.ProgLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgLanguages.Commands.UpdateProgLanguage
{
    public class UpdateProgLanguageCommand : IRequest<UpdatedProgLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgLanguageCommandHandler : IRequestHandler<UpdateProgLanguageCommand, UpdatedProgLanguageDto>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;


            public UpdateProgLanguageCommandHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProgLanguageDto> Handle(UpdateProgLanguageCommand request, CancellationToken cancellationToken)
            {

                ProgLanguage mappedprogLanguage = _mapper.Map<ProgLanguage>(request);
                ProgLanguage updatedprogLanguage = await _progLanguageRepository.DeleteAsync(mappedprogLanguage);
                UpdatedProgLanguageDto updatedProgLanguageDto = _mapper.Map<UpdatedProgLanguageDto>(updatedprogLanguage);
                return updatedProgLanguageDto;
            }
        }
    }
}
