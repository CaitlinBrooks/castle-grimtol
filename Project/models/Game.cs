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
      string UserInput = Console.ReadLine();
      if (Int32.TryParse(UserInput, out int choice))
      {
        switch (choice)
        {
          case 1:
            Go();
            break;
          case 2:
            Look();
            break;
          case 3:
            Inventory();
            break;
          case 4:
            TakeItem();
            break;
          case 5:
            UseItem();
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
      throw new System.NotImplementedException();
    }
    public void StartGame()
    {
      throw new System.NotImplementedException();
    }
    public void Go(string direction)
    {
      throw new System.NotImplementedException();
    }
    public void Look()
    {
      throw new System.NotImplementedException();
    }
    public void Inventory()
    {
      throw new System.NotImplementedException();
    }
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    public void Quit()
    {
      throw new System.NotImplementedException();
    }
    public void Help()
    {
      throw new System.NotImplementedException();
    }
    public void Reset()
    {
      throw new System.NotImplementedException();
    }
  }
}