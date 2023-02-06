using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Likes.AddLike
{
    public class AddLikeCommandHandler : ICommandHandler<AddLikeCommand>
    {
        private readonly IMediator _mediator;
        private readonly ILikeService _likeService;

        public AddLikeCommandHandler(IMediator mediator, ILikeService likeService)
        {
            _likeService = likeService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(AddLikeCommand request, CancellationToken cancellationToken)
        {
            await _likeService.AddLike(request.Username);
            return Unit.Value;
        }
    }
}
