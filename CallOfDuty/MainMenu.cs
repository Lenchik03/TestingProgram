using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        
        public Student Create()
        {
            Student newStudent = new Student();
            studentRepository.Students.Add(newStudent);
            return newStudent;
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

        public void Delete()
        {

        }

        public List<Student> ShowAll(string text)
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
    }
}
