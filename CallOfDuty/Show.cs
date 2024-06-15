using CallOfDuty;

class Show : UserCommand
{
    private MainMenu mainMenu;
    StudentRepository studentRepository;

    public Show(MainMenu mainMenu, StudentRepository studentRepository)
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