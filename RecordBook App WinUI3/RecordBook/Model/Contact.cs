using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecordBook.Model
{
    // C# code-behind

    // The data template is defined to display a Contact object (class definition shown below), and the text
    // displayed is bound to the Contact object's Name attribute.

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Info => Name + " - " + Email;

    }
}
