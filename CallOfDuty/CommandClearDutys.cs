using CallOfDuty;

internal class CommandClearDutys : UserCommand
{
    private MainMenu mainMenu;
    private StudentRepository studentRepository;

    public CommandClearDutys(MainMenu mainMenu, StudentRepository studentRepository)
    {
        this.mainMenu = mainMenu;
        this.studentRepository = studentRepository;
    }
    public override void Execute()
    {
        foreach (var student in studentRepository.Students)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "dutys", $"{student.Info}.json");
            if (File.Exists(path))
            mainMenu.DeleteAllDutys(path);
        }
        
        Console.WriteLine("Дежурства обнулены!!!");
    }
}