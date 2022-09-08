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

namespace Application.Features.ProgLanguages.Queries.GetByIdProgLanguage
{
    public class GetByIdProgLanguageQuery : IRequest<ProgLanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgLanguageQueryHandler : IRequestHandler<GetByIdProgLanguageQuery, ProgLanguageGetByIdDto>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;
           
            public GetByIdProgLanguageQueryHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgLanguageGetByIdDto> Handle(GetByIdProgLanguageQuery request, CancellationToken cancellationToken)
            {

                ProgLanguage? progLanguage = await _progLanguageRepository.GetAsync(b => b.Id == request.Id);
                ProgLanguageGetByIdDto progLanguageGetByIdDto = _mapper.Map<ProgLanguageGetByIdDto>(progLanguage);
                return progLanguageGetByIdDto;

            }
        }
    }
}
