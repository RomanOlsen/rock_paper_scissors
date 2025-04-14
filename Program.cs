using System.Threading.Tasks;

internal class Program
{

  // static int userWins = 0;
  // static int computerWins = 0;


  private static void Main()
  {
    Console.WriteLine("Let's play Rock Paper Scissors! 🤘");
    string userMove = ChooseMove();
    string computerMove = PickComputerMove();
    Console.WriteLine($"You chose {userMove}");
    Console.WriteLine($"Your opponent chose {computerMove}");
    string winner = DecideWinner(userMove, computerMove);
    if (winner == "Tie")
    {
      Console.WriteLine("It's a tie!");
    }
    else
    {
      Console.WriteLine($"And the winner is {winner}!");
    }

  }

  static string DecideWinner(string userMove, string computerMove)
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

    if (userInput != "r" && userInput != "p" && userInput != "s")
    {
      Console.Clear();
      Console.WriteLine("Please type r, p, or s to choose.");
      return ChooseMove(); // thanks to jeremy for adding the return for me
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
    if (option == "1" || option == "r")
    {
      return "rock";
    }
    if (option == "2" || option == "p")
    {
      return "paper";
    }
    if (option == "3" || option == "s")
    {
      return "scissors";
    }
    return "an error occured/something broke";
  }
}