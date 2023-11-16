using ConsoleApp5.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Commands
{
    class CommandCreateGroup : UserCommand
    {
        private GroupDB groupDB;

        public CommandCreateGroup(GroupDB groupDB)
        {
            this.groupDB = groupDB;
        }

        public override void Execute()
        {
            Console.WriteLine("Создание группы...");
            Group newGroup = groupDB.Create();
            Console.WriteLine("Укажите номер группы...");
            newGroup.Nomer = Console.ReadLine();

            if (groupDB.Update(newGroup))
                Console.WriteLine("Группа создана!");
            else
                Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
        }
    }
}
