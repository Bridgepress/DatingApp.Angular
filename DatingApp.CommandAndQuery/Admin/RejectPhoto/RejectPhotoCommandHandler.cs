using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.RejectPhoto
{
    public class RejectPhotoCommandHandler : ICommandHandler<RejectPhotoCommand, PhotoDto>
    {
        private readonly IMediator _mediator;
        private readonly IAdminService _adminService;

        public RejectPhotoCommandHandler(IMediator mediator, IAdminService adminService)
        {
            _adminService = adminService;
            _mediator = mediator;
        }

        public async Task<PhotoDto> Handle(RejectPhotoCommand request, CancellationToken cancellationToken)
        {
            return await _adminService.RejectPhoto(request.PhotoId);
        }
    }
}
