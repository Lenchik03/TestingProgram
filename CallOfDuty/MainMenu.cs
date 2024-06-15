using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CallOfDuty
{
    public class MainMenu
    {
        StudentRepository studentRepository;
        public MainMenu(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
            //    string file = "Students.txt";
            //    StudentRepository studentRepository = new StudentRepository(file);
        }

        public MainMenu(StudentRepository db, string folder) : this(db)
        {
            this.folder = folder;
            string path = Path.Combine(Environment.CurrentDirectory, folder);
            Directory.CreateDirectory(path);
        }

        Random rnd = new Random();
        private string folder = "";

        public Student Create(string name, string info)
        {
            Student newStudent = new Student();
            newStudent.Name = name;
            newStudent.Info = info;
            studentRepository.Students.Add(newStudent);
            return newStudent;
        }
        public Student UpdateStud(int index, string name, string info)
        {
            List<Student> searchStudent = studentRepository.Students;

            searchStudent[index].Name = name;
            searchStudent[index].Info = info;
            Update(searchStudent[index]);
           return searchStudent[index];
        }
        public bool Update(Student student)
        {
            if(!studentRepository.Students.Contains(student))
            {
               return false;
            }

            Save();
            return true;
        }

        public bool Delete(Student student)
        {
            if (!studentRepository.Students.Contains(student))
                return false;
            studentRepository.Students.Remove(student);
            Save();
            return true;
        }

        public List<Student> Show(string text)
        {
            List<Student> result = new();
            foreach (var student in studentRepository.Students)
            {
                if (student.Name.Contains(text) ||
                        student.Info.Contains(text))
                    result.Add(student);
            }
            return result;
        }

        public void Save()
        {
            List<Student> students = studentRepository.Students;
            string[] studs = new string[students.Count];
            for(int i = 0; i < students.Count; i++)
            {
                studs[i] = students[i].Info +";" + students[i].Name + ";"; 
            }
            string file = "Students.txt";
            File.WriteAllLines(file, studs);
        }

        public void RemoveAllDutys(string path)
        {    
            File.Delete(path);
            var fs = File.Create(path);
            fs.Close();
        }
    }
}
