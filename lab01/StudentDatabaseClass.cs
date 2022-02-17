using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_OP
{
    internal class StudentDatabaseClass
    {
        private int ID;
        private string Name;
        private string PhoneNumber;

        public StudentDatabaseClass(int ID, string Name, string PhoneNumber)
        {
            this.ID = ID;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }

        public int getID() => ID;
        public string getName() => Name;
        public string getPhoneNumber() => PhoneNumber;

        public string AnEntry(int ID, string Name, string PhoneNumber)
        {
            string entry = $"{ID} - {Name} - {PhoneNumber}";
            return entry;
        }
    }
}
