using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MediaBazaar_ManagementSystem.Models;

namespace MediaBazaar_ManagementSystem.classes
{
    public class Employee
    {
        private int id, bsn;
        private string firstName, surName, userName, password, email, address, spouseName, phoneNumber, spousePhone;
        private bool active;
        private DateTime dateOfBirth;

        public Employee(int id, bool active, string firstName, string surName, string userName, string password, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone)
        {
            this.id = id;
            this.active = active;
            this.firstName = firstName;
            this.surName = surName;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.dateOfBirth = dateOfBirth;
            this.bsn = bsn;
            this.spouseName = spouseName;
            this.spousePhone = spousePhone;
        }

        public int Id
        {
            get { return id; }
        }

        public bool Active
        {
            get { return active; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string SpousePhone
        {
            get { return spousePhone; }
            set { spousePhone = value; }
        }

        public int Bsn
        {
            get { return bsn; }
            set { bsn = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SurName
        {
            get { return surName; }
            set { surName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string SpouseName
        {
            get { return spouseName; }
            set { spouseName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        //public enum Function
        //{
        //    Function functions;
        //}
    }
}
