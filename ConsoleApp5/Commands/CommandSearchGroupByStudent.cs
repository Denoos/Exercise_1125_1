using ConsoleApp5.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Commands
{
    class CommandSearchGroupByStudent : UserCommand
    {
        private StudentGroupDB studentGroupDB;

        public CommandSearchGroupByStudent(StudentGroupDB studentGroupDB)
        {
            this.studentGroupDB = studentGroupDB;
        }
        public override void Execute()
        {
            Console.WriteLine("Введите uid студента для поиска группы");
            Group group = studentGroupDB.GetGroupByStudent(Console.ReadLine());
                Console.WriteLine($" {group.Nomer} {group.UID}");

        }
    }
}
