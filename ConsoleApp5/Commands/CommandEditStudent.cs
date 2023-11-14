class CommandEditStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandEditStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.Write("Введите имя или фамилию студента, которого хотите исправить: ");
        List<Student> students = studentDB.Search(Console.ReadLine());

        for (int i = 0; i < students.Count; i++)
        {
            Student edStudent = students[i];
            Console.WriteLine("Укажите новое имя: ");
            edStudent.FirstName = Console.ReadLine();
            Console.WriteLine("Укажите новую фамилию: ");
            edStudent.LastName = Console.ReadLine();
            if (studentDB.Update(edStudent))
                Console.WriteLine("Студент создан!");
            else
                Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
        }
    }
}
