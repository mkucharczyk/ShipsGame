using ShipsGame.Enums;

namespace ShipsGame.Domain;

public abstract class Ship
{
    public abstract int Length { get; }
    
    public List<Field> fields { get; }
    
    public bool IsDestroyed => fields.All(f => f.Hit == FieldHit.ShipHit);
    
    public void AddFields(List<Field> fields)
    {
        foreach (var field in fields)
        {
            field.SetShip(this);
        }
        this.fields.AddRange(fields);
    }

    public Ship()
    {
        fields = new List<Field>(Length);
    }
}