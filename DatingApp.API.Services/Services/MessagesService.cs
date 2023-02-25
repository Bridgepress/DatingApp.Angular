using API.DTOs;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using DatingApp.Contracts.Repositories;
using DatingApp.Domain.Exceptions.InfrastructureExceptions;
using DatingApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Domain.Services
{
	public class MessagesService : IMessagesService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private IHttpContextAccessor _httpContextAccessor;

		public MessagesService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task DeleteMessage(int id)
		{
			var username = _httpContextAccessor.HttpContext.User.GetUserName();
			var message = await _unitOfWork.MessageRepository.GetMessage(id);
			if (message.SenderUsername != username && message.RecipientUsername != username)
			{
				throw new HaventAccessException(System.Net.HttpStatusCode.Unauthorized);
			}
			if (message.SenderUsername == username)
			{
				message.SenderDeleted = true;
			}
			if (message.RecipientUsername == username)
			{
				message.RecipientDeleted = true;
			}
			if (message.SenderDeleted && message.RecipientDeleted)
			{
				_unitOfWork.MessageRepository.DeleteMessage(message);
			}
			await _unitOfWork.Complete();
		}

		public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
		{
			messageParams.Username = _httpContextAccessor.HttpContext.User.GetUserName();
			var messages = await _unitOfWork.MessageRepository.GetMessagesForUser(messageParams);
			_httpContextAccessor.HttpContext.Response.AddPaginationHeader(messages.CurrentPage, messages.PageSize,
				messages.TotalCount, messages.TotalPages);
			return messages;
		}
	}
}
