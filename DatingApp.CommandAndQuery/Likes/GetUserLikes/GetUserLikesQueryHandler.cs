using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Queries;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Likes.GetUserLikes
{
    internal class GetUserLikesQueryHandler : IQueryHandler<GetUserLikesQuery, PagedList<LikeDto>>
    {
        private readonly IMediator _mediator;
        private readonly ILikeService _likeService;

        public GetUserLikesQueryHandler(IMediator mediator, ILikeService likeService)
        {
            _likeService = likeService;
            _mediator = mediator;
        }

        public async Task<PagedList<LikeDto>> Handle(GetUserLikesQuery request, CancellationToken cancellationToken)
        {
            return await _likeService.GetUserLikes(request.LikesParams);
        }
    }
}
