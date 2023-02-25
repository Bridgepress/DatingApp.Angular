using API.DTOs;
using API.Helpers;

namespace DatingApp.Domain.Interfaces
{
	public interface IMessagesService
	{
		Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
		Task DeleteMessage(int id);
	}
}
