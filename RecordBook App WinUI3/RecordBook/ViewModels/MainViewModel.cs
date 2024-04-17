using System.Collections.Specialized;
using RecordBook.Commands;
using RecordBook.Model;
using RecordBook.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace RecordBook.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Contact> _сontacts;
        public ObservableCollection<Contact> Contacts
        {
            get => _сontacts;
            set
            {
                _сontacts = value;
                OnPropertyChanged(nameof(Contacts)); // Уведомляем UI об изменении списка
            }
        }

        public ICommand ShowWindowCommand { get; set; }


        public MainViewModel()
        {
            Contacts = new ObservableCollection<Contact>(ContactManager.Instance.DatabaseContacts);
            ContactManager.Instance.DatabaseContacts.CollectionChanged += DatabaseContacts_CollectionChanged;

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var newContactWindow = new AddContact();
            newContactWindow.Title = "Добавить контакт";
            newContactWindow.Activate(); // Для UWP
        }

        private void DatabaseContacts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Обновите ObservableCollection в MainViewModel, когда добавляется новый контакт
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var newItem in e.NewItems)
                {
                    Contacts.Add((Contact)newItem);
                }
            }
        }
    }
}
