using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopContactApp.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Ignore]
        public string NamePlusMail { get { return Name + " " + Email; } }


        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
