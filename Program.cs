using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Welcome, young warrior. You have entered the tunnel of Castle Grimtol. Do you have what it takes to survive?");
      Game game = new Game();
      game.StartGame();
    }
  }
}
