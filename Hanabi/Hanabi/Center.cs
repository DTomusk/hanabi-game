namespace Hanabi;

public class Center
{
    public IDictionary<CardColour, IList<Card>> PlayedCards { get; private set; }

    public Center()
    {
        PlayedCards = new Dictionary<CardColour, IList<Card>>();
        foreach (CardColour colour in Enum.GetValues(typeof(CardColour)))
        {
            PlayedCards[colour] = new List<Card>();
        }
    }

    // Returns if move was legal
    public bool PlayCard(Card card)
    {
        var playedCards = PlayedCards[card.Colour];
        if (playedCards.Count == 0 && card.Value == 1)
        {
            playedCards.Add(card);
            return true;
        }
        else if (playedCards.Count > 0 && card.Value == playedCards.Last().Value + 1)
        {
            playedCards.Add(card);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetScore()
    {
        var score = 0;
        foreach (var list in PlayedCards)
        {
            foreach (var card in list.Value)
            {
                score += card.Value;
            }
        }

        return score;
    }
}
