using System;

namespace Domain.Exceptions
{
    public class ExistsOfficeExceptions : Exception
    {
        public override string Message => $"La office ingresada ya existe en Location";

    }
}
