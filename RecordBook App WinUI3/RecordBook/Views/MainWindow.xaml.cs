using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RecordBook.ViewModels;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RecordBook
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var filterText = textBox.Text;
            //ViewModel.FilterContacts(filterText);
        }

    }
}
