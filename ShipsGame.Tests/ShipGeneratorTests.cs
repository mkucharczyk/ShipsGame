using ShipsGame.Domain;

namespace ShipsGame.Tests;

public class ShipGeneratorTests
{
    private GameBoard board;

    [SetUp]
    public void Setup()
    {
        GameConfiguration gameConfiguration = new GameConfiguration()
        {
            Battleships = 2,
            Size = 10,
            Destroyers = 2
        };
        board = new GameBoard(gameConfiguration);
    }

    [TestCase(4)]
    [TestCase(5)]
    public void GetShipPlacementCoordinates_Should_ReturnCorrectNumberOfFields(int length)
    {
        ShipGenerator.GetShipPlacementCoordinates(board, length, out var fields);

        Assert.That(fields.Count, Is.EqualTo(length));
        Assert.That(fields.All(f => f.IsShipOnField() == false));
    }
}