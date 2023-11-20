using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandDeleteStudent : CommandUser
{
    private StudentDB studentDB;

    public CommandDeleteStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск студента...");
        List<Student> students = studentDB.Search("");
        for (int i = 0; i < students.Count; i++)
            Console.WriteLine($"{i + 1}).{students[i].LastName} {students[i].FirstName} {students[i].UID}");

        Console.WriteLine("Укажите порядковый номер...");
        int.TryParse(Console.ReadLine(), out int nomer);
        if (students.Count > nomer - 1 && studentDB.Delete(students[nomer-1]))
        Console.WriteLine("Студент успешно вырезан!");
            else
            Console.WriteLine("Не удалось вырезать студента:(");

    }
}
