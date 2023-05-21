using System.Text;
using ShipsGame.Domain;
using ShipsGame.Enums;

namespace ShipsGame.Helpers;

public static class GameBoardPrinter
{
    public static void PrintBoard(this GameBoard board)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("  ");
        for (int y = 0; y < board.Size; y++)
        {
            stringBuilder.Append($"{y + 1} ");
        }

        stringBuilder.AppendLine();
        for (int x = 0; x < board.Size; x++)
        {
            string line = $"{CoordinatesHelper.IntToString(x)} ";

            for (int y = 0; y <  board.Size; y++)
            {
                var field = board.GetField(x, y);
                if (field.Hit == FieldHit.Unknown)
                    line += "0 ";
                else if (field.Hit == FieldHit.ShipHit)
                    line += "S ";
                else if (field.Hit == FieldHit.EmptyHit)
                    line += "X ";
            }

            stringBuilder.AppendLine(line);
        }

        Console.WriteLine(stringBuilder.ToString());
    }
}