using Application.Features.Frameworks.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Frameworks.Queries.GetListFramework
{
    public class GetListFrameworkQuery : IRequest<FrameworkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetlistFrameworkQueryHandler : IRequestHandler<GetListFrameworkQuery, FrameworkListModel>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _FrameworkRepository;

            public GetlistFrameworkQueryHandler(IMapper mapper, IFrameworkRepository FrameworkRepository)
            {
                _mapper = mapper;
                _FrameworkRepository = FrameworkRepository;
            }

            public async Task<FrameworkListModel> Handle(GetListFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameworks = await _FrameworkRepository.GetListAsync(include:
                                                 m => m.Include(c => c.ProgLanguage),
                                                 index: request.PageRequest.Page,
                                                 size: request.PageRequest.PageSize);
                FrameworkListModel framework = _mapper.Map<FrameworkListModel>(frameworks);
                return framework;
            }
        }
    }
}
