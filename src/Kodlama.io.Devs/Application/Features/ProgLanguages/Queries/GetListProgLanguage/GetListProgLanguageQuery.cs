using Application.Features.ProgLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgLanguages.Queries.GetListProgLanguage
{
    public class GetListProgLanguageQuery : IRequest<ProgLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgLanguageQueryHandler : IRequestHandler<GetListProgLanguageQuery, ProgLanguageListModel>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgLanguageQueryHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgLanguageListModel> Handle(GetListProgLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgLanguage> progLanguages = await _progLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                ProgLanguageListModel mappedProgLanguageListModel = _mapper.Map<ProgLanguageListModel>(progLanguages);
                return mappedProgLanguageListModel;

            }
        }
    }
}
