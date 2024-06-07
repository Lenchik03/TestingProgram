using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty
{
    class CommandCreateStudent: UserCommand
    {
        private MainMenu mainMenu;

        public CommandCreateStudent(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public override void Execute()
        {
            Console.WriteLine("Создание студента...");
            Student newStudent = mainMenu.Create();
            Console.WriteLine("Укажите имя...");
            newStudent.Name = Console.ReadLine();
            Console.WriteLine("Укажите фамилию...");
            newStudent.Info = Console.ReadLine();
            if (mainMenu.Update(newStudent))
                Console.WriteLine("Студент создан!");
            else
                Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
        }
    }
}
