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

        Task<List<Contact>> AddContact(Contact contactData);

        Task<List<Contact>> UpdateContact(Contact contactData);

        Task<List<Contact>> DeleteContact(int contactId);

    }
}
