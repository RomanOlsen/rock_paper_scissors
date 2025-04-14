using System.Text.Json;
using System.Threading.Tasks;

internal class Program
{

  static int userWins = 0;
  static int computerWins = 0;
  static int player1Wins = 0;
  static int player2Wins = 0;

  static void SaveGame()
  {

    SaveData save = new(userWins, computerWins);
    string saveData = JsonSerializer.Serialize(save);
    File.WriteAllText("saveGame.json", saveData);

  }

  static void LoadGame()
  {

    if (!File.Exists("saveGame.json")) return;
    string jsonString = File.ReadAllText("saveGame.json");

    SaveData data = JsonSerializer.Deserialize<SaveData>(jsonString);
    if (data != null)
    {
      userWins = data.UserWins;
      computerWins = data.ComputerWins;
    }

  }



  private static void Main()
  {
    string twoPlayer = EnableTwoPlayer();
    if (twoPlayer == "y")
    {
      TwoPlayer();
      return;
    }


    LoadGame();
    Console.Clear();
    Console.WriteLine("Let's play Rock Paper Scissors! 🤘");
    string userMove = ChooseMove();
    string computerMove = PickComputerMove();
    Console.Clear();
    Console.WriteLine($"You chose {userMove}");
    Console.WriteLine($"Your opponent chose {computerMove}");
    string winner = DecideWinner(userMove, computerMove);
    if (winner == "Tie")
    {
      Console.WriteLine("It's a tie!");
    }
    else if (winner == "you")
    {
      userWins++;
      Console.WriteLine($"And the winner is {winner}!");
    }
    else
    {
      computerWins++;
      Console.WriteLine($"And the winner is {winner}!");
    }
    Console.WriteLine($"Score: {userWins}-{computerWins}");
    SaveGame();
    bool playAgain = AskToPlayAgain();
    if (playAgain)
    {
      Main();
    }
  }

  private static string EnableTwoPlayer()
  {
    Console.WriteLine("Enable Two Player Mode? (y/n)");
    string userInput = Console.ReadLine();
    if (userInput != "y" && userInput != "n")
    {
      Console.Clear();
      Console.WriteLine("Hit y or n.");
      return EnableTwoPlayer();
    }
    return $"{userInput}";
  }

  private static bool AskToPlayAgain()
  {
    Console.WriteLine("Play again? (y/n)");
    string userInput = Console.ReadLine();
    if (userInput != "y" && userInput != "n")
    {
      Console.Clear();
      Console.WriteLine("Type y or n.");
      return AskToPlayAgain();
    }
    if (userInput == "y")
    {
      return true;
    }
    return false;
  }

  static string DecideWinner(string userMove, string computerMove) // NOTE computer move is player 2 on Two player mode
  {
    if (userMove == computerMove)
    {
      return "Tie";
    }
    // ANCHOR times when user wins
    if (userMove == "rock" && computerMove == "scissors")
    {
      return "you";
    }
    if (userMove == "paper" && computerMove == "rock")
    {
      return "you";
    }
    if (userMove == "scissors" && computerMove == "paper")
    {
      return "you";
    }
    return "the computer";
  }

  static string ChooseMove()
  {
    Console.WriteLine("Choose your fighter");
    Console.WriteLine("Rock (r)");
    Console.WriteLine("Paper (p)");
    Console.WriteLine("Scissors (s)");

    string userInput = Console.ReadLine();

    if (userInput != "r" && userInput != "p" && userInput != "s" && userInput != "rock" && userInput != "paper" && userInput != "scissors")
    {
      Console.Clear();
      Console.WriteLine("Please type r, p, or s to choose.");
      return ChooseMove();
    }
    string answer = FilterMove(userInput);
    return $"{answer}";
  }

  static string PickComputerMove()
  {
    int computerPick = new Random().Next(1, 4);
    string answer = FilterMove($"{computerPick}");
    return $"{answer}";
  }
  static string FilterMove(string option)
  {
    if (option == "1" || option == "r" || option == "rock")
    {
      return "rock";
    }
    if (option == "2" || option == "p" || option == "paper")
    {
      return "paper";
    }
    if (option == "3" || option == "s" || option == "scissors")
    {
      return "scissors";
    }
    return "an error occured/something broke";
  }
  private static void TwoPlayer()
  {
    Console.Clear();
    Console.WriteLine("Let's play Rock Paper Scissors TWO PLAYER 🤘");

    Console.WriteLine("PLAYER 1");
    string player1Move = ChooseMove();
    Console.Clear();
    Console.WriteLine("PLAYER 2");
    string player2Move = ChooseMove();
    Console.Clear();

    Console.WriteLine($"Player 1, you chose {player1Move}.");
    Console.WriteLine($"Player 2! You chose {player2Move}.");

    string winner = DecideWinner(player1Move, player2Move);
    if (winner == "Tie")
    {
      Console.WriteLine("It's a tie!");
    }
    else if (winner == "you") // you meaning player 1
    {
      player1Wins++;
      Console.WriteLine($"And the winner is PLAYER 1!");
    }
    else
    {
      player2Wins++;
      Console.WriteLine($"And the winner is PLAYER 2!");
    }

    Console.WriteLine($"Score: {player1Wins}-{player2Wins}");

    bool playAgain = AskToPlayAgain();
    if (playAgain)
    {
      TwoPlayer();
    }

  }
}

internal class SaveData
{
  public int UserWins { get; set; }
  public int ComputerWins { get; set; }

  public SaveData(int userWins, int computerWins)
  {

    UserWins = userWins;
    ComputerWins = computerWins;

  }
}