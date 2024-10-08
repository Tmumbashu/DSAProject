# Phonebook Application Documentation

## Modules

The application is divided into three main modules:

### 1. Data Storage Module
- **Hash Table Module**: Manages insertion, searching, deletion, and updating of contacts using hashing based on contact names.
- **Trie Module**: Allows for prefix-based access by managing insertion, searching, and deletion of contacts

### 2. Operations Module
Contains the core functions that operate on the data, including insertion, searching, deletion, updating, and sorting contacts.

### 3. Utility Module
Provides helper functions such as sorting, input validation, and handling the display of contacts.

## Functions

### Data Storage Module
- **InitializeHashTable()**: Initializes the hash table for storing contacts.
- **InitializeTrie()**: Initializes the Trie for storing contacts.

### Operations Module
- **InsertContact(name, phone)**: Adds a new contact to both the Hash Table and Trie.
- **SearchContact(name)**: Searches for a contact by name in both the Hash Table and Trie.
- **DeleteContact(name)**: Deletes a contact by name from both the Hash Table and Trie.
- **UpdateContact(name, newPhone)**: Updates a contact’s phone number.
- **SortContacts()**: Sorts contacts alphabetically using the Trie’s inherent order or by sorting the hash table output.

### Utility Module
- **ValidatePhoneNumber(phone)**: Validates the format of a phone number.
- **DisplayContacts()**: Displays all contacts alphabetically by iterating through the Trie or Hash Table.

## Pseudocode

### 1. Insert Contact

```plaintext
FUNCTION InsertContact(root, name, phone)
    node ← root
    FOR each character in name
        IF node.children[character] IS NULL
            node.children[character] ← new TRIE_NODE
        END IF
        node ← node.children[character]
    END FOR
    node.isEndOfWord ← TRUE
    node.phone ← phone
END FUNCTION
```

### 2. Search Contact

```plaintext
FUNCTION SearchContact(root, name)
    node ← root
    FOR each character in name
        IF node.children[character] IS NULL
            RETURN "Contact Not Found"
        END IF
        node ← node.children[character]
    END FOR
    IF node.isEndOfWord IS TRUE
        RETURN node.phone
    ELSE
        RETURN "Contact Not Found"
    END IF
END FUNCTION
```

### 3. Display All Contacts

```plaintext
FUNCTION DisplayContacts(node, prefix)
    IF node.isEndOfWord IS TRUE
        PRINT prefix + " : " + node.phone
    END IF
    FOR each character in node.children
        IF node.children[character] IS NOT NULL
            DisplayContacts(node.children[character], prefix + character)
        END IF
    END FOR
END FUNCTION
```

Explanation: This function performs a depth-first traversal of the Trie, printing each contact in alphabetical order by recursively traversing all children nodes.

### 4. Delete Contact

```plaintext
FUNCTION DeleteContact(node, name, depth)
    IF node IS NULL
        RETURN FALSE
    END IF
    IF depth = LENGTH(name)
        IF node.isEndOfWord IS TRUE
            node.isEndOfWord ← FALSE
            RETURN node.hasNoChildren()  // Check if node can be deleted
        END IF
        RETURN FALSE
    END IF
    index ← name[depth]
    IF DeleteContact(node.children[index], name, depth + 1) IS TRUE
        node.children[index] ← NULL
        RETURN (node.hasNoChildren() AND NOT node.isEndOfWord)
    END IF
    RETURN FALSE
END FUNCTION
```

Explanation: The delete function is recursive. It goes down the Trie following the name, and once the end of the word is reached, it marks it as not an end and removes unnecessary nodes if they don't branch out.

### 5. Update Contact

```plaintext
FUNCTION UpdateContact(root, name, newPhone)
    node ← root
    FOR each character in name
        IF node.children[character] IS NULL
            RETURN "Contact Not Found"
        END IF
        node ← node.children[character]
    END FOR
    IF node.isEndOfWord IS TRUE
        node.phone ← newPhone
        RETURN "Contact updated successfully"
    ELSE
        RETURN "Contact Not Found"
    END IF
END FUNCTION
```

## Flowchart

1. **Start**: Begin with system initialization.
2. **Choose Operation**: User selects an operation (Insert, Search, Delete, Update).
3. **Insert Contact**: Adds a contact node in both the Hash Table and Trie.
4. **Search Contact**: Searches for the contact by name and displays the result.
5. **Delete Contact**: Removes contact nodes, handling shared nodes in the Trie if necessary.
6. **End**: End the flow after completing the operation.
