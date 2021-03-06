﻿using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    /// <summary>
    /// Class for an employee object. Contains all relevant information that's also found in the employeeStorages' employee.
    /// </summary>
    public class Employee
    {
        private int id, bsn, function, contractHours;
        private string firstName, surName, userName, password, email, address, spouseName, phoneNumber, spousePhone, postalCode, city, preferredHours, workingDepartments;
        private bool active;
        private DateTime dateOfBirth;
        private float workingHours = 0;
        private List<string> permissions;
        private List<DateTime> notWorkingDays;

        public Employee(int id, bool active, string firstName, string surName, string userName, string password, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone, int function, string postalCode, string city, string preferredHours, string workingDepartments, int contractHours)
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
            this.function = function;
            this.postalCode = postalCode;
            this.city = city;
            this.preferredHours = preferredHours;
            this.workingDepartments = workingDepartments;
            this.contractHours = contractHours;
            this.notWorkingDays = new List<DateTime>();
        }

        #region Properties
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

        public int Function
        {
            get { return function; }
            set { function = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string PreferredHours
        {
            get { return preferredHours; }
            set { preferredHours = value; }
        }

        public string WorkingDepartments
        {
            get { return workingDepartments; }
            set { workingDepartments = value; }
        }

        public int ContractHours
        {
            get { return contractHours; }
            set { contractHours = value; }
        }

        public float WorkingHours
        {
            get { return workingHours; }
            set { workingHours = value; }
        }

        public List<string> Permissions
        {
            get { return permissions; }
            set { permissions = value; }
        }

        public List<DateTime> NotWorkingDays
        {
            get { return notWorkingDays; }
            set { notWorkingDays = value; }
        }
        #endregion
    }
}
