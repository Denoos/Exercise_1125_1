class CommandManager
{
    Dictionary<string, CommandUser> listOfCommands = new();
    (string discriptionOfCommand, CommandUser commandForDiscription) discription;
    public void Start()
    {
        string command;
        do
        {
            Console.Write("Введите команду: ");
            command = Console.ReadLine();
            TestCommand(command);
        }
        while (command != "exit");

    }

    void TestCommand(string? command)
    {
        if (listOfCommands.ContainsKey(command))
        {
            listOfCommands[command].Execute();
        }
    }

    public void RegisterCommand(string command, CommandUser commandBullets)
    {
        listOfCommands.Add(command, commandBullets);
    }
}
