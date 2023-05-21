using ShipsGame.Enums;

namespace ShipsGame.Domain;

public class Field
{
    public Coordinates Coordinates {get;}
    public Ship? Ship { get; private set;  }
    public FieldHit Hit { get; private set; }

    public Field(Coordinates coordinates)
    {
        Coordinates = coordinates;
    }

    public bool IsShipOnField()
    {
        return Ship != null;
    }

    public void SetFieldHit(FieldHit hit)
    {
        Hit = hit;
    }

    public void SetShip(Ship ship)
    {
        Ship = ship;
    }
}
