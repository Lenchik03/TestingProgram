using CallOfDuty;

internal class CommandUpdateStudent : UserCommand
{
    private MainMenu mainMenu;
    StudentRepository studentRepository;

    public CommandUpdateStudent(MainMenu mainMenu, StudentRepository studentRepository)
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
            Console.WriteLine($"{i + 1}  {searchStudent[i].Info}");
        }

        Console.WriteLine("Введите номер студента...");
        int num = int.Parse(Console.ReadLine()) - 1;
        Student edit = searchStudent[num];
        Console.WriteLine("Введите новое имя");
        edit.Name = Console.ReadLine();

        Console.WriteLine("Введите новую фамилию");
        edit.Info = Console.ReadLine();




        mainMenu.Update(edit);
    }
}