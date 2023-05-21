using ShipsGame.Domain;

namespace ShipsGame.Tests;

public class GameManagerTests
{
    private GameManager gameManager;
    private GameBoard board;

    [SetUp]
    public void Setup()
    {
        GameConfiguration gameConfiguration = new GameConfiguration()
        {
            Battleships = 0,
            Size = 10,
            Destroyers = 1
        };
        gameManager = new GameManager(gameConfiguration);
        board = gameManager.Board;
    }

    [Test]
    public void GameBoard_Should_HaveCorrectNumberOfShips()
    {
        var field1 = board.Ships[0].fields[0];
        var field2 = board.Ships[0].fields[1];
        var field3 = board.Ships[0].fields[2];
        var field4 = board.Ships[0].fields[3];
        board.RegisterHit(field1.Coordinates);
        board.RegisterHit(field2.Coordinates);
        board.RegisterHit(field3.Coordinates);
        board.RegisterHit(field4.Coordinates);
        
        Assert.True(gameManager.IsGameOver());
    }
}