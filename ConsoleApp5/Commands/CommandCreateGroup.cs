using System.Text.RegularExpressions;

class CommandCreateGroup : CommandGroup
{
    private GroupDB groupDB;

    public CommandCreateGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Создание группы...");
        Group newGroup = groupDB.CreateGroup();
        Console.WriteLine("Укажите номер...");
        newGroup.Number = Console.ReadLine();
        if (!groupDB.UpdateGroup(newGroup))
            Console.WriteLine("Группа создана!");
        else
            Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
    }
}
