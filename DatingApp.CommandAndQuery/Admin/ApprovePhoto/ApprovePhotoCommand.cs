using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.ApprovePhoto
{
    public class ApprovePhotoCommand : BaseCommand<PhotoDto>
    {
        public int PhotoId { get; set; }

        public ApprovePhotoCommand(int photoId)
        {
            PhotoId = photoId;
        }
    }
}
