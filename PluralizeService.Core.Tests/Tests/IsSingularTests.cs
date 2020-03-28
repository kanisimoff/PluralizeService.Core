using Xunit;

namespace PluralizeService.Core.Tests
{
    public class IsSingularTests
    {
        [Theory]
        [InlineData("Email", true)]
        [InlineData("Emails", false)]
        [InlineData("company", true)]
        [InlineData("companies", false)]
        [InlineData("Crisis", true)]
        [InlineData("Crises", false)]
        [InlineData("Fungus", true)]
        [InlineData("Fungi", false)]
        [InlineData("bus", true)]
        [InlineData("buses", false)]
        public void WordIsSingular(string word, bool expected)
        {
            // Arrange
            bool actual = PluralizationProvider.IsSingular(word);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}