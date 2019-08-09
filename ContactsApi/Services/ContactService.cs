using ContactsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApi.Services
{
    public class ContactService
    {
        private readonly IMongoCollection<Contacts> _contacts;

        public ContactService(IAddressBookDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _contacts = database.GetCollection<Contacts>(settings.ContactsCollectionName);
        }

        public List<Contacts> Get() =>
            _contacts.Find(contact => true).ToList();

        public Contacts Get(string id) =>
            _contacts.Find<Contacts>(contact => contact.Id == id).FirstOrDefault();

        public Contacts Create(Contacts contact)
        {
            _contacts.InsertOne(contact);
            return contact;
        }

        public void Update(string id, Contacts contactIn) =>
            _contacts.ReplaceOne(contact => contact.Id == id, contactIn);

        public void Remove(Contacts contactIn) =>
            _contacts.DeleteOne(contact => contact.Id == contactIn.Id);

        public void Remove(string id) =>
            _contacts.DeleteOne(contact => contact.Id == id);
    }
}