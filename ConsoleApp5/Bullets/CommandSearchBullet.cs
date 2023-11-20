using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

class CommandSearchBullet : CommandUser
{
    private StudentDB studentDB;

    public CommandSearchBullet(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск студента...");
        List<Student> students = studentDB.Search(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i+1}){students[i].LastName} {students[i].FirstName} {students[i].UID}");
        }


    }
}
