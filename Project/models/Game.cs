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
      Room Aresenal = new Room("Aresenal", "You sneak into the room and are heard by a guard cleaning the weapons from the battle. The guard hears you and quickly turns, ending your time in Castle Grimtol. Game over, young warrior.", true);
      Room Undercroft = new Room("Undercroft", "Cautiously you make your way to the undercroft, a large room with many options to explore. Make sure you step lightly, guards are likely nearby!");
      Item Key = new Item("Golden Key", "This is a golden key. Hang onto it, you never know when it will come in handy.");
      Room Casemate = new Room("Casemate", "You are now in the gloomy casemate underneath the castle. Soldiers were able to barricade themselves inside the casemates for weeks, perhaps there is something they've left behind to help in the castle later on. There seems to be a door at the end of the corridoor, yet your hopes are dashed when you notice the lock.");
      Room PlaceofArms = new Room("PlaceofArms", "A new room! This is where troops most likely assemble before battles like the one you've known in the past. There is a stairwell in the corner that allows you access to the hallways of the castle. You made it! You won access to Grimtol!", true);

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
        if (CurrentRoom.Gameover)
        {
          playing = false;
        }
        Console.WriteLine($"{CurrentRoom.Description}");
        return;
      }
      else
      {
        Console.WriteLine("Nothing to see here except a stone wall.");
        Console.WriteLine(@"                    
        |>>>
        |
    _  _|_  _
   |;|_|;|_|;|
   \\.    .  /
    \\:  .  /
     ||:   |
     ||:.  |
     ||:  .|
     ||:   |
     ||: , |
     ||:   |
     ||: . |
    _||_   |
~    ~`---");
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
