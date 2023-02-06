using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.RejectPhoto
{
    public class RejectPhotoCommand : BaseCommand<PhotoDto>
    {
        public int PhotoId { get; }

        public RejectPhotoCommand(int photoId)
        {
            PhotoId = photoId;
        }
    }
}
