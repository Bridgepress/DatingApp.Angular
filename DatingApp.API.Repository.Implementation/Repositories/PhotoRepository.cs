using API.DTOs;
using API.Entities;
using DatingApp.Contracts;
using DatingApp.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;

        public PhotoRepository(DataContext context)
        {
            _context = context; 
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            return await _context.Photos
                 .IgnoreQueryFilters()
                 .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Photo>> GetUnapprovedPhotos()
        {
            return await _context.Photos
                .IgnoreQueryFilters()
                .Where(p => p.IsApproved == false)
                .ToListAsync();
        }

        public void RemovePhoto(Photo photo)
        {
            _context.Photos.Remove(photo);
        }
    }
}
