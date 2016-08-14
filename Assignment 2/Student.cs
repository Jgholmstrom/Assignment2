using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace As2Lib
{
    public class Student : Person
    {
        private int startYear;
        private string program;
        private Dictionary<string, float> credits;

        public int StartYear
        {
            get { return startYear; }
            set
            {
                if (value <= 0)
                    throw new Exception("Start year cannot be less than or equal to 0");
                startYear = value;
            }
        }
        public string Program 
        {
            get { return program; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Program cannot be null");
                if (value == "")
                    throw new Exception("Program cannot be empty");
                program = value;
            }
        }
        public Dictionary<string, float> Credits 
        {
            get { return credits; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Credits cannot be null");
                credits = value;
            }
        }

        public Student(string firstName, string lastName, string emailAddress, int startYear, string program, Dictionary<string, float> credits) : base(firstName, lastName, emailAddress)
        {
            StartYear = startYear;
            Program = program;
            Credits = credits;
        }

        public void setCredits(string course, float credits)
        {
            if (credits < 0)
                throw new Exception("Credits cannot be negative");
            if (course == "")
                throw new Exception("Course cannot be empty");
            Credits.Add(course, credits);
        }

        public float getCredits(string course)
        {
            float credits;
            bool exists = Credits.TryGetValue(course, out credits);
            if (!exists)
            {
                throw new Exception(course + " does not exist");
            }
            return credits;

        }

        public void removeCredits(string course)
        { 
            if (Credits.ContainsKey(course))
            {
                Credits[course] = 0;
            }
            else
            {
                throw new Exception(course + " does not exist");
            }
        }

        public string showCredits()
        {
            string credits = "";
            foreach (string c in Credits.Keys)
            {
                float v;
                Credits.TryGetValue(c, out v);
                credits += String.Format("{0}, {1}hp\n", c, v);
            }
            return credits;
        }
    }
}
