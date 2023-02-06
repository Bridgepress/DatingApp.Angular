using DatingApp.CommandAndQuery.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Users.DeletePhoto
{
    public class DeletePhotoCommand : BaseCommand
    {
        public int PhotoId { get; }

        public DeletePhotoCommand(int photoId)
        {
            PhotoId = photoId;
        }
    }
}
