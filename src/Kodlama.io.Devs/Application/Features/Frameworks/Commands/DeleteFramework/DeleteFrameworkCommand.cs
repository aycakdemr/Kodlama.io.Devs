using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Commands.DeleteFramework;
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

namespace Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommand : IRequest<DeletedFrameworkDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FrameworkId { get; set; }

        public class DeleteFrameworkCommandHandler : IRequestHandler<DeleteFrameworkCommand, DeletedFrameworkDto>
        {
            private readonly IFrameworkRepository _FrameworkRepository;
            private readonly IMapper _mapper;


            public DeleteFrameworkCommandHandler(IFrameworkRepository FrameworkRepository, IMapper mapper)
            {
                _FrameworkRepository = FrameworkRepository;
                _mapper = mapper;
            }

            public async Task<DeletedFrameworkDto> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
            {

                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework deletedFramework = await _FrameworkRepository.DeleteAsync(mappedFramework);
                DeletedFrameworkDto deletedFrameworkDto = _mapper.Map<DeletedFrameworkDto>(deletedFramework);
                return deletedFrameworkDto;
            }
        }
    }
}
