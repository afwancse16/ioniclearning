using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApi.Context;
using ContactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsContext ctx;

        public ContactsRepository(ContactsContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(Contacts item)
        {
            ctx.Contacts.Add(item);
            ctx.SaveChanges();
        }

        public Contacts Find(int key)
        {
            return ctx.Contacts
                .Where(e => e.Id.Equals(key))
                .SingleOrDefault();
        }

        public async Task<IEnumerable<Contacts>> GetAllAsync(int skip, int take)
        {
            return await (ctx.Contacts.Include(i => i.Company).Include(i => i.JobTitle).OrderBy(i => i.Name).Skip(skip).Take(take)).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(int skip, int take)
        {
            return await (ctx.Companies.OrderBy(i => i.Name).Skip(skip).Take(take)).ToListAsync();
        }

        public async Task<int> CountRecordsAsync()
        {
            return await (ctx.Contacts).CountAsync();
        }

        public void Remove(int Id)
        {
            var itemToRemove = ctx.Contacts.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                ctx.Contacts.Remove(itemToRemove);
            ctx.SaveChanges();
        }

        public void Update(Contacts item)
        {
            var itemToUpdate = ctx.Contacts.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
            }
            ctx.Update(itemToUpdate);
            ctx.SaveChanges();
        }
    }
}