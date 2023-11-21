using ConsoleApp5.DB;
using static System.Runtime.InteropServices.JavaScript.JSType;

class CommandManager
{
    private BulletsDB bulletsDB;
    Dictionary<string, (string discriptionOfCommand, CommandUser commandForDiscription)> listOfCommands = new();
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
        Console.WriteLine("Что хотите сделать(выберите цифру):" +
                " 1. Описание" +
                " 2. Выполнить" +
                " 3. Вывести все команды" +
                " 4. Вывести список");
        string d = Console.ReadLine();

        if (listOfCommands.ContainsKey(command))
        {
            if (d == "1")
                Console.WriteLine(listOfCommands[command].discriptionOfCommand);
            else if (d == "2")
                listOfCommands[command].commandForDiscription.Execute();
        }
        if (d == "3")
            RegisterCommand(Console.ReadLine(), Console.ReadLine(), new CommandSearchBullet(bulletsDB));
        if (d == "4")
            RegisterCommand(Console.ReadLine(), Console.ReadLine(), new CommandSearchBullet(bulletsDB));
    }

    public void RegisterCommand(string command, string discr, CommandUser commandBullets)
    {
        listOfCommands.Add(command, (discr, commandBullets));
    }
    public void ListCommands(string command, string discr, CommandUser commandBullets)
    {
       for (int i = 0; i < listOfCommands.Count; i++)
        { Console.WriteLine($"{listOfCommands[command].commandForDiscription} - {listOfCommands[command].discriptionOfCommand}"); }
    }
}
/*публичный метод Register, c аргументами типа string и (string, CommandUser), добавляет команду в словарь по указанному ключу. К команде есть краткое описание ее назначения.
публичный метод Execute, c аргументом типа string, запускает команду из словаря, если таковая имеется по указанному ключу
публичный метод ListCommands. Выводит на экран список команд в формате: команда - описание. Для этого нужно циклом перебрать все ключи в словаре и вывести значение ключа (команда) и строки descr из значения.
3) класс CommandInvoker. Внутри:
поле типа CommandManager
публичный конструктор, c аргументом типа CommandManager. Значение аргумента сохраняется в соответствующее поле
публичный метод Run. Запускает цикл пользовательских команд. Введенная пользователем команда передается в метод Execute на объекте типа CommandManager. 
Если введена команда exit - цикл прерывается и метод завершается
Если введена команда help - выводится список команд*/
