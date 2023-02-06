using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.ApprovePhoto
{
    public class ApprovePhotoCommandHandler : ICommandHandler<ApprovePhotoCommand, PhotoDto>
    {
        private readonly IMediator _mediator;
        private readonly IAdminService _adminService;

        public ApprovePhotoCommandHandler(IMediator mediator, IAdminService adminService)
        {
            _adminService = adminService;
            _mediator = mediator;
        }

        public async Task<PhotoDto> Handle(ApprovePhotoCommand request, CancellationToken cancellationToken)
        {
            return await _adminService.ApprovePhoto(request.PhotoId);
        }
    }
}
