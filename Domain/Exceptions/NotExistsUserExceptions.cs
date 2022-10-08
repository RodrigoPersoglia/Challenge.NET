using System;

namespace Domain.Exceptions
{
    public class NotExistsUserExceptions : Exception
    {
        public override string Message => $"El usuario ingresado no existe";

    }
}
