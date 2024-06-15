using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty
{
    class Create: UserCommand
    {
        private MainMenu mainMenu;

        public Create(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public override void Execute()
        {
            
            Console.WriteLine("Укажите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Укажите фамилию");
            string info = Console.ReadLine();
            Student newStudent = mainMenu.Create(name, info);
            if (mainMenu.Update(newStudent))
                Console.WriteLine("Студент создан!");
            else
                Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
        }
    }
}
