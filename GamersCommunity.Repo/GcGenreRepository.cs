using GamersCommunity.Data.Models;
using GamersCommunity.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GamersCommunity.Repo
{
    public class GcGenreRepository : IGcGenreRepository
    {
        private readonly GamersCommunityContext _DbContext;
        public GcGenreRepository(GamersCommunityContext gamersCommunityContext)
        {
            _DbContext = gamersCommunityContext;
        }

        public void Create(GcGenreInformation gcClass)
        {
            string SqlQuery = $"INSERT INTO GcGenreInformation (Genre,CreatedBy,CreatedDate) VALUES ('{gcClass.Genre}','{gcClass.CreatedBy}','{gcClass.CreatedDate}')";
            _DbContext.Database.ExecuteSqlRaw(SqlQuery);
        }

        public void Delete(string Id)
        {
            string SqlQuery = $"DELETE GcGenreInformation WHERE Id='{Id}'";
            _DbContext.Database.ExecuteSqlRaw(SqlQuery);
        }

        public IEnumerable<GcGenreInformation> GetAllData()
        {
            string SqlQuery = $"SELECT * FROM GcGenreInformation";
            return _DbContext.GcGenreInformation.FromSqlRaw(SqlQuery);
        }

        public IEnumerable<GcGenreInformation> GetGenreByAlphabets(string Character)
        {
            string SqlQuery = $"SELECT * FROM GcGenreInformation WHERE Genre LIKE '{Character}%'";
            return _DbContext.GcGenreInformation.FromSqlRaw(SqlQuery);
        }

        public GcGenreInformation GetSingleById(string Id)
        {
            string SqlQuery = $"SELECT * FROM GcGenreInformation WHERE ID= '{Id}'";
            return _DbContext.GcGenreInformation.FromSqlRaw(SqlQuery).FirstOrDefaultAsync().Result;
        }

        public void Update(GcGenreInformation gcClass)
        {
            string SqlQuery = $"UPDATE  GcGenreInformation SET Genre='{gcClass.Genre}' WHERE  ID= '{gcClass.Id}'";
            _DbContext.Database.ExecuteSqlRaw(SqlQuery);
        }
    }
}
