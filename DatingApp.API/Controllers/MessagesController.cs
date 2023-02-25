using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Messages.DeleteMessage;
using DatingApp.CommandAndQuery.Messages.GetMessagesForUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class MessagesController : BaseApiController
	{
		private readonly IMediator _mediator;

		public MessagesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<PagedList<MessageDto>>> GetMessagesForUser([FromQuery] MessageParams messageParams)
		{
			return await _mediator.Send(new GetMessagesForUserQuery(messageParams));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteMessage(int id)
		{
			await _mediator.Send(new DeleteMessageCommand(id));
			return Ok();
		}

	}
}
