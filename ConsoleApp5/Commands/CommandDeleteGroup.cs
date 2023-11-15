class CommandDeleteGroup : CommandGroup
{
    private GroupDB groupDB;

    public CommandDeleteGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.Write("Введите номер группы, которая не ходила на пары Дяди Пушкина: ");
        List<Group> groups = groupDB.SearchGroup(Console.ReadLine());
        for (int i = 0; i < groups.Count; i++)
            groupDB.DeleteGroup(groups[i]);
    }
}
