using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GreenMoneyTestTask.Tests
{
    public class CharactersCounterTests
    {
        CharactersCounter charCounter = new CharactersCounter();

        [Theory]
        [InlineData(new[] {'a', 'b', 'c', 'd', 'f'}, 'e')]
        [InlineData(new[] { 'O', 'Q', 'R', 'S' }, 'P')]
        void GetMissedCharacter_positive_scenario(IEnumerable<char> characters, char expectedMissedChar)
        {
            char missedChar = (char)0;
            var isFound = charCounter.TryGetMissedCharacter(characters, out missedChar);

            Assert.True(isFound);
            Assert.Equal(expectedMissedChar, missedChar);
        }

        [Theory]
        [InlineData(new[] { 'a', 'b', 'c', 'd', 'e' })]
        [InlineData(new[] { 'P', 'Q', 'R', 'S' })]
        [InlineData(new[] { 'X', 'Y', 'Z', 'A' })]
        [InlineData(new[] { 'y', 'z', 'a', 'b' })]
        void GetMissedCharacter_negative_scenario(IEnumerable<char> characters)
        {
            char missedChar = (char)0;
            var isFound = charCounter.TryGetMissedCharacter(characters, out missedChar);

            Assert.False(isFound);            
        }
    }
}
