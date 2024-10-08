using DSAProject.Models;

namespace DSAProject.DataStorageModule
{
    /// <summary>
    /// Custom hash table implementation to store contacts
    /// </summary>
    public class HashTable
    {
        private Dictionary<string, Contact> contacts;

        public HashTable()
        {
            contacts = new Dictionary<string, Contact>();
        }

        /// <summary>
        /// Clears the hash table
        /// </summary>
        public void InitializeHashTable()
        {
            contacts.Clear();
        }

        // Inserts a new contact into the hash table
        public void InsertContact(Contact contact)
        {
            if (!contacts.ContainsKey(contact.Name))
            {
                contacts[contact.Name] = contact;
            }
        }

        /// <summary>
        ///  Searches for a contact by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Contact SearchContact(string name)
        {
            if (contacts.TryGetValue(name, out Contact contact))
            {
                return contact;
            }
            return null; // Contact not found
        }

        /// <summary>
        ///  Deletes a contact by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteContact(string name)
        {
            return contacts.Remove(name);
        }

        /// <summary>
        /// Updates a contact's phone number
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newPhone"></param>
        /// <returns></returns>
        public bool UpdateContact(string name, string newPhone)
        {
            if (contacts.TryGetValue(name, out Contact contact))
            {
                contact.UpdatePhone(newPhone);
                return true;
            }
            return false; // Contact not found
        }

        /// <summary>
        /// Retrieves all contacts
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetAllContacts()
        {
            return new List<Contact>(contacts.Values);
        }
    }
}
