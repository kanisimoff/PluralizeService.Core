using Xunit;

namespace PluralizeService.Core.Tests.Tests
{
    public class SingularizeTests
    {
        [Theory]
        [InlineData("Emails", "Email")]
        [InlineData("companies", "company")]
        [InlineData("Projects", "Project")]
        [InlineData("Containers", "Container")]
        [InlineData("buses", "bus")]
        public void ShouldSingularizeWord(string word, string expected)
        {
            // Arrange
            string actual = PluralizationProvider.Singularize(word);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
