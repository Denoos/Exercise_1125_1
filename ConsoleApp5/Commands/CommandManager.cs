class CommandManager
{
    Dictionary<string, CommandStudent> commands = new();
    Dictionary<string, CommandGroup> commandsToGroup = new();
    Dictionary<string, CommandAboutGroupAndStudent> commandsAboutGroupAndStudent = new();
    public void Start()
    {
        string command;
        do
        {
            Console.WriteLine("Введите команду");
            command = Console.ReadLine();
            TestCommand(command);
        }
        while (command != "exit");

    }

    void TestCommand(string? command)
    {
        if (commands.ContainsKey(command))
        {
            commands[command].Execute();
        }
        if (commandsToGroup.ContainsKey(command))
        {
            commandsToGroup[command].Execute();
        }
        if (commandsAboutGroupAndStudent.ContainsKey(command))
        {
            commandsAboutGroupAndStudent[command].Execute();
        }
    }

    public void RegisterCommandToGroup(string command, CommandGroup commandGroup)
    {
        commandsToGroup.Add(command, commandGroup);
    }
    public void RegisterCommand(string command, CommandStudent commandStudent)
    {
        commands.Add(command, commandStudent);
    }
    public void RegisterCommandAboutGroupAndStudent(string command, CommandAboutGroupAndStudent commandAboutGroupAndStudent)
    {
        commandsAboutGroupAndStudent.Add(command, commandAboutGroupAndStudent);
    }
}
