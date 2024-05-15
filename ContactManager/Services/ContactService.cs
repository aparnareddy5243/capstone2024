using ContactManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Services
{
    public class ContactService
    {
        private List<Contact> _contacts = new List<Contact>();

        public ContactService()
        {
            // Seed with initial data
            _contacts.Add(new Contact { Id = 1, Name = "John Doe", Email = "john@example.com", Phone = "555-5555" });
            _contacts.Add(new Contact { Id = 2, Name = "Jane Doe", Email = "jane@example.com", Phone = "555-1234" });
        }

        public List<Contact> GetAll() => _contacts;
        public Contact GetById(int id) => _contacts.FirstOrDefault(x => x.Id == id);
        public void Add(Contact contact)
        {
            contact.Id = _contacts.Any() ? _contacts.Max(c => c.Id) + 1 : 1;
            _contacts.Add(contact);
        }
        public void Delete(int id)
        {
            var contact = GetById(id);
            if (contact != null)
                _contacts.Remove(contact);
        }
    }
}
