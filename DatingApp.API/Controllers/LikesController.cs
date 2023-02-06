using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Likes.AddLike;
using DatingApp.CommandAndQuery.Likes.GetUserLikes;
using DatingApp.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LikesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{username}")]
        public async Task<IActionResult> AddLike(string username)
        {
            await _mediator.Send(new AddLikeCommand(username));
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<LikeDto>>> GetUserLikes([FromQuery] LikesParams likesParams)
        {
            return Ok(await _mediator.Send(new GetUserLikesQuery(likesParams)));
        }
    }
}
