class CommandSearchStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandSearchStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.Write("Введите имя студента: ");
        List<Student> students = new List<Student>();
        string studentData = Console.ReadLine();
        Console.WriteLine(DB.StudentDB.Search(studentData));
    }
}
