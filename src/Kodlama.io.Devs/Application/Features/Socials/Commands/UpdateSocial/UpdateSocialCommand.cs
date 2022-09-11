using Application.Features.Socials.Commands.UpdateSocial;
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

namespace Application.Features.Socials.Commands.UpdateSocial
{
    public class UpdateSocialCommand : IRequest<UpdatedSocialDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int SocialId { get; set; }
        public class UpdateSocialCommandHandler : IRequestHandler<UpdateSocialCommand, UpdatedSocialDto>
        {
            private readonly ISocialRepository _SocialRepository;
            private readonly IMapper _mapper;


            public UpdateSocialCommandHandler(ISocialRepository SocialRepository, IMapper mapper)
            {
                _SocialRepository = SocialRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialDto> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
            {

                Social mappedSocial = _mapper.Map<Social>(request);
                Social updatedSocial = await _SocialRepository.DeleteAsync(mappedSocial);
                UpdatedSocialDto updatedSocialDto = _mapper.Map<UpdatedSocialDto>(updatedSocial);
                return updatedSocialDto;
            }
        }
    }
}
