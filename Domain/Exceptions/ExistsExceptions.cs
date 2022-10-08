using System;

namespace Domain.Exceptions
{
    public class ExistsExceptions : Exception
    {
        public override string Message => $"El registro que intenta crear ya existe";

    }
}
