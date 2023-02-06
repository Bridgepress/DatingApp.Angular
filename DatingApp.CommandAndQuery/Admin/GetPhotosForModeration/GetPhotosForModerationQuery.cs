using API.DTOs;
using DatingApp.CommandAndQuery.Queries;

namespace DatingApp.CommandAndQuery.Admin.GetPhotosForModeration
{
    public class GetPhotosForModerationQuery : IQuery<IEnumerable<PhotoForApprovalDto>>
    {
        public GetPhotosForModerationQuery()
        {
        }
    }
}
