using System;

namespace Domain.Exceptions
{
    public class NotExistsOfficeExceptions : Exception
    {
        public override string Message => $"No existe Office en la Location ingresada";

    }
}
