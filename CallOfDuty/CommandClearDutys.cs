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
        mainMenu.DeleteAllDutys();
        Console.WriteLine("Дежурства обнулены!!!");
    }
}