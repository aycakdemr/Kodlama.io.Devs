using Application.Features.Frameworks.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommand : IRequest<CreatedFrameworkDto>
    {
        public string Name { get; set; }
        public int ProgLanguageId { get; set; }

        public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreatedFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;

            public CreateFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
            }

            public async Task<CreatedFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework mappedframework = _mapper.Map<Framework>(request);
                Framework createdframework = await _frameworkRepository.AddAsync(mappedframework);
                CreatedFrameworkDto createdFrameworkDto = _mapper.Map<CreatedFrameworkDto>(createdframework);
                return createdFrameworkDto;
            }
        }
    }
}
