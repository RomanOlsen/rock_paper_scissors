using System.Threading.Tasks;

internal class Program
{
  private static void Main()
  {
    Console.WriteLine("Loading up Rock Paper Scissors game! 🤘");
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
      Console.WriteLine("Please type r, p, or s to choose.");
      return ChooseMove(); // thanks to jeremy for adding the return for me
    }


    return $"{userInput}";
  }

  static string PickComputerMove()
  {
    int computerPick = new Random().Next(1, 4);
    Console.WriteLine($"{computerPick}");
    return $"{computerPick}";
  }
}