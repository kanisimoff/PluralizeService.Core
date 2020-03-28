using Xunit;

namespace PluralizeService.Core.Tests
{
    public class IsPluralTests
    {
        [Theory]
        [InlineData("Email", false)]
        [InlineData("Emails", true)]
        [InlineData("company", false)]
        [InlineData("companies", true)]
        [InlineData("Crisis", false)]
        [InlineData("Crises", true)]
        [InlineData("Fungus", false)]
        [InlineData("Fungi", true)]
        [InlineData("bus", false)]
        [InlineData("buses", true)]
        public void WordIsPlural(string word, bool expected)
        {
            // Arrange
            bool actual = PluralizationProvider.IsPlural(word);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}