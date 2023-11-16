using System.Collections.Generic;
using System.Text.Json;

class GroupDB
{
    Dictionary<string, Group> groups = new();

    public GroupDB()
    {
         if (File.Exists("group.json"))
             groups = JsonSerializer.Deserialize<Dictionary<string, Group>>(File.ReadAllText("group.json"));//load file (json)
         else File.Create("group.json");
    }

    internal List<Group> SearchGroup(string text)
    {
        List<Group> result = new();
        foreach (var group in groups.Values)
        {
            if (group.Number.Contains(text))
                result.Add(group);
        }
        return result;
    }

    public bool UpdateGroup(Group group)
    {
        if (!groups.ContainsKey(group.Number))
            return false;
        groups[group.Number] = group;
        Save();
        return true;
    }

    public Group CreateGroup()
    {
        Group newGroup = new Group { UID = Guid.NewGuid().ToString() };
        groups.Add(newGroup.UID, newGroup);
        return newGroup;
    }

    public bool DeleteGroup(Group group)
    {
        if (!groups.ContainsKey(group.UID))
            return false;
        groups.Remove(group.UID);
        Save();
        return true;
    }

    void Save()
    {
        File.WriteAllText("group.json", JsonSerializer.Serialize(groups));
        // save file (json)
    }
}
