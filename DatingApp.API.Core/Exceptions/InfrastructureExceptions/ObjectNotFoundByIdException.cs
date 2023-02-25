using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Domain.Exceptions.InfrastructureExceptions
{
    public class ObjectNotFoundByIdException : InfrastructureExceptions
    {
        public ObjectNotFoundByIdException(Type objectType, int id) : base(HttpStatusCode.NotFound, $"Object of type {objectType} with id={id} not found")
        {

        }
    }
}
