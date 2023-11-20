using ConsoleApp5.DB;

class CommandCreateBullet : CommandUser
{
    private BulletsDB newBullets;

    public CommandCreateBullet(BulletsDB bulletsDB)
    {
        this.newBullets = bulletsDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Создание снаряда.");
        Bullets newBullet = newBullets.Create();
        Console.Write("Укажите название: ");
        newBullet.Name = Console.ReadLine();
        Console.Write("Укажите мощность заряда в тротиловом эквиваленте: ");
        newBullet.massOfExplosivesInTNTEquivalent = Console.ReadLine();
        Console.Write("Укажите массу снаряда: ");
        newBullet.Weight = Console.ReadLine();
        if (newBullets.Update(newBullet))
            Console.WriteLine("Снаряд создан!");
        else
            Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна. Возможно такой снаряд уже существует.");
        newBullets.Save();
    }
}
