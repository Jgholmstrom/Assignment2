using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using As2Lib;

namespace As2LibTest
{
    [TestFixture]
    class StudentTest
    {

        [Test]
        public void AddValidStudent()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Assert.AreEqual("Bob", s.FirstName);
            Assert.AreEqual("Hund", s.LastName);
            Assert.AreEqual("bob@hund.com", s.EmailAddress);
            Assert.AreEqual(2012, s.StartYear);
            Assert.AreEqual("DSV", s.Program);
            Assert.AreEqual(new Dictionary<string, float>(), s.Credits);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddStudentZeroStartYear()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 0, "DSV", new Dictionary<string, float>());
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddStudentNegativeStartYear()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", -2012, "DSV", new Dictionary<string, float>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudentNullProgram()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, null, new Dictionary<string, float>());
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddStudentEmptyProgram()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "", new Dictionary<string, float>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudentNullDictionary()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", null);
        }

        [Test]
        public void AddStudentPreExistingDictionary()
        {
            Dictionary<string, float> dict = new Dictionary<string, float>();
            dict.Add("OOP", 7.5F);
            dict.Add("Prog2", 0F);
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", dict);
            Assert.AreEqual(dict, s.Credits);
        }

        [Test]
        public void SetValidCredits()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Dictionary<string, float> d = new Dictionary<string, float>();
            s.setCredits("OOP", 7.5F);
            d.Add("OOP", 7.5F);
            Assert.AreEqual(d, s.Credits);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetCreditsNullKey()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Dictionary<string, float> d = new Dictionary<string, float>();
            s.setCredits(null, 7.5F);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SetCreditsEmptyKey()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Dictionary<string, float> d = new Dictionary<string, float>();
            s.setCredits("", 7.5F);
        }

        [Test]
        public void SetCreditsZeroValue()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Dictionary<string, float> d = new Dictionary<string, float>();
            s.setCredits("OOP", 0);
            d.Add("OOP", 0);
            Assert.AreEqual(d, s.Credits);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SetCreditsNegativeValue()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Dictionary<string, float> d = new Dictionary<string, float>();
            s.setCredits("OOP", -7.5F);
        }

        [Test]
        public void GetValidCredits()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            s.setCredits("OOP", 7.5F);
            Assert.AreEqual(7.5F, s.getCredits("OOP"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCreditsNull()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            s.getCredits(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void GetCreditsWrong()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Dictionary<string, float> d = new Dictionary<string, float>();
            s.getCredits("asd");
        }

        [Test]
        public void RemoveValidCredits()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            s.setCredits("OOP", 7.5F);
            s.removeCredits("OOP");
            Assert.AreEqual(0F, s.getCredits("OOP"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveCreditsNull()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            s.removeCredits(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void RemoveCreditsWrong()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            s.setCredits("OOP", 7.5F);
            s.removeCredits("Prog2");
        }

        [Test]
        public void ShowValidCredits()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            s.setCredits("OOP", 7.5F);
            s.setCredits("Prog2", 0F);
            Assert.AreEqual("OOP, 7,5hp\nProg2, 0hp\n", s.showCredits());
        }

        [Test]
        public void ShowCreditsEmpty()
        {
            Student s = new Student("Bob", "Hund", "bob@hund.com", 2012, "DSV", new Dictionary<string, float>());
            Assert.IsEmpty(s.showCredits());
        }
    }
}
