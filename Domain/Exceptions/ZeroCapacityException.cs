using System;

namespace Domain.Exceptions
{
    public class ZeroCapacityException : Exception
    {
        public override string Message => $"La capacidad de una oficina tiene que ser mayor a cero.";

    }
}
