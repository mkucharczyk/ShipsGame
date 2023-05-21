using ShipsGame.Domain;

namespace ShipsGame.Helpers;

public class CoordinatesHelper
{
    public static bool MapStringToCoordinates(string coordinatesString, int size, out Coordinates? coordinates)
    {
        coordinates = null;
        bool success = !(String.IsNullOrEmpty(coordinatesString) || coordinatesString.Length > 3);

        try
        {
            var x = coordinatesString[0] - 64 - 1;
            var y = (coordinatesString.Length == 3
                ? Int32.Parse(coordinatesString.Substring(1, 2))
                : coordinatesString[1] - 48) - 1;
            coordinates = new Coordinates(x, y);
        }
        catch (Exception)
        {
            success = false;
        }

        return success && (coordinates.X >= 0 && coordinates.X < size) && (coordinates.Y >= 0 && coordinates.Y < size);
    }

    public static char IntToString(int number)
    {
        return Convert.ToChar(65 + number);
    }
}