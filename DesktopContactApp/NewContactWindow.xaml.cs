using DesktopContactApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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


            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.Insert(contact);
            }

            Close();
        }
    }
}
