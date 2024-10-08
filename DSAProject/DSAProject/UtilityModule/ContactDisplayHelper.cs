using DSAProject.DataStorageModule;
using DSAProject.Models;

namespace DSAProject.UtilityModule
{
    public static class ContactDisplayHelper
    {
        /// <summary>
        /// Displays all contacts alphabetically by using the Trie structure
        /// </summary>
        /// <param name="trie"></param>
        public static void DisplayContactsAlphabetically(Trie trie)
        {
            List<Contact> contacts = trie.GetContactsByPrefix("");
            contacts.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts to display.");
                return;
            }

            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(FormatContact(contact));
            }
        }

        // Formats a contact for display
        public static string FormatContact(Contact contact)
        {
            return $"{contact.Name} : {contact.Phone}";
        }

        // Displays contacts based on a specific prefix (useful for partial matches or autocompletion)
        public static void DisplayContactsByPrefix(Trie trie, string prefix)
        {
            List<Contact> contacts = trie.GetContactsByPrefix(prefix);
            if (contacts.Count == 0)
            {
                Console.WriteLine($"No contacts found with prefix '{prefix}'.");
                return;
            }

            Console.WriteLine($"Contacts with prefix '{prefix}':");
            foreach (var contact in contacts)
            {
                Console.WriteLine(FormatContact(contact));
            }
        }
    }
}
