using Ships;
using ShipsGame.Domain;

public class ShipGenerator
{
    private static Coordinates GenerateCoordinates(int maxX, int maxY)
    {
        Random random = new Random();

        return new Coordinates(random.Next(1, maxX), random.Next(1, maxY));
    }

    public static bool GetShipPlacementCoordinates(GameBoard board, int length, out List<Field> fields)
    {
        fields = new();
        foreach (Direction direction in GetRandomizedDirections())
        {
            fields.Clear();
            var coordinates = GenerateCoordinatesBasedOnDirection(board, length, direction);
            var field = board.GetField(coordinates.X, coordinates.Y);
            fields.Add(field);
            if (field.IsShipOnField())
                break;

            var collision = false;
            for (int i = 1; i < length; i++)
            {
                if (direction == Direction.Horizontal)
                {
                    field = board.GetField(coordinates.X + i, coordinates.Y);
                }
                else
                    field = board.GetField(coordinates.X, coordinates.Y + i);

                if (field.IsShipOnField())
                {
                    collision = true;
                    break;
                }

                fields.Add(field);
            }

            if (collision)
                break;
            
            return true;
        }

        return false;
    }

    private static Coordinates GenerateCoordinatesBasedOnDirection(GameBoard board, int length, Direction direction)
    {
        return direction == Direction.Horizontal
            ? GenerateCoordinates(board.Size - length, board.Size)
            : GenerateCoordinates(board.Size, board.Size - length);
    }

    private static IEnumerable<Direction> GetRandomizedDirections()
    {
        var directions = Enum.GetValues<Direction>().ToList();
        var rnd = new Random();
        return directions.OrderBy(item => rnd.Next());
    }
}