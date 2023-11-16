using ConsoleApp5.Commands;
using ConsoleApp5.DB;
using System.Xml.Linq;

class Program
{
    public static void Main()
    { 
        CommandManager commandManager = new CommandManager();
        StudentDB studentDB = new StudentDB();
        GroupDB groupDB = new GroupDB();
        StudentGroupDB studentgroupDB = new StudentGroupDB(studentDB, groupDB);
        commandManager.RegisterCommand("CreateStudents", new CommandCreateStudent(studentDB));
        commandManager.RegisterCommand("SearchStudents", new CommandSearchStudent(studentDB));
        commandManager.RegisterCommand("DeleteStudents", new CommandDeleteStudent(studentDB));
        commandManager.RegisterCommand("EditStudents", new CommandEditStudent(studentDB));
        commandManager.RegisterCommand("CreateGroup", new CommandCreateGroup(groupDB));
        commandManager.RegisterCommand("SearchGroup", new CommandSearchGroup(groupDB));
        commandManager.RegisterCommand("AddStudentByGroup", new CommandCreateSG(studentgroupDB));
        commandManager.RegisterCommand("SearchStudentByGroup", new CommandSearchStudentByGroup(studentgroupDB));
        commandManager.RegisterCommand("SearchGroupByStudent", new CommandSearchGroupByStudent(studentgroupDB));

        commandManager.Start();
    }

}
