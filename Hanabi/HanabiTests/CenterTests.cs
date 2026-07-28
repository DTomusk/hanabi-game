using Hanabi;
using Xunit;

namespace HanabiTests;

public class CenterTests
{
    [Fact]
    public void ShouldInitialise_PlayedCardsDictionary()
    {
        // Arrange & Act
        var center = new Center();

        // Assert
        foreach (CardColour colour in Enum.GetValues(typeof(CardColour)))
        {
            Assert.True(center.PlayedCards.ContainsKey(colour));
            Assert.Empty(center.PlayedCards[colour]);
        }
    }

    [Fact]
    public void PlayCard_ShouldReturnTrue_WhenPlayingValidCard()
    {
        // Arrange
        var center = new Center();
        var card = new Card(1, CardColour.Red);

        // Act
        var result = center.PlayCard(card);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void PlayCard_ShouldReturnFalse_WhenPlayingInvalidCard()
    {
        // Arrange
        var center = new Center();
        var card1 = new Card(1, CardColour.Red);
        var card2 = new Card(3, CardColour.Red);
        center.PlayCard(card1);

        // Act
        var result = center.PlayCard(card2);

        // Assert
        Assert.False(result);
    }
}
