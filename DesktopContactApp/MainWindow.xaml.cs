using DesktopContactApp.Api;
using DesktopContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDataBase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new NewContactWindow().ShowDialog();
            ReadDataBase();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBox = (TextBox)sender;
            //bool pred(Contact w) => w.Name.ToLower().Contains(txtBox.Text.ToLower())
            //                                || w.Email.ToLower().Contains(txtBox.Text.ToLower())
            //                                || w.Phone.Contains(txtBox.Text);
            Func<Contact, bool> pred = w => w.Name.ToLower().Contains(txtBox.Text.ToLower())
                                            || w.Email.ToLower().Contains(txtBox.Text.ToLower())
                                            || w.Phone.Contains(txtBox.Text);

            contactsListView.ItemsSource = contacts.Where(pred).ToList();
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (Contact)contactsListView.SelectedItem;
            if (selected != null)
                new ContactDetailsWindow(selected).ShowDialog();

            ReadDataBase();
        }

        private void ReadDataBase()
        {
            using (var connection = DatabaseConnection.Connection())
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().OrderBy(o => o.Name).ToList();
            }

            if (contacts != null)
                contactsListView.ItemsSource = contacts;
        }
    }
}
