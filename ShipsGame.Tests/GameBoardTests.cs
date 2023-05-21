using ShipsGame.Domain;
using ShipsGame.Enums;

namespace ShipsGame.Tests;

public class GameBoardTests
{
    private GameConfiguration gameConfiguration;
    private GameBoard board;

    [SetUp]
    public void Setup()
    {
        gameConfiguration = new GameConfiguration()
        {
            Battleships = 0,
            Size = 10,
            Destroyers = 1
        };
        board = new GameBoard(gameConfiguration);
    }

    [Test]
    public void GameBoard_Should_HaveCorrectNumberOfShips()
    {
        Assert.That(board.Ships.Count, Is.EqualTo(gameConfiguration.Battleships + gameConfiguration.Destroyers));
    }
    
    [Test]
    public void RegisterHit_When_CoordinatesBelongToShip_Should_MarkFieldAsHitAndReturnHit()
    {
        var field = board.Ships[0].fields[0];

        var hitResult = board.RegisterHit(field.Coordinates);
        
        Assert.That(board.Ships[0].fields[0].Hit == FieldHit.ShipHit);
        Assert.That(hitResult == HitResult.Hit);
    }
    
    [Test]
    public void RegisterHit_When_CoordinatesBelongToShipAndItWasLastField_Should_MarkFieldAsHitAndResultAsSink()
    {
        var field1 = board.Ships[0].fields[0];
        var field2 = board.Ships[0].fields[1];
        var field3 = board.Ships[0].fields[2];
        var field4 = board.Ships[0].fields[3];
        board.RegisterHit(field1.Coordinates);
        board.RegisterHit(field2.Coordinates);
        board.RegisterHit(field3.Coordinates);

        var hitResult = board.RegisterHit(field4.Coordinates);
        
        Assert.That(board.Ships[0].fields[0].Hit == FieldHit.ShipHit);
        Assert.That(hitResult == HitResult.Sink);
    }
    
    [Test]
    public void RegisterHit_When_HitSameCoordinatesTwice_Should_ReturnInvalid()
    {
        var field1 = board.Ships[0].fields[0];
        board.RegisterHit(field1.Coordinates);

        var hitResult = board.RegisterHit(field1.Coordinates);
        
        Assert.That(board.Ships[0].fields[0].Hit == FieldHit.ShipHit);
        Assert.That(hitResult == HitResult.Invalid);
    }
    
    [Test]
    public void RegisterHit_When_ThereIsNoShipOnField_Should_MarkFieldAsEmptyHitAndReturnMiss()
    {
        gameConfiguration = new GameConfiguration()
        {
            Battleships = 0,
            Size = 10,
            Destroyers = 0
        };
        board = new GameBoard(gameConfiguration);

        var hitResult = board.RegisterHit(new Coordinates(1,1));
        
        Assert.That(board.GetField(1, 1).Hit == FieldHit.EmptyHit);
        Assert.That(hitResult == HitResult.Miss);
    }
}
