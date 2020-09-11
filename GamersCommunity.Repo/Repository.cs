using GamersCommunity.Data.Models;
using GamersCommunity.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamersCommunity.Repo
{
    public class Repository <GcClass>: IRepository<GcClass> where GcClass : class
    {
        protected readonly GamersCommunityContext Context;

        public Repository(GamersCommunityContext context)
        {
            Context = context;
        }
        public void Create(GcClass gcClass)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GcClass> GetAllData()
        {
            throw new NotImplementedException();
        }

        public GcClass GetSingleById(string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(GcClass gcClass)
        {
            throw new NotImplementedException();
        }
    }
}
