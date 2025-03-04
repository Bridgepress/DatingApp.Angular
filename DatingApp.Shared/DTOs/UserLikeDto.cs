﻿using API.Entities;

namespace DatingApp.Shared.DTOs
{
    public class UserLikeDto
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }
        public AppUser TargetUser { get; set; }
        public int TargetUserId { get; set; }
    }
}
