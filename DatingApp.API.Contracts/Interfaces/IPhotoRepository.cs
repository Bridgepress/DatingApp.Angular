using API.Entities;

namespace DatingApp.Contracts.Repositories
{
	public interface IPhotoRepository
	{
		Task<IEnumerable<Photo>> GetUnapprovedPhotos();
		Task<Photo> GetPhotoById(int id);
		void RemovePhoto(Photo photo);
	}
}
