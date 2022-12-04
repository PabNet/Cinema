using System;
using System.Threading.Tasks;

namespace Cinema.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}