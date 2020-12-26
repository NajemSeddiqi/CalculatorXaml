using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string databaseName = "Contacts.db";
        private static readonly string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        internal static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
