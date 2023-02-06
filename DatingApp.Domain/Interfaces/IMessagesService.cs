using API.DTOs;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Domain.Interfaces
{
    public interface IMessagesService
    {
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task DeleteMessage(int id);
    }
}
