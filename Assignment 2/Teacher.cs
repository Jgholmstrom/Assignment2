using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace As2Lib
{
    public class Teacher : Person
    {
        private List<string> courses;
        private float salary;
        private string affiliation;

        public List<string> Courses
        {
            get { return courses; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("List of courses cannot be null");
                courses = value;
            }
        }
        public float Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new Exception("Salary cannot be less than to 0");
                salary = value;
            }
        }
        public string Affiliation
        {
            get { return affiliation; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Affiliation cannot be null");
                if (value == "")
                    throw new Exception("Affiliation cannot be empty");
                affiliation = value;
            }
        }

        public Teacher(string firstName, string lastName, string emailAddress, List<string> courses, float salary, string affiliation) : base(firstName, lastName, emailAddress)
        {
            Courses = courses;
            Salary = salary;
            Affiliation = affiliation;
        }

        public void addCourse(string course)
        {
            if (course == null)
                throw new ArgumentNullException("Course cannot be null");
            if (course == "")
                throw new Exception("Course cannot be empty");
            Courses.Add(course);
        }

        public void removeCourse(string course)
        {
            if (course == null)
                throw new ArgumentNullException("Course cannot be null");
            if (course == "")
                throw new Exception("Course cannot be empty");
            int removed = 0;
            for (int i = Courses.Count - 1; i >= 0; i--)
            {
                if (course.Equals(Courses[i]))
                {
                    Courses.RemoveAt(i);
                    removed++;
                }
            }
            if (removed == 0)
                throw new Exception(course + " does not exist");
        }

        public void changeCourse(string oldCourse, string newCourse)
        {
            if (oldCourse == null || newCourse == null)
                throw new ArgumentNullException("Course cannot be null");
            if (oldCourse == "" || newCourse == "")
                throw new Exception("Course cannot be empty");
            int changed = 0;
            for (int i = Courses.Count - 1; i >= 0; i--)
            {
                if (oldCourse.Equals(Courses[i]))
                {
                    Courses[i] = newCourse;
                    changed++;
                }
            }
            if (changed == 0)
                throw new Exception(oldCourse + " does not exist");
        }


        public string showCourses()
        {
            string courses = "";
            foreach (string c in Courses)
            {
                courses += c + "\n";
            }
            return courses;
        }
    }
}
