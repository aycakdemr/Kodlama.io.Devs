using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialCommand : IRequest<CreatedSocialDto>
    {
        public string Url { get; set; }
        public int UserId { get; set; }

        public class CreateSocialCommandHandler : IRequestHandler<CreateSocialCommand, CreatedSocialDto>
        {
            private readonly ISocialRepository _SocialRepository;
            private readonly IMapper _mapper;

            public CreateSocialCommandHandler(ISocialRepository SocialRepository, IMapper mapper)
            {
                _SocialRepository = SocialRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialDto> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
            {
                Social mappedSocial = _mapper.Map<Social>(request);
                Social createdSocial = await _SocialRepository.AddAsync(mappedSocial);
                CreatedSocialDto createdSocialDto = _mapper.Map<CreatedSocialDto>(createdSocial);
                return createdSocialDto;
            }
        }
    }
}
