using DesktopContactApp.Api;
using DesktopContactApp.Models;
using System.Windows;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save contact
            var contact = new Contact()
            {
                Name = nameTxtBox.Text,
                Email = emailTxtBox.Text,
                Phone = phoneTxtBox.Text
            };

            using (var connection = DatabaseConnection.Connection())
            {
                connection.Insert(contact);
            }

            Close();
        }
    }
}
