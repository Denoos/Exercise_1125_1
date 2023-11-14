class CommandDeleteStudent : CommandStudent
{
    private StudentDB studentDB;

    public CommandDeleteStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.Write("Введите имя или фамилию студента, который не ходил на пары Дяди Пушкина: ");
        List<Student> students = studentDB.Search(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
            studentDB.Delete(students[i]);
    }
}
