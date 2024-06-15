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
            
            Console.WriteLine("Укажите имя...");
            string name = Console.ReadLine();
            Console.WriteLine("Укажите фамилию...");
            string info = Console.ReadLine();
            Student newStudent = mainMenu.Create(name, info);
            if (mainMenu.Update(newStudent))
                Console.WriteLine("Студент создан!");
            else
                Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
        }
    }
}
