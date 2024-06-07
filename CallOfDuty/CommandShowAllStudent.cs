using CallOfDuty;

internal class CommandShowAllStudent : UserCommand
{
    private MainMenu mainMenu;
    StudentRepository studentRepository;

    public CommandShowAllStudent(MainMenu mainMenu, StudentRepository studentRepository)
    {
        this.mainMenu = mainMenu;
        this.studentRepository = studentRepository;
    }

    public override void Execute()
    {
        int index = 1;
        foreach (var student in studentRepository.Students)
            Console.WriteLine($"#{index++} {student.Name} {student.Info}");
    }
}