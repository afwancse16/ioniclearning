using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApi.Models;

namespace ContactApi.Repository
{
    public interface IContactsRepository
    {
        void Add(Contacts item);

        Task<IEnumerable<Contacts>> GetAllAsync(int skip, int take);

        Contacts Find(int key);

        void Remove(int Id);

        void Update(Contacts item);

        Task<int> CountRecordsAsync();
    }
}