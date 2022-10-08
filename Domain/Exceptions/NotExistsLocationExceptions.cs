using System;

namespace Domain.Exceptions
{
    public class NotExistsLocationExceptions : Exception
    {
        public override string Message => $"No existe Location con el nombre ingresado";

    }
}
