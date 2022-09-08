using Application.Features.ProgLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgLanguages.Dtos;
using Application.Features.ProgLanguages.Rules;

namespace Application.Features.ProgLanguages.Commands.CreateProgLanguage
{
    public class CreateProgLanguageCommand : IRequest<CreatedProgLanguageDto>
    {

        public string Name { get; set; }

        public class CreateProgLanguageCommandHandler : IRequestHandler<CreateProgLanguageCommand, CreatedProgLanguageDto>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;
             private readonly ProgLanguageBusinessRules _progLanguageBusinessRules;

            public CreateProgLanguageCommandHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper, ProgLanguageBusinessRules progLanguageBusinessRules)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
                _progLanguageBusinessRules = progLanguageBusinessRules;
            }

            public async Task<CreatedProgLanguageDto> Handle(CreateProgLanguageCommand request, CancellationToken cancellationToken)
            {
                await _progLanguageBusinessRules.ProgLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgLanguage mappedprogLanguage = _mapper.Map<ProgLanguage>(request);
                ProgLanguage createdprogLanguage = await _progLanguageRepository.AddAsync(mappedprogLanguage);
                CreatedProgLanguageDto createdProgLanguageDto = _mapper.Map<CreatedProgLanguageDto>(createdprogLanguage);
                return createdProgLanguageDto;
            }
        }
    
}
}
