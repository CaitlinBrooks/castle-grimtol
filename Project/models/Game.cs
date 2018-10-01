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
      Room Entry = new Room("Entry", "You find yourself in a dark cobblestone room, and through the light you see one door and the handle of what looks like another door.");
      Room Aresenal = new Room("Aresenal", @"You sneak into the room and are heard by a guard cleaning the weapons from the battle. The guard hears you and swiftly swings his sword, ending your time in Castle Grimtol.
____ ____ _  _ ____    ____ _  _ ____ ____ 
| __ |__| |\/| |___    |  | |  | |___ |__/ 
|__] |  | |  | |___    |__|  \/  |___ |  \ ", true);
      Room Undercroft = new Room("Undercroft", "Cautiously you make your way to the undercroft, a large room with many options to explore. Make sure you step lightly, guards are likely nearby!");
      Item Key = new Item("Golden Key", "This is a golden key. Hang onto it, you never know when it will come in handy.");
      Room Casemate = new Room("Casemate", "You are now in the gloomy cavern directly underneath the castle. Soldiers barricaded themselves inside casemates for weeks, perhaps there is something they've left behind to help you later on. There seems to be a door at the far end of the corridoor, yet your hopes are dashed when you notice the lock.", false, true);
      Item LockedExit = new Item("Locked Exit", "This door is locked, you're almost there young warrior. Try again using all that you have at your disposal...");
      Room PlaceofArms = new Room("PlaceofArms", @"A new room! There is a stairwell in the corner that allows you direct free access to the hallways of the castle. You made it inside without being seen! May you bring Dristol down once and for all.
_   _ ____ _  _    _ _ _ _ _  _ 
 \_/  |  | |  |    | | | | |\ | 
  |   |__| |__|    |_|_| | | \| ", true, false);

      //Entry -> Undercroft -> Casemate -> Place of Arms
      Entry.Exits.Add("east", Undercroft);
      Entry.Exits.Add("south", Aresenal);
      // Aresenal is game over, no win.
      Undercroft.Items.Add(Key); // needed to unlocked second to last room to gain access to final room.
      Undercroft.Exits.Add("west", Entry);
      Undercroft.Exits.Add("east", Casemate);
      Casemate.Exits.Add("west", Undercroft);
      Casemate.Items.Add(LockedExit); // needs the key to unlock
      Casemate.Exits.Add("east", PlaceofArms); // YOU WIN!

      CurrentRoom = Entry;

    }
    public void StartGame()
    {
      Setup();
      {
        Console.WriteLine("Welcome, young warrior. Let's see if you have what it takes to becomes a legend.");
        Console.WriteLine("What is your name, so that we can remember your quest?");
        Console.WriteLine(@"
 [][][] /""\ [][][]
  |::| /___\ |::|
  |[]|_|:::|_|[]|
  |::::::__:::::|
  |:::::/||\::::|
  |:#:::||||::#:|");
        var name = Console.ReadLine();
        // input = input.ToLower();
        CurrentPlayer = new Player(name);
        Console.WriteLine("Roughed up after fighting to gain access, you are determined as ever to kill Dristol Grim once and for all.");
        Console.WriteLine("In this dark cobblestone room, with the light between the stones, you see a door ahead and the handle of what could be another entrance.");
        while (playing)
        {
          GetUserInput();
        }
      }
    }
    public void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      //  && CurrentRoom.IsLocked = false)
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
  _________________
  ||:    :   .  , |
  ||:.  .   ,  :  |
  ||:  .  . ,,  : |
  ||: .  :  ;  :  |
  ||: ,     ..    |
  ||:   :  :  .   |
  ||: .  ,   :  ; |
  || .   ..  ..   |");
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
        Console.WriteLine(@"
   8 8          ,o.
  d8o8azzzzzzzzd   b
                `o'   ");
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
          System.Console.WriteLine($"You found a golden key. It is safely stored in your sachel for later on.");
        }
        return;
      }
    }
    public void UseItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(i => i.Name == itemName);
      if (item != null)
      {
        CurrentPlayer.Inventory.Remove(item);
        CurrentRoom.IsLocked = false;
      }
    }

    public void Reset()
    {
      Console.Clear();
      StartGame();
    }

    public void Quit()
    {
      Console.WriteLine(@"
____ ____ _  _ ____    ____ _  _ ____ ____ 
| __ |__| |\/| |___    |  | |  | |___ |__/ 
|__] |  | |  | |___    |__|  \/  |___ |  \ ");
      playing = false;
    }

    public void Help()
    {
      Console.WriteLine(@"Possible Commands:
      Go [direction]    Inventory
      Look              Take Item
      Use Item          Reset      
      Quit              Help
         ______________
        /             /|
       /             / |
      /____________ /  |
     | ___________ |   |
     ||           ||   |
     ||   neat!   ||   |
     ||           ||   |
     ||___________||   |
     |   _______   |  /
    /|  (_______)  | /
   ( |_____________|/
    \
.=======================.
| ::::::::::::::::  ::: |
| ::::::::::::::[]  ::: |
|   -----------     ::: |
`-----------------------'
                         ");
    }
  }
}
