using DSAProject.Models;

namespace DSAProject.DataStorageModule
{
    /// <summary>
    /// This class will allow prefix-based access for contacts and is helpful for autocompletion etc.
    /// </summary>
    public class Trie
    {
        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; }
            public bool IsEndOfWord { get; set; }
            public Contact Contact { get; set; }

            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                IsEndOfWord = false;
                Contact = null;
            }
        }

        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        // Initializes the trie
        public void InitializeTrie()
        {
            root = new TrieNode();
        }

        // Inserts a new contact into the trie
        public void InsertContact(Contact contact)
        {
            TrieNode node = root;
            foreach (char ch in contact.Name)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
            node.Contact = contact;
        }

        // Searches for a contact by name
        public Contact SearchContact(string name)
        {
            TrieNode node = root;
            foreach (char ch in name)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return null; // Contact not found
                }
                node = node.Children[ch];
            }
            return node.IsEndOfWord ? node.Contact : null;
        }

        // Deletes a contact by name
        public bool DeleteContact(string name)
        {
            return DeleteContactHelper(root, name, 0);
        }

        private bool DeleteContactHelper(TrieNode node, string name, int depth)
        {
            if (node == null)
            {
                return false;
            }

            if (depth == name.Length)
            {
                if (node.IsEndOfWord)
                {
                    node.IsEndOfWord = false;
                    return node.Children.Count == 0;
                }
                return false;
            }

            char ch = name[depth];
            if (DeleteContactHelper(node.Children[ch], name, depth + 1))
            {
                node.Children.Remove(ch);
                return node.Children.Count == 0 && !node.IsEndOfWord;
            }

            return false;
        }

        // Updates a contact's phone number
        public bool UpdateContact(string name, string newPhone)
        {
            TrieNode node = root;
            foreach (char ch in name)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false; // Contact not found
                }
                node = node.Children[ch];
            }
            if (node.IsEndOfWord)
            {
                node.Contact.UpdatePhone(newPhone);
                return true;
            }
            return false;
        }

        // Retrieves all contacts with a given prefix
        public List<Contact> GetContactsByPrefix(string prefix)
        {
            TrieNode node = root;
            List<Contact> contacts = new List<Contact>();

            foreach (char ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return contacts; // No contacts with this prefix
                }
                node = node.Children[ch];
            }

            GetAllContactsFromNode(node, contacts);
            return contacts;
        }

        private void GetAllContactsFromNode(TrieNode node, List<Contact> contacts)
        {
            if (node == null)
                return;

            if (node.IsEndOfWord)
            {
                contacts.Add(node.Contact);
            }

            foreach (var child in node.Children)
            {
                GetAllContactsFromNode(child.Value, contacts);
            }
        }
    }
}
