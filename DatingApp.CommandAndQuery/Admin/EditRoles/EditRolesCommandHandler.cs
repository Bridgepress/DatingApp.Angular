using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;

namespace DatingApp.CommandAndQuery.Admin.EditRoles
{
	public class EditRolesCommandHandler : ICommandHandler<EditRolesCommand, IList<string>>
	{
		private readonly IMediator _mediator;
		private readonly IAdminService _adminService;

		public EditRolesCommandHandler(IMediator mediator, IAdminService adminService)
		{
			_adminService = adminService;
			_mediator = mediator;
		}

		public async Task<IList<string>> Handle(EditRolesCommand request, CancellationToken cancellationToken)
		{
			return await _adminService.EditRoles(request.Username, request.Roles);
		}
	}
}
