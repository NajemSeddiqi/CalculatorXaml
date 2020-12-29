using DesktopContactApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact() { Name = "Name", Email = "Example@gmail.com", Phone = "45 458 74" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ContactControl)d;
            if (control != null)
            {
                control.nameTxtBlock.Text = (e.NewValue as Contact).Name;
                control.emailTxtBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTxtBlock.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
