using System;
using Doosy.Domain.Enum;
using Doosy.Framework.Domain;

namespace Doosy.Domain.Requests
{
    public class PersonRequest: RequestBase
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
    }
}
