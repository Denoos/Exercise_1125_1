using ConsoleApp5.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandDeleteBullet : CommandUser
{
    private BulletsDB bulletsDB;

    public CommandDeleteBullet(BulletsDB bulletsDB)
    {
        this.bulletsDB = bulletsDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск снаряда: ");
        List<Bullets> bullets = bulletsDB.Search(Console.ReadLine());
        for (int i = 0; i < bullets.Count; i++)
            Console.WriteLine($"{i + 1}) Название: {bullets[i].Name}; Масса заряда в тротиловом эквиваленте: {bullets[i].massOfExplosivesInTNTEquivalent}; Масса: {bullets[i].Weight}; BID: {bullets[i].BID}");

        Console.Write("Укажите порядковый номер: ");
        int.TryParse(Console.ReadLine(), out int nomer);
        if (bullets.Count > nomer - 1 && bulletsDB.Delete(bullets[nomer-1]))
        Console.WriteLine("Снаряд успешно удалён!");
            else
            Console.WriteLine("Не удалось удалить снаряд!");
        bulletsDB.Save();
    }
}
