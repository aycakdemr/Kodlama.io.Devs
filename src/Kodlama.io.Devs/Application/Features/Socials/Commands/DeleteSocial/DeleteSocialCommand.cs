using Application.Features.Socials.Commands.DeleteSocial;
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

namespace Application.Features.Socials.Commands.DeleteSocial
{
    public class DeleteSocialCommand : IRequest<DeletedSocialDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int SocialId { get; set; }

        public class DeleteSocialCommandHandler : IRequestHandler<DeleteSocialCommand, DeletedSocialDto>
        {
            private readonly ISocialRepository _SocialRepository;
            private readonly IMapper _mapper;


            public DeleteSocialCommandHandler(ISocialRepository SocialRepository, IMapper mapper)
            {
                _SocialRepository = SocialRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSocialDto> Handle(DeleteSocialCommand request, CancellationToken cancellationToken)
            {

                Social mappedSocial = _mapper.Map<Social>(request);
                Social deletedSocial = await _SocialRepository.DeleteAsync(mappedSocial);
                DeletedSocialDto deletedSocialDto = _mapper.Map<DeletedSocialDto>(deletedSocial);
                return deletedSocialDto;
            }
        }
    }
}
