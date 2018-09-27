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
      switch (UserInput.ToLower())
      {
        case "go north":
          Go("north");
          break;
        case "go east":
          Go("east");
          break;
        case "go south":
          Go("south");
          break;
        case "go west":
          Go("west");
          break;
        case "look":
          Look();
          break;
        case "inventory":
          Inventory();
          break;
        case "take item":
          TakeItem("Key");
          break;
        case "use item":
          UseItem("Key");
          break;
        case "quit":
          Quit();
          break;
        case "help":
          Help();
          break;
        case "reset":
          Reset();
          break;
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