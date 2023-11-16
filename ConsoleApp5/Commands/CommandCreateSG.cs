using ConsoleApp5.DB;

namespace ConsoleApp5.Commands
{
    class CommandCreateSG : UserCommand
    {
        private StudentGroupDB studentGroupDB;

        public CommandCreateSG (StudentGroupDB studentGroupDB)
        {
            this.studentGroupDB = studentGroupDB;
        }

        public override void Execute()
    {
        Console.WriteLine("Введите uid студента...");
        string uidSt = Console.ReadLine();
            Console.WriteLine("Введите uid группы...");
            string uidGr = Console.ReadLine();
            if (studentGroupDB.AddS(uidSt, uidGr))
            {
                Console.WriteLine("Студент зачислен в группу!");
            }

    }
}
}