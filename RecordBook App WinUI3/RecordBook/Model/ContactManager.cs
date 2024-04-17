using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RecordBook.Model
{
    public class ContactManager
    {
        // Сделайте ContactManager синглтоном или используйте Dependency Injection для его инстанциирования
        public static ContactManager Instance { get; } = new ContactManager();

        public ObservableCollection<Contact> DatabaseContacts { get; }

        private ContactManager()
        {
            DatabaseContacts = new ObservableCollection<Contact>() {
            new Contact() { Email = "quam@aol.couk", Name = "Erich Fry" },
            // остальные контакты
        };
        }

        public void AddContact(Contact newContact)
        {
            DatabaseContacts.Add(newContact);
        }
    }
}
