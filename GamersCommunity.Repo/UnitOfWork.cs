using GamersCommunity.Data.Models;
using GamersCommunity.Repo.Interfaces;
using System.Threading.Tasks;

namespace GamersCommunity.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GamersCommunityContext _gcContext;
        public GcGenreRepository gcGenreRepository { get; }

        public UnitOfWork(GamersCommunityContext gamersCommunityContext)
        {
            this._gcContext = gamersCommunityContext;
            this.gcGenreRepository = new GcGenreRepository(this._gcContext);
        }
        public async Task CommitAll()
        {
            await this._gcContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._gcContext.Dispose();
        }
    }
}
