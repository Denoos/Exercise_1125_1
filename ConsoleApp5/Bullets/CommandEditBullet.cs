using ConsoleApp5.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandEditBullet : CommandUser
{
    private BulletsDB bulletsDB;

    public CommandEditBullet(BulletsDB bulletsDB)
    {
        this.bulletsDB = bulletsDB;
    }
    public override void Execute()
    {
        Console.WriteLine("Поиск снаряда: ");
        List<Bullets> bullets = bulletsDB.Search(Console.ReadLine());
        for (int i = 0; i < bullets.Count; i++)
        {
            Console.WriteLine($"{i + 1}) Название: {bullets[i].Name}; Масса заряда в тротиловом эквиваленте: {bullets[i].massOfExplosivesInTNTEquivalent}; Масса: {bullets[i].Weight}; BID: {bullets[i].BID}");

            Console.Write("Укажите порядковый номер: ");
            int.TryParse(Console.ReadLine(), out int edit);
            if (bullets.Count > edit - 1)
            {
                Console.Write("Измените название: ");
                bullets[i].Name = Console.ReadLine();
                Console.Write("Измените вес: ");
                bullets[i].Weight = Console.ReadLine();
                Console.Write("Укажите мощность заряда в тротиловом эквиваленте: ");
                bullets[i].massOfExplosivesInTNTEquivalent = Console.ReadLine();
                if (bulletsDB.Update(bullets[i]))
                    Console.WriteLine("Снаряд отредактирован!");
                else
                    Console.WriteLine("Снаряд НЕ отредактирован!");
            }
        }
        

    }
}
