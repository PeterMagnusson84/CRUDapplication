using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactApplication.Models.Repositories
{
    public class EFRepository : ContactApplication.Models.Repositories.IRepository
    {
        contactsdatabaseEntities _entities = new contactsdatabaseEntities();


        public IEnumerable<Contact> GetContacts()
        {
            return _entities.Contacts.ToList();
        }

        public Contact GetContactById(int id)
        {
            return _entities.Contacts.Find(id);
        }

        public void InsertContact(Contact contact)
        {
            _entities.Contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contacts.Attach(contact);
            }

            _entities.Entry(contact).State = EntityState.Modified;
        }

        public void DeleteContact(Contact contact)
        {
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contacts.Attach(contact);
            }

            _entities.Contacts.Remove(contact);
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}