using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Welcome, young warrior. You have entered the tunnel of Castle Grimtol. You find yourself in a dark cobblestone room, and through the light you see one door ahead of you and the knob of one door to your right.");
      Game game = new Game();
      game.StartGame();
    }
  }
}
