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
          TakeItem("key");
          break;
        case "use item":
          UseItem("key");
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

      //Entry -> Undercroft -> Casemate -> Place of Arms
      Entry.Exits.Add("East", Undercroft);
      Entry.Exits.Add("South", Aresenal);
      // Aresenal is game over, no win.
      Undercroft.Items.Add(Key);
      Entry.Exits.Add("West", Entry);
      Entry.Exits.Add("East", Casemate);
      Entry.Exits.Add("West", Undercroft);
      Entry.Exits.Add("East", PlaceofArms); // YOU WIN!
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
      for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
      {
        Console.WriteLine($"You currently have one {CurrentPlayer.Inventory[i].Name} in your inventory.");
      }
      string choice = Console.ReadLine();
      GetUserInput();
    }
    public void TakeItem(string itemName)
    {
      throw new NotImplementedException();
    }
    public void UseItem(string itemName)
    {
      throw new NotImplementedException();
    }
    public void Help()
    {
      throw new NotImplementedException();
    }
    public void Reset()
    {
      throw new NotImplementedException();
    }
    public void Quit()
    {
      throw new NotImplementedException();
    }
  }
}