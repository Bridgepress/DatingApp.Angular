using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Users.AddPhoto
{
    internal class AddPhotoCommandHandler : ICommandHandler<AddPhotoCommand, PhotoDto>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public AddPhotoCommandHandler(IMediator mediator, IUserService userService)
        {
            _userService = userService;
            _mediator = mediator;
        }

        public async Task<PhotoDto> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AddPhoto(request.File);
        }
    }
}
