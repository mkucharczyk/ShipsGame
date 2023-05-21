using ShipsGame;
using ShipsGame.Domain;
using ShipsGame.Enums;
using ShipsGame.Helpers;

public class GameManager
{
    public GameBoard Board { get; }

    public GameManager(GameConfiguration configuration)
    {
        Board = new GameBoard(configuration);
        Board.PrintBoard();
    }
    
    public void GameLoop()
    {
        Console.WriteLine("Enter hit coordinates eg. A5");
        var coordinatesString = Console.ReadLine();
        var correctString = CoordinatesHelper.MapStringToCoordinates(coordinatesString, Board.Size, out var coordinates);
        HitResult hitResult;
        if (correctString)
            hitResult = Board.RegisterHit(coordinates);
        else
            hitResult = HitResult.Invalid;
        
        Console.Clear();
        Board.PrintBoard();
        Console.WriteLine($"Result of shot is: {hitResult}");
    }

    public bool IsGameOver()
    {
        return Board.AllShipsDestroyed();
    }

    public void GameOver()
    {
        Console.WriteLine("Good job! You have beaten the game");
    }
}