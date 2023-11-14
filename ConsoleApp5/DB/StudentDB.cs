using System.Collections.Generic;
using System.Text.Json;

class StudentDB
{
    Dictionary<string, Student> students = new();

    public StudentDB()
    {
        if (File.Exists("students.json"))
            students = JsonSerializer.Deserialize<Dictionary<string, Student>>(File.ReadAllText("students.json"));//load file (json)
    }

    internal List<Student> Search(string text)
    {
        List<Student> result = new();
        foreach (var student in students.Values)
        {
            if (student.FirstName.Contains(text) ||
                    student.LastName.Contains(text))
                result.Add(student);
        }
        return result;
    }

    public bool Update(Student student)
    {
        if (!students.ContainsKey(student.UID))
            return false;
        students[student.UID] = student;
        Save();
        return true;
    }

    public Student Create()
    {
        Student newStudent = new Student { UID = Guid.NewGuid().ToString() };
        students.Add(newStudent.UID, newStudent);
        return newStudent;
    }

    public bool Delete(Student student)
    {
        if (!students.ContainsKey(student.UID))
            return false;
        students.Remove(student.UID);
        Save();
        return true;
    }

    void Save()
    {
        File.WriteAllText("students.json", JsonSerializer.Serialize(students));
        // save file (json)
    }
}
