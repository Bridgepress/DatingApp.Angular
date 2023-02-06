using DatingApp.CommandAndQuery.Queries;
using DatingApp.Domain.Interfaces;
using DatingApp.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.GetUsersWithRoles
{
    public class GetUsersWithRolesQueryHandler : IQueryHandler<GetUsersWithRolesQuery, List<UsersWithRolesDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IAdminService _adminService;

        public GetUsersWithRolesQueryHandler(IMediator mediator, IAdminService adminService)
        {
            _adminService = adminService;
            _mediator = mediator;
        }

        public async Task<List<UsersWithRolesDTO>> Handle(GetUsersWithRolesQuery request, CancellationToken cancellationToken)
        {
            return await _adminService.GetUsersWithRoles();
        }
    }
}
