namespace Hanabi;

public class CardInformation
{
    public CardColour? Colour { get; private set; }
    public int? Value { get; private set; }
    public int TurnDrawn { get; private set; }

    public CardInformation(int turnDrawn)
    {
        TurnDrawn = turnDrawn;
        Colour = null;
        Value = null;
    }

    public void SetColourInformation(CardColour colour)
    {
        Colour = colour;
    }

    public void SetValueInformation(int value)
    {
        Value = value;
    }
}
