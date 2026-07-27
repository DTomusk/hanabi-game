using Hanabi;
using Xunit;

namespace HanabiTests;

public class DeckTests
{
    [Fact]
    public void Deck_ShouldContainCorrectNumberOfCards()
    {
        // Arrange
        var deck = new Deck();
        // Act
        int totalCards = deck.Cards.Count;
        // Assert
        Assert.Equal(50, totalCards); // 3x1, 2x2, 2x3, 2x4, 1x5 for each of the 5 colors
    }

    [Fact]
    public void Deck_ShouldContainCorrectDistributionOfCards()
    {
        // Arrange
        var deck = new Deck();
        // Act
        var cardCounts = new Dictionary<(int, CardColour), int>();
        foreach (var card in deck.Cards)
        {
            var key = (card.Value, card.Colour);
            if (!cardCounts.ContainsKey(key))
            {
                cardCounts[key] = 0;
            }
            cardCounts[key]++;
        }
        // Assert
        foreach (CardColour colour in Enum.GetValues(typeof(CardColour)))
        {
            Assert.Equal(3, cardCounts[(1, colour)]);
            Assert.Equal(2, cardCounts[(2, colour)]);
            Assert.Equal(2, cardCounts[(3, colour)]);
            Assert.Equal(2, cardCounts[(4, colour)]);
            Assert.Equal(1, cardCounts[(5, colour)]);
        }
    }
}
