using System;

namespace Cinema.Domain.Abstractions
{
    public interface IExternalServiceRepository
    {
        public void Execute(Enum command, params object[] parameters);
    }
}