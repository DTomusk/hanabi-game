namespace Hanabi;

public class Card
{
    public int Value { get; init; }
    public CardColour Colour { get; init; }

    // The information that has been given about this card
    public CardInformation Information { get; private set; }

    public Card(int value, CardColour colour)
    {
        Value = value;
        Colour = colour;
        Information = new CardInformation(0);
    }

    public void UpdateInformation(CardColour? colour, int? value, int moveNumber)
    {
        // If player doesn't have this information, update it
        if (colour.HasValue && colour.Value == Colour && Information.Colour == null)
        {
            Information.SetColourInformation(colour.Value, moveNumber);
        }
        if (value.HasValue && value.Value == Value && Information.Value == null)
        {
            Information.SetValueInformation(value.Value, moveNumber);
        }
    }

    public void PrintCard()
    {
        Console.WriteLine(Colour.ToString() + " " + Value.ToString());
        Information.PrintInformation();
    }
}

public enum CardColour
{
    Red,
    Blue,
    Green,
    Yellow,
    White
}
