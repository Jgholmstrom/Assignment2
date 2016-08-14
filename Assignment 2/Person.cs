using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace As2Lib
{
    public class Person
    {
        static int id;
        private string firstName, lastName, emailAddress;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("First name cannot be null");
                if (value == "")
                    throw new Exception("First name cannot be empty");
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Last name cannot be null");
                if (value == "")
                    throw new Exception("Last name cannot be empty");
                lastName = value;
            }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Email cannot be null");
                if (value == "")
                    throw new Exception("Email cannot be empty");
                emailAddress = value;
            }
        }
        public int Id { get; set; }

        public Person(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Id = ++id;
        }
    }
}


