namespace Hanabi;

public record CardInformation
{
    public ColourInformation? Colour { get; private set; }
    public ValueInformation? Value { get; private set; }
    public int TurnDrawn { get; private set; }

    public CardInformation(int turnDrawn)
    {
        TurnDrawn = turnDrawn;
        Colour = null;
        Value = null;
    }

    public void SetColourInformation(CardColour colour, int turnLearned)
    {
        Colour = new ColourInformation(colour, turnLearned);
    }

    public void SetValueInformation(int value, int turnLearned)
    {
        Value = new ValueInformation(value, turnLearned);
    }
}

public record ColourInformation(CardColour Colour, int TurnLearned);

public record ValueInformation(int Value, int TurnLearned);
