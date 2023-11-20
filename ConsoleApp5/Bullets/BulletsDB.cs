using ConsoleApp5.DB;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;

class BulletsDB
{
    Dictionary<string, Bullets> bullets;

    public BulletsDB()
    {
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
                    bullet.BID.Contains(text) ||
                    bullet.massOfExplosivesInTNTEquivalent.Contains(text))
                result.Add(bullet);
        }
        return result;
    }

    public bool Update(Bullets bullet)
    {
        if (!bullets.ContainsKey(bullet.BID))
            return false;
        bullets[bullet.BID] = bullet;
        Save();
        return true;
    }

    public Bullets Create()
    {
        Bullets newBullet = new Bullets { BID = Guid.NewGuid().ToString() };
        bullets.Add(newBullet.BID, newBullet);
        return newBullet;
    }

    public bool Delete(Bullets bullet)
    {
        if (!bullets.ContainsKey(bullet.BID))
            return false;
        bullets.Remove(bullet.BID);
        Save();
        return true;
    }

    void Save()
    {
        using (FileStream fs = new FileStream("bullet.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, bullets);
        }
    }
}
