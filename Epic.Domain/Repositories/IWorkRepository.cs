using System.Collections.Generic;
using Epic.Domain.Model;

namespace Epic.Domain.Repositories
{
    public interface IWorkRepository<T> where T : IWork
    {
        T Insert(T work, string user);
        IEnumerable<T> GetAll();
        T Get(string id);
        T Update(T work, string user);
        void Delete(string id);
    }
}