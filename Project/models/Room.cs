using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public bool Gameover { get; set; }
    public Dictionary<string, Room> Exits { get; set; }
    public bool IsLocked { get; set; }
    public Room(string name, string description, bool gameover = false, bool? IsLocked = false)
    {
      Name = name;
      Description = description;
      Exits = new Dictionary<string, Room>();
      Items = new List<Item>();
    }
  }
}
