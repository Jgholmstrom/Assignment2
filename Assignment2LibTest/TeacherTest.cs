using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using As2Lib;

namespace As2LibTest
{
    [TestFixture]
    class TeacherTest
    {
        [Test]
        public void AddValidTeacher()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            Assert.AreEqual(new List<string>(), t.Courses);
            Assert.AreEqual(10000, t.Salary);
            Assert.AreEqual("HunDSV", t.Affiliation);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTeacherNullList()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", null, 10000, "HunDSV");
        }

        [Test]
        public void AddTeacherPreExistingList()
        {
            List<string> d = new List<string>();
            d.Add("OOP");
            d.Add("Prog2");
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", d, 10000, "HunDSV");
            Assert.AreEqual(d, t.Courses);
        }

        [Test]
        public void AddTeacherZeroSalary()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 0, "HunDSV");
            Assert.AreEqual(0, t.Salary);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddTeacherNegativeSalary()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), -10000, "HunDSV");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTeacherNullAffiliation()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddTeacherEmptyAffiliation()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "");
        }

        [Test]
        public void AddValidCourse()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            Assert.Contains("OOP", t.Courses);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCourseNull()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddCourseEmpty()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("");
        }

        [Test]
        public void RemoveValidCourse()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.removeCourse("OOP");
            CollectionAssert.DoesNotContain(t.showCourses(), "OOP");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveCourseNull()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.removeCourse(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void RemoveCourseEmpty()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.removeCourse("");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void RemoveCourseWrong()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.removeCourse("Prog2");
        }

        [Test]
        public void ChangeValidCourse()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.changeCourse("OOP", "Prog2");
            Assert.Contains("Prog2", t.Courses);
            CollectionAssert.DoesNotContain(t.Courses, "OOP");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeCourseOldNull()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.changeCourse(null, "Prog2");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeCourseNewNull()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.changeCourse("OOP", null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ChangeCourseOldEmpty()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.changeCourse("", "Prog2");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ChangeCourseNewEmpty()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.changeCourse("OOP", "");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ChangeCourseWrong()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            t.changeCourse("Prog2", "Prog3");
        }

        [Test]
        public void ShowValidCourses()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            t.addCourse("OOP");
            Assert.AreEqual("OOP\n", t.showCourses());
        }

        [Test]
        public void ShowCoursesEmpty()
        {
            Teacher t = new Teacher("Bob", "Hund", "bob@hund.com", new List<string>(), 10000, "HunDSV");
            Assert.IsEmpty(t.showCourses());
        }
    }
}
