using DatingApp.CommandAndQuery.Commands;

namespace DatingApp.CommandAndQuery.Users.SetMainPhoto
{
	public class SetMainPhotoCommand : BaseCommand
	{
		public int PhotoId { get; }

		public SetMainPhotoCommand(int photoId)
		{
			PhotoId = photoId;
		}
	}
}
