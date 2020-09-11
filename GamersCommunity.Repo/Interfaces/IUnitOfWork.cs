using System;
using System.Threading.Tasks;

namespace GamersCommunity.Repo.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAll();
    }
}
