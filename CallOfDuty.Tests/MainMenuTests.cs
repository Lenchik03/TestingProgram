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
            string name = "Петр";
            string info = "Петров";
            mainMenu.Create(name, info);
            Assert.That(db.Students.Count, Is.EqualTo(s + 1));
        }

        [Test]
        public void MainMenu_WasUpdateStudent()
        {
            Student stud1 = db.Students.FirstOrDefault(s => s.Info == "test2");

            string name = "Станислав";
            string info = "Криповников";
            int index = 1;
            stud1 = mainMenu.UpdateStud(index, name, info);
            Assert.That(name, Is.EqualTo(stud1.Name));
            Assert.That(info, Is.EqualTo(stud1.Info));

        }

        [Test]
        public void MainMenu_WasDeleteStudent()
        {
            int countStudent = db.Students.Count;
            var stud1 = db.Students.FirstOrDefault(s => s.Info == "test2");
            mainMenu.Delete(stud1);
            int countStudent2 = db.Students.Count;
            Assert.That(countStudent, Is.Not.EqualTo(countStudent2));
        }

        [Test]
        public void MainMenu_WasDeleteAllDutysForAllStudents()
        {
            string folder = "test_dutys2";
            foreach (var student in db.Students)
            {
                string path = Path.Combine(Environment.CurrentDirectory, folder, $"{student.Info}.json");
                mainMenu.DeleteAllDutys(path);
                FileInfo n = new FileInfo(path);
                long m = n.Length;
                Assert.That(m, Is.EqualTo(0));
            }
        }
    }
}
