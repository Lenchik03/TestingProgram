using CallOfDuty;

internal class Update : UserCommand
{
    private MainMenu mainMenu;
    StudentRepository studentRepository;

    public Update(MainMenu mainMenu, StudentRepository studentRepository)
    {
        this.mainMenu = mainMenu;
        this.studentRepository = studentRepository;
    }

    public override void Execute()
    {

        Console.WriteLine("Редактирование студента...");
        //string search = Console.ReadLine();
        List<Student> searchStudent = studentRepository.Students;

        for (int i = 0; i < searchStudent.Count; i++)
        {
            Console.WriteLine($"{i + 1}  {searchStudent[i].Name}");
        }

        Console.WriteLine("Введите номер студента...");
        int num = int.Parse(Console.ReadLine()) - 1;
      //  Student edit = searchStudent[num];
        Console.WriteLine("Введите новое имя");
        string name = Console.ReadLine();
        
        

        Console.WriteLine("Введите новую фамилию");
        string info = Console.ReadLine();

        mainMenu.UpdateStud(num, name, info);



        //mainMenu.Update(edit);
    }
}