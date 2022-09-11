using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Commands.UpdateFramework;
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

namespace Application.Features.Frameworks.Commands.UpdateFramework
{
    public class UpdateFrameworkCommand : IRequest<UpdatedFrameworkDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FrameworkId { get; set; }
        public class UpdateFrameworkCommandHandler : IRequestHandler<UpdateFrameworkCommand, UpdatedFrameworkDto>
        {
            private readonly IFrameworkRepository _FrameworkRepository;
            private readonly IMapper _mapper;


            public UpdateFrameworkCommandHandler(IFrameworkRepository FrameworkRepository, IMapper mapper)
            {
                _FrameworkRepository = FrameworkRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedFrameworkDto> Handle(UpdateFrameworkCommand request, CancellationToken cancellationToken)
            {

                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework updatedFramework = await _FrameworkRepository.DeleteAsync(mappedFramework);
                UpdatedFrameworkDto updatedFrameworkDto = _mapper.Map<UpdatedFrameworkDto>(updatedFramework);
                return updatedFrameworkDto;
            }
        }

    }
}
