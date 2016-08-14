using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using As2Lib;

namespace As2LibTest
{
    [TestFixture]
    class PersonTest
    {
        [Test]
        public void AddValidPerson()
        {
            Person p = new Person("Bob", "Hund", "bob@hund.com");
            Assert.AreEqual("Bob", p.FirstName);
            Assert.AreEqual("Hund", p.LastName);
            Assert.AreEqual("bob@hund.com", p.EmailAddress);

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPersonNullFirst()
        {
            Person p = new Person(null, "Hund", "bob@hund.com");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPersonNullLast()
        {
            Person p = new Person("Bob", null, "bob@hund.com");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPersonNullEmail()
        {
            Person p = new Person("Bob", "Hund", null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddPersonEmptyFirst()
        {
            Person p = new Person("", "Hund", "bob@hund.com");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddPersonEmptyLast()
        {
            Person p = new Person("Bob", "", "bob@hund.com");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddPersonEmptyEmail()
        {
            Person p = new Person("Bob", "Hund", "");
        }
    }
}
