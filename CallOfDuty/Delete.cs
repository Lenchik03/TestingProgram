using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty
{
    class Delete: UserCommand
    {
        private MainMenu mainMenu;
        private StudentRepository studentRepository;

        public Delete(MainMenu mainMenu, StudentRepository studentRepository)
        {
            this.mainMenu = mainMenu;
            this.studentRepository = studentRepository;
        }

        public override void Execute()
        {
            Console.WriteLine("Введите фамилию студента");
            string info = Console.ReadLine();
            var stud = studentRepository.Students.FirstOrDefault(s => s.Info == info);
            bool deleteStudent = mainMenu.Delete(stud);
            Console.WriteLine("Студент удален");
        }
    }
}
