using GamersCommunity.Data.Models;
using System.Collections.Generic;

namespace GamersCommunity.Repo.Interfaces
{
    public interface IGcGenreRepository : IRepository<GcGenreInformation>
    {
        IEnumerable<GcGenreInformation> GetGenreByAlphabets(string Character);
    }
}
