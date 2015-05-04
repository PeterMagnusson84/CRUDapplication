using System;
using System.Collections.Generic;

namespace ContactApplication.Models.Repositories
{
    interface IRepository
    {
        Contact GetContactById(int id);
        IEnumerable<ContactApplication.Models.Contact> GetContacts();
        void Save();
        void InsertContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
