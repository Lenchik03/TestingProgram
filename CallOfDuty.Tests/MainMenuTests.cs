using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
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
            string file = "DeleteTest.txt";
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
           
            string name = "Станислав";
            string info = "Криповников";
            int index = 1;
            var newStud = mainMenu.UpdateStud(index, name, info);
            Assert.That(name, Is.EqualTo(newStud.Name));
            Assert.That(info, Is.EqualTo(newStud.Info));

        }

        [Test]
        public void MainMenu_WasDeleteStudent()
        {
            var stud1 = db.Students.FirstOrDefault(s => s.Info == "test2");
            var m = mainMenu.Delete(stud1);

            Assert.That(true, Is.EqualTo(m));
        }

        [Test]
        public void MainMenu_WasDeleteAllDutysForAllStudents()
        {
            string folder = "test_dutys2";
            StudentDuty studentDuty = new StudentDuty(db, folder);
            
            List<DateTime> dutys0 = null;
            List<DateTime> dutys = new List<DateTime>();
            foreach (var student in db.Students)
            {
                string path = Path.Combine(Environment.CurrentDirectory, folder, $"{student.Info}.json");
                mainMenu.DeleteAllDutys(path);
                var n= new FileInfo(path);
                var m = n.Length;
                //using (var fs = File.OpenRead(path))
                //    dutys = JsonSerializer.Deserialize<List<DateTime>>(fs);
                Assert.That(m, Is.EqualTo(0));
            }
        }
    }
}
