using ShipsGame.Enums;

namespace ShipsGame.Domain;

public class GameBoard
{
    public int Size { get; }
    private Field[,] Fields { get; set; }
    public List<Ship> Ships { get; }

    public GameBoard(GameConfiguration config)
    {
        Size = config.Size;
        Ships = new List<Ship>(config.Battleships + config.Destroyers);

        InitializeFields();
        CreateShips(config);
    }

    private void CreateShips(GameConfiguration config)
    {
        for (int i = 0; i < config.Battleships; i++)
        {
            CreateShip<Battleship>();
        }

        for (int i = 0; i < config.Destroyers; i++)
        {
            CreateShip<Destroyer>();
        }
    }

    private void InitializeFields()
    {
        Fields = new Field[Size, Size];

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                Fields[x, y] = new Field(new Coordinates(x,y));
            }
        }
    }

    public HitResult RegisterHit(Coordinates coordinates)
    {
        if (coordinates.X > Size || coordinates.Y > Size)
            return HitResult.Invalid;

        var field = GetField(coordinates.X, coordinates.Y);

        if (field.Hit != FieldHit.Unknown)
            return HitResult.Invalid;

        if (field.IsShipOnField())
        {
            field.SetFieldHit(FieldHit.ShipHit);
            return field.Ship.IsDestroyed ? HitResult.Sink : HitResult.Hit;
        }

        field.SetFieldHit(FieldHit.EmptyHit);
        return HitResult.Miss;
    }

    private void PlaceShipOnBoard(Ship ship, List<Field> fields)
    {
        ship.AddFields(fields);
        Ships.Add(ship);
    }

    private void CreateShip<T>() where T : Ship, new()
    {
        var ship = new T();
        var canPlace = false;
        while (!canPlace)
        {
            canPlace = ShipGenerator.GetShipPlacementCoordinates(this, ship.Length, out var fields);
            if (canPlace)
            {
                PlaceShipOnBoard(ship, fields);
            }
        }
    }

    public Field GetField(int x, int y)
    {
        return Fields[x, y];
    }

    public bool AllShipsDestroyed()
    {
        return Ships.All(s => s.IsDestroyed);
    }
}