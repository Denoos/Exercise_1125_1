class CommandSearchStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandSearchStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.Write("Введите имя или фамилию студента: ");
        List<Student> students = studentDB.Search(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
        { Console.WriteLine($"{i + 1}. {students[i].FirstName} {students[i].LastName} UID: {students[i].UID}"); }
    }
}