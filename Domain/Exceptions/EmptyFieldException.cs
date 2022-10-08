using System;

namespace Domain.Exceptions
{
    public class EmptyFieldException : Exception
    {
        public override string Message => $"Uno o más campos ingresados son nulos o estan vacios";
    }
}
