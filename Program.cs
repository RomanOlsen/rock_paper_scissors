using System.Threading.Tasks;

internal class Program
{
  private static void Main()
  {
    Console.WriteLine("Let's play Rock Paper Scissors! 🤘");
    string userMove = ChooseMove();
    string computerMove = PickComputerMove();
    Console.WriteLine($"You chose {userMove}");
    Console.WriteLine($"Your opponent chose {computerMove}");

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
    // if (computerPick == 1)
    // {
    //   return "rock";
    // }
    // if (computerPick == 2)
    // {
    //   return "paper";
    // }
    // if (computerPick == 3)
    // {
    //   return "scissors";
    // }
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