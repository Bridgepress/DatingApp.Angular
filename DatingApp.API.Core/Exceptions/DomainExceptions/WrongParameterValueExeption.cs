using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Domain.Exceptions.DomainExceptions
{
    public class InvalidParameterValueException : DomainException
    {
        public InvalidParameterValueException(object @object, string parameterName, string because)
            : base(HttpStatusCode.BadRequest, $"{because}\nparameter '{parameterName}' has invalid value", @object)
        {
        }
    }
}
