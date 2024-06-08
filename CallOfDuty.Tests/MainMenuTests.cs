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
        MainMenu mainMenu;

        [SetUp]
        public void Setup()
        {
            string file = "testStudents.txt";
            db = new StudentRepository(file);
            mainMenu = new MainMenu(db);
            
        }

        [Test]
        public void MainMenu_WasCreateNewStudent()
        {
            var s = db.Students.Count;
            db.Students.Add(new Student { Name = "Пюрешка", Info = "Вкусная" });
            Assert.That(db.Students.Count, Is.EqualTo(s + 1));
        }

        [Test]
        public void MainMenu_WasUpdateStudent()
        {
            var stud1 = db.Students.FirstOrDefault(s => s.Info == "test2");
            var m = mainMenu.Update(stud1);

            Assert.That(true, Is.EqualTo(m));
        }

        [Test]
        public void MainMenu_WasDeleteStudent()
        {
            var stud1 = db.Students.FirstOrDefault(s => s.Info == "test2");
            var m = mainMenu.Delete(stud1);

            Assert.That(true, Is.EqualTo(m));
        }
    }
}
