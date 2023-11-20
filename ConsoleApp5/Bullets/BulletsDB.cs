using ConsoleApp5.DB;
using System.Collections.Generic;
using System.Text.Json;

class BulletsDB
{
    Dictionary<string, Bullets> bullets;

    public BulletsDB()
    {
        //load file (json)
        if (!File.Exists("bullet.json"))
            bullets = new Dictionary<string, Bullets>();
        else
            using (FileStream fs = new FileStream("bullet.json", FileMode.OpenOrCreate))
            {
                bullets = JsonSerializer.Deserialize<Dictionary<string, Bullets>>(fs);
            }

    }

    public List<Bullets> Search(string text)
    {
        List<Bullets> result = new();
        foreach (var bullet in bullets.Values)
        {
            if (bullet.Weight.Contains(text) ||
                    bullet.Name.Contains(text) ||
                    bullet.GunPowderPowerAtTrotillEquivalent.Contains(text) ||
                    bullet.Caliber.Contains(text))
                result.Add(bullet);
        }
        return result;
    }

    public bool Update(Bullets bullets)
    {
        if (!bullets.ContainsKey(bullets.Name))
            return false;
        bullets[bullets.Name] = bullets;
        Save();
        return true;
    }

    public Bullets Create()
    {
        Bullets newBullet = new Bullets();
        bullets.Add(newBullet.Name, newBullet);
        return newBullet;
    }

    public bool Delete(Bullets bullets)
    {
        if (!bullets.ContainsKey(bullets.Name))
            return false;
        bullets.Remove(bullets.Name);
        Save();
        return true;
    }

    void Save()
    {
        //save file (json)
        using (FileStream fs = new FileStream("bullet.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, bullets);
        }
    }
}
