using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.RegularExpressions;

internal class StudentGroupDB
{
    public string group { get; set; }
    public string student { get; set; }
    internal StudentGroupDB() {  }
    Dictionary<string, Group> groups = JsonSerializer.Deserialize<Dictionary<string, Group>>(File.ReadAllText("groups.json"));
    Dictionary<string, Student> students = JsonSerializer.Deserialize<Dictionary<string, Student>>(File.ReadAllText("students.json"));

}