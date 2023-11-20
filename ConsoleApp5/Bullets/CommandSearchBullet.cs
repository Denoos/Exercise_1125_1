using ConsoleApp5.DB;

class CommandSearchBullet : CommandUser
{
    private BulletsDB bulletsDB;

    public CommandSearchBullet(BulletsDB bulletsDB)
    {
        this.bulletsDB = bulletsDB;
    }

    public override void Execute()
    {
        Console.Write("Поиск снаряда: ");
        List<Bullets> bullets = bulletsDB.Search(Console.ReadLine());
        for (int i = 0; i < bullets.Count; i++)
            Console.WriteLine($"{i + 1}).{bullets[i].Name} {bullets[i].massOfExplosivesInTNTEquivalent} {bullets[i].Weight} {bullets[i].BID}");
    }
}
