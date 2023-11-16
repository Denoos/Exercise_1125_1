public class StudentGroupDB
{
    Dictionary<string, string> studentToGroup = new Dictionary<string, string>();
    Dictionary<string, List<string>> groupOfStudent = new Dictionary<string, List<string>>();

    private StudentDB studentDB;
    private GroupDB groupDB;

    StudentGroupDB(StudentDB studentDB, GroupDB groupDB)
    {
        this.studentDB = studentDB;
        this.groupDB = groupDB;
    }
    public void AddStudentToGroup(string studentUID, string groupUID)
    {
        studentToGroup.Add(studentUID, groupUID);
        if (groupOfStudent.ContainsKey(groupUID))
        {
            groupOfStudent[groupUID].Add(studentUID);
        }
        else
        {
            groupOfStudent.Add(groupUID, new List<string> { studentUID });
        }
        Console.WriteLine("Студент добавлен в Tруппу");
    }
    public void SearchGroupByStudent(string studentUID, string groupUID)
    {
        studentToGroup.Add(studentUID, groupUID);
        if (groupOfStudent.ContainsKey(groupUID))
        {
            groupOfStudent[groupUID].Add(studentUID);
        }
        else
        {
            groupOfStudent.Add(groupUID, new List<string> { studentUID });
        }
    }
}