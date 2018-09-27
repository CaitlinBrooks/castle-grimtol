using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool playing { get; private set; }

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
        default:
          System.Console.WriteLine("I don't recognize that command, please try again.");
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
      for (int i = 0; i < CurrentPlayer.Inventory.Count; i++) //IGame.CurrentPlayer?
      {
        Console.WriteLine($"You currently have one {CurrentPlayer.Inventory[i].Name} in your inventory.");
      }
      string choice = Console.ReadLine();
      GetUserInput();
    }
    public void TakeItem(string itemName)
    {
      // this.CurrentRoom = currentroom;
      Item item = CurrentRoom.Items.Find(i => i.Name == itemName);
      if (item != null)
      {
        {
          CurrentRoom.Items.Remove(item);
          CurrentPlayer.Inventory.Add(item);
        }
      }
    }
    public void UseItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(i => i.Name == itemName);
      if (item != null)
      {
        CurrentPlayer.Inventory.Remove(item);
      }
    }

    public void Reset()
    {
      throw new NotImplementedException();
    }

    public void Quit()
    {
      Console.WriteLine("You lost the game...");
      playing = false;
    }

    public void Help()
    {
      throw new NotImplementedException();
    }
  }
}