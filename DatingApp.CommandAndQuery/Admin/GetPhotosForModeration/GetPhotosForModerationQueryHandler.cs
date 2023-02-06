using API.DTOs;
using DatingApp.CommandAndQuery.Queries;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.GetPhotosForModeration
{
    internal class GetPhotosForModerationQueryHandler : IQueryHandler<GetPhotosForModerationQuery, IEnumerable<PhotoForApprovalDto>>
    {
        private readonly IMediator _mediator;
        private readonly IAdminService _adminService;

        public GetPhotosForModerationQueryHandler(IMediator mediator, IAdminService adminService)
        {
            _adminService = adminService;
            _mediator = mediator;
        }

        public async Task<IEnumerable<PhotoForApprovalDto>> Handle(GetPhotosForModerationQuery request, CancellationToken cancellationToken)
        {
            return await _adminService.GetPhotosForModeration();
        }
    }
}
