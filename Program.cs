// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
//Program.cs
using System;
    //Main program entry point
class Program
{
    static void Main(string[] args)
    {
        // Create two players.
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");

        // Initialize and set up the game.
        Game game = new Game (player1, player2);
        game.InitializeDeck();
        game.ShuffleDeck();
        game.DistributeCards();

        // Start the game.
        game.PlayGame();
    }

}
