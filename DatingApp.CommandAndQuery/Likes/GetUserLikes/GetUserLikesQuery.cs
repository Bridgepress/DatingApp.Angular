using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Likes.GetUserLikes
{
    public class GetUserLikesQuery : IQuery<PagedList<LikeDto>>
    {
        public LikesParams LikesParams { get; }

        public GetUserLikesQuery(LikesParams likesParams)
        {
            LikesParams = likesParams;
        }
    }
}
