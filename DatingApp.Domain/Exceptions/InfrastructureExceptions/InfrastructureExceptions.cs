using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Domain.Exceptions.InfrastructureExceptions
{
    public class InfrastructureExceptions : HttpResponseException
    {
        public InfrastructureExceptions(HttpStatusCode statusCode, string message = "", object @object = null) : base(statusCode, message, @object)
        {
        }
    }
}
