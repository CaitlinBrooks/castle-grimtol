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
      Console.WriteLine($"What do you want to do, {CurrentPlayer.PlayerName} ?");
      string UserInput = Console.ReadLine();
      switch (UserInput.ToLower())
      {
        // split into an array to shorten the amount of "go" commands.
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
      playing = true;
      Room Entry = new Room("Entry", "You find yourself in a dark cobblestone room, and through the light you see one door ahead of you and the knob of one door to your right.");
      Room Aresenal = new Room("Aresenal", "You are in the aresenal room. Game over."); //need to fire off quit
      Room Undercroft = new Room("Undercroft", "You are in the Undercroft.");
      Item Key = new Item("Golden Key", "This is a key.");
      Room Casemate = new Room("Casemate", "You are in the Casemate.");
      Room PlaceofArms = new Room("PlaceofArms", "You are in the Place of Arms. You made it! You won!"); //Need to fire off quit.

      //Entry -> Undercroft -> Casemate -> Place of Arms
      Entry.Exits.Add("east", Undercroft);
      Entry.Exits.Add("south", Aresenal);
      // Aresenal is game over, no win.
      Undercroft.Items.Add(Key);
      Undercroft.Exits.Add("west", Entry);
      Undercroft.Exits.Add("east", Casemate);
      Casemate.Exits.Add("west", Undercroft);
      Casemate.Exits.Add("east", PlaceofArms); // YOU WIN!

      CurrentRoom = Entry;

    }
    public void StartGame()
    {
      Setup();
      {
        Console.WriteLine("Welcome, young warrior. You have entered the tunnel of Castle Grimtol.");
        Console.WriteLine("What is your name, so that we can remember your quest for years to come?");
        Console.WriteLine(@"
 [][][] /""\ [][][]
  |::| /____\ |::|
  |[]|_|::::|_|[]|
  |::::::__::::::|
  |:::::/||\:::::|
  |:#:::||||::#::|");
        var name = Console.ReadLine();
        // input = input.ToLower();
        CurrentPlayer = new Player(name);
        while (playing)
        {
          GetUserInput();
        }
      }
    }
    public void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        Console.WriteLine($"You are currently in {CurrentRoom.Name}");
        Console.WriteLine($"{CurrentRoom.Description}");
        Console.ReadLine();
        return;
      }
      else
      {
        Console.WriteLine("Nothing to see here except a stone wall.");
      }
    }
    public void Look()
    {
      Console.WriteLine($"You are currently in {CurrentRoom.Name}");
      Console.WriteLine($"{CurrentRoom.Description}");
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
      Console.Clear();
      StartGame();
      // playing = true;
    }

    public void Quit()
    {
      Console.WriteLine("You lost the game...");
      playing = false;
    }

    public void Help()
    {
      Console.WriteLine(@"Possible Commands:
      Go [direction]    Inventory
      Look              Take Item
      Use Item          Reset      
      Quit              Help
    .__________________________.
    | .___________________. |==|
    | | ................. | |  |
    | | :::::What Do::::: | |  |
    | | ::::::I Do?:::::: | |  |
    | | ::::::::::::::::: | |  |
    | | ::::::::::::::::: | |  |
    | | ::::::::::::::::: | |  |
    | | ::::::::::::::::: | | ,|
    | !___________________! |(c|
    !_______________________!__!
   /                            \
  /  [][][][][][][][][][][][][]  \
 /  [][][][][][][][][][][][][][]  \
(  [][][][][____________][][][][]  )
 \ ------------------------------ /
  \______________________________/
                         ");
    }
  }
}
