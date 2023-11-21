class Program
{
    public static void Main()
    { 
        CommandManager commandManager = new CommandManager();
        BulletsDB bulletsDB = new BulletsDB();
        commandManager.RegisterCommand("Create", "Создает новый снаряд", new CommandCreateBullet(bulletsDB));
        commandManager.RegisterCommand("Search", "Ищет снаряд", new CommandSearchBullet(bulletsDB));
        commandManager.RegisterCommand("Delete", "Удаляет снаряд", new CommandDeleteBullet(bulletsDB));
        commandManager.RegisterCommand("Edit", "Редактирует снаряд", new CommandEditBullet(bulletsDB));
        commandManager.Start();
    }
}
