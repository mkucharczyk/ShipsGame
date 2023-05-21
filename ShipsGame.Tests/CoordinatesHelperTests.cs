
using ShipsGame.Helpers;

namespace ShipsGame.Tests;

public class CoordinatesHelperTests
{
    [TestCase("A5", 0, 4)]
    [TestCase("B6", 1, 5)]
    [TestCase("G3", 6, 2)]
    public void MapStringToCoordinates_When_StringIsCorrect_Returns_CorrectMappedCoordinates(string coordinatesString, int resultX, int resultY)
    {
        var success = CoordinatesHelper.MapStringToCoordinates(coordinatesString, 10, out var coordinates);

        Assert.True(success);
        Assert.That(coordinates.X, Is.EqualTo(resultX));
        Assert.That(coordinates.Y, Is.EqualTo(resultY));
    }
    
    [TestCase("AA7")]
    [TestCase("7A")]
    [TestCase("L12")]
    public void MapStringToCoordinates_When_StringIsIncorrect_Returns_False(string coordinatesString)
    {
        var success = CoordinatesHelper.MapStringToCoordinates(coordinatesString, 10, out var coordinates);

        Assert.False(success);
    }
}