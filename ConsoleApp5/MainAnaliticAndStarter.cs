class Program
{
    public static void Main()
    { 
        CommandManager commandManager = new CommandManager();
        BulletsDB bulletsDB = new BulletsDB();
        commandManager.RegisterCommand("Create", new CommandCreateBullet(bulletsDB));
        commandManager.RegisterCommand("Search", new CommandSearchBullet(bulletsDB));
        commandManager.RegisterCommand("Delete", new CommandDeleteBullet(bulletsDB));
        commandManager.RegisterCommand("Edit", new CommandEditBullet(bulletsDB));
        commandManager.Start();
    }
}
