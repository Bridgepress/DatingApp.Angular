using DatingApp.CommandAndQuery.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
