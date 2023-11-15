class CommandSearchGroup : CommandGroup
{
    private GroupDB groupDB;

    public CommandSearchGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.Write("Введите номер группы : ");
        List<Group> groups = groupDB.SearchGroup(Console.ReadLine());
        if (groups.Count == 0)
            Console.WriteLine("нема Труппы, на практику ушли))))))");
        else
            for (int i = 0; i < groups.Count; i++)
            { Console.WriteLine($"{i + 1}. {groups[i].Students} {groups[i].Number} UID: {groups[i].UID}"); }
    }
}