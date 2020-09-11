using System.Collections.Generic;

namespace GamersCommunity.Repo.Interfaces
{
    public interface IRepository <GcClass> where GcClass : class
    {
        IEnumerable<GcClass> GetAllData();
        GcClass GetSingleById(string Id);
        void Create(GcClass gcClass);
        void Update(GcClass gcClass);
        void Delete(string Id);
        
    }
}
