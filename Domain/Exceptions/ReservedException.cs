using System;

namespace Domain.Exceptions
{
    public class ReservedException : Exception
    {
        public override string Message => $"La oficina esta reservada en la fecha solicitada";
    }
}
