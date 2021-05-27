using Xunit;

namespace PluralizeService.Core.Tests
{
    public class PluralizeTests
    {
        [Theory]
        [InlineData("Email", "Emails")]
        [InlineData("company", "companies")]
        [InlineData("Project", "Projects")]
        [InlineData("Container", "Containers")]
        [InlineData("bus", "buses")]
        [InlineData("euro", "euros")]
        [InlineData("Euro", "Euros")]
        public void ShouldPluralizeWord(string word, string expected)
        {
            // Arrange
            string actual = PluralizationProvider.Pluralize(word);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
