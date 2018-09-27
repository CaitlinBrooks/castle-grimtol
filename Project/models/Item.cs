using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Item : IItem
  {
    private string v;

    public Item(string v)
    {
      this.v = v;
    }

    public string Name { get; set; }
    public string Description { get; set; }
  }
}