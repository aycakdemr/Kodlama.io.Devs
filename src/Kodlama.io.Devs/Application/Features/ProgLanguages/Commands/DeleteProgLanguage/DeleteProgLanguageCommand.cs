using Application.Features.ProgLanguages.Dtos;
using Application.Features.ProgLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgLanguages.Commands.DeleteProgLanguage
{
    public class DeleteProgLanguageCommand : IRequest<DeletedProgLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class DeleteProgLanguageCommandHandler : IRequestHandler<DeleteProgLanguageCommand, DeletedProgLanguageDto>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;


            public DeleteProgLanguageCommandHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProgLanguageDto> Handle(DeleteProgLanguageCommand request, CancellationToken cancellationToken)
            {

                ProgLanguage mappedprogLanguage = _mapper.Map<ProgLanguage>(request);
                ProgLanguage deletedprogLanguage = await _progLanguageRepository.DeleteAsync(mappedprogLanguage);
                DeletedProgLanguageDto deletedProgLanguageDto = _mapper.Map<DeletedProgLanguageDto>(deletedprogLanguage);
                return deletedProgLanguageDto;
            }
        }
    }
}
