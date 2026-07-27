namespace Hanabi;

public record Card(int Value, CardColour Colour);

public enum CardColour
{
    Red,
    Blue,
    Green,
    Yellow,
    White
}
