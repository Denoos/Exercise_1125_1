class CommandEditGroup : CommandGroup
{
    private GroupDB groupDB;

    public CommandEditGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.Write("Введите номер группы, которую хотите исправить: ");
        List<Group> groups = groupDB.SearchGroup(Console.ReadLine());

        for (int i = 0; i < groups.Count; i++)
        {
            Group edGroup = groups[i];
            Console.WriteLine("Укажите новый номер: ");
            edGroup.Number = Console.ReadLine();
            if (groupDB.UpdateGroup(edGroup))
                Console.WriteLine("Труппа создан!");
            else
                Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
        }
    }
}
