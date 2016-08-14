using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using As2Lib;

namespace As2Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Tomas", "Ahlström", "tahlstrom@gmail.com");
            Console.WriteLine("Skapade ny person: {0} {1}, {2}, ID: {3}", p.FirstName, p.LastName, p.EmailAddress, p.Id);

            Teacher t = new Teacher("Helena", "Axelsson", "haxelsson@gmail.com", new List<string>(), 28000, "catcorp");
            Console.WriteLine("Skapade ny lärare: {0} {1}, {2}, ID: {3}", t.FirstName, t.LastName, t.EmailAddress, t.Id);
            Console.WriteLine("{0} tjänar {2}kr i månaden.", t.FirstName, t.LastName, t.Salary);
            t.addCourse("OOP");
            Console.Write(t.showCourses());
            t.addCourse("Prog2");
            Console.Write(t.showCourses());
            t.removeCourse("OOP");
            Console.Write(t.showCourses());

            Student s = new Student("Stefan", "Stendahl", "sstendahl@gmail.com", 2012, "DSV", new Dictionary<string, float>());
            Console.WriteLine("Skapade ny student: {0} {1}, {2}, ID: {3}", s.FirstName, s.LastName, s.EmailAddress, s.Id);
            s.setCredits("Prog2", 7.5F);
            Console.Write(s.showCredits());
            s.setCredits("Prog3", 7.5F);
            Console.Write(s.showCredits());
            s.removeCredits("Prog3");
            Console.Write(s.showCredits());
            
            Console.ReadKey();
        }
    }
}
