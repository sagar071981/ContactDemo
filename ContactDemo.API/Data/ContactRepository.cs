using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDemo.API.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext dbContext;

        public ContactRepository(ContactDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<Contact>> AddContact(Contact contactData)
        {
            dbContext.Contacts.Add(contactData);
            await dbContext.SaveChangesAsync();

            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<List<Contact>> DeleteContact(int contactId)
        {
            var contactToDelete = dbContext.Contacts.Single(e => e.Id == contactId);

            dbContext.Contacts.Remove(contactToDelete);
            await dbContext.SaveChangesAsync();

            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContact(int contactId)
        {
            return await dbContext.Contacts.Where(e => e.Id == contactId).FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<List<Contact>> UpdateContact(Contact contactData)
        {
            var contactToUpdate = dbContext.Contacts.Single(e => e.Id == contactData.Id);

            contactToUpdate.Name = contactData.Name;
            contactToUpdate.JobTitle = contactData.JobTitle;
            contactToUpdate.Company = contactData.Company;
            contactToUpdate.PhoneNo = contactData.PhoneNo;
            contactToUpdate.Email = contactData.Email;
            contactToUpdate.Address = contactData.Address;
            contactToUpdate.LastDateConnected = contactData.LastDateConnected;

            await dbContext.SaveChangesAsync();

            return await dbContext.Contacts.ToListAsync();
        }
    }
}
