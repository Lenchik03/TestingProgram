using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.Tests
{
    public class MainMenuTests
    {
        StudentRepository db;

        [SetUp]
        public void Setup()
        {
            string file = "testStudents.txt";
            db = new StudentRepository(file);
            
        }

        [Test]
        public void MainMenu_WasCreateNewStudent()
        {
            var s = db.Students.Count;
            db.Students.Add(new Student { Name = "Пюрешка", Info = "Вкусная" });
            Assert.That(db.Students.Count, Is.EqualTo(s + 1));
        }
    }
}
