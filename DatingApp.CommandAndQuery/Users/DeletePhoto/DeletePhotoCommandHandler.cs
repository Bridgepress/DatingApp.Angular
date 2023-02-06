using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Users.DeletePhoto
{
    public class DeletePhotoCommandHandler : ICommandHandler<DeletePhotoCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public DeletePhotoCommandHandler(IMediator mediator, IUserService userService)
        {
            _userService = userService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeletePhoto(request.PhotoId);
            return Unit.Value;
        }
    }
}
