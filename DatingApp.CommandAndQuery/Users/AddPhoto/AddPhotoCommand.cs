using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using Microsoft.AspNetCore.Http;

namespace DatingApp.CommandAndQuery.Users.AddPhoto
{
	public class AddPhotoCommand : BaseCommand<PhotoDto>
	{
		public IFormFile File { get; }

		public AddPhotoCommand(IFormFile file)
		{
			File = file;
		}
	}
}
