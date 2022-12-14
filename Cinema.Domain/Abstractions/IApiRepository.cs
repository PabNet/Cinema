using System;
using System.Threading.Tasks;

namespace Cinema.Domain.Abstractions
{
    public interface IApiRepository
    {
        public T ExecuteRequest<T>(Enum command, params object[] parameters);

    }
}