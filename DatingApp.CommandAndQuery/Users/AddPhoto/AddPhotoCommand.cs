using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
