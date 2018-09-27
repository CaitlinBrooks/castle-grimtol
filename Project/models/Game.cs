using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    Room IGame.CurrentRoom { get; set; }
    Player IGame.CurrentPlayer { get; set; }

    public void GetUserInput()
    {
      Console.WriteLine("");
      string UserInput = Console.ReadLine();
      if (Int32.TryParse(UserInput, out int choice))
      {
        switch (choice)
        {
          case 1:
            Go("North");
            Go("East");
            Go("South");
            Go("West");
            break;
          case 2:
            Look();
            break;
          case 3:
            Inventory();
            break;
          case 4:
            TakeItem("Key");
            break;
          case 5:
            UseItem("Key");
            break;
          case 6:
            Quit();
            break;
          case 7:
            Help();
            break;
          case 8:
            Reset();
            break;

        }
      }
    }

    public void Setup()
    {
      Room Entry = new Room("");
      Room Aresenal = new Room("");
      Room Undercroft = new Room("");
      Item Key = new Item("");
      Room Casemate = new Room("");
      Room PlaceofArms = new Room("");
    }
    public void StartGame()
    {

    }
    public void Go(string direction)
    {

    }
    public void Look()
    {

    }
    public void Inventory()
    {

    }
    public void TakeItem(string itemName)
    {

    }
    public void UseItem(string itemName)
    {

    }
    public void Quit()
    {

    }
    public void Help()
    {

    }
    public void Reset()
    {

    }
  }
}