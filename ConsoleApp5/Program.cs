using System.Text.RegularExpressions;
using System.Xml.Linq;

class Program
{
    public static void Main()
    { 
        CommandManager commandManager = new CommandManager();
        StudentDB studentDB = new StudentDB();
        GroupDB groupDB = new GroupDB();
        commandManager.RegisterCommand("Create", new CommandCreateStudent(studentDB));
        // добавить команды:
        // Search - поиск студентов по имени/фамилии, должен выводиться UID
        commandManager.RegisterCommand("Search", new CommandSearchStudent(studentDB));
        // Delete - удаление выбранного студента (по UID или порядковому номеру в выведенном списке)
        commandManager.RegisterCommand("Delete", new CommandDeleteStudent(studentDB));
        // Edit - редактирование выбранного студента
        commandManager.RegisterCommand("Edit", new CommandEditStudent(studentDB));


        commandManager.RegisterCommandToGroup("Create Group", new CommandCreateGroup(groupDB));
        commandManager.RegisterCommandToGroup("Search Group", new CommandSearchGroup(groupDB));
        commandManager.RegisterCommandToGroup("Delete Group", new CommandDeleteGroup(groupDB));
        commandManager.RegisterCommandToGroup("Edit Group", new CommandEditGroup(groupDB));
        commandManager.Start();
    }

}
