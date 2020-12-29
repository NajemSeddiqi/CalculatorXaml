using DesktopContactApp.Api;
using DesktopContactApp.Models;
using System.Windows;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private readonly Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;
            nameTxtBox.Text = contact.Name;
            emailTxtBox.Text = contact.Email;
            phoneTxtBox.Text = contact.Phone;

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTxtBox.Text;
            contact.Email = emailTxtBox.Text;
            contact.Phone = phoneTxtBox.Text;
            using (var conn = DatabaseConnection.Connection())
            {
                conn.Update(contact);
            }

            Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = DatabaseConnection.Connection())
            {
                conn.Delete(contact);
            }

            Close();
        }
    }
}
