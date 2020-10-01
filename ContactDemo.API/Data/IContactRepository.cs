using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDemo.API.Data
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContacts();

        Task<Contact> GetContact(int contactId);

        Task AddContact(Contact contactData);

        Task UpdateContact(Contact contactData);

        Task DeleteContact(int contactId);

    }
}
