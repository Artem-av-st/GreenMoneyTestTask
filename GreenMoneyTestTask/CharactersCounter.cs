using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class CharactersCounter
    {
        /// <summary>
        /// Returns the missing letter in the array.
        /// </summary>
        /// <param name="characters">Collection of english letters</param>
        /// <param name="missedCharacter">Result</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if character is not an english letter</exception>
        /// <returns>Return false if letter is not found</returns>
        public bool TryGetMissedCharacter(IEnumerable<char> characters, out char missedCharacter)
        {
            missedCharacter = '\0';
            var missedCharacterIsFound = false;
            var enumerator = characters.GetEnumerator();
           
            if (enumerator.MoveNext())
            {
                var currentChar = enumerator.Current;
               
                while (enumerator.MoveNext())
                {
                    var nextChar = enumerator.Current;

                    if (!IsEnglishLetter(currentChar) || !IsEnglishLetter(nextChar))
                    {
                        throw new ArgumentOutOfRangeException("characters", "All input characters must be an English letters");
                    }

                    var nextExpectedChar = GetNextCharacter(currentChar);
                                        
                    if(nextExpectedChar != nextChar)
                    {
                        missedCharacterIsFound = true;
                        missedCharacter = nextExpectedChar;
                        break;
                    }

                    currentChar = nextChar;
                }                
            }

            return missedCharacterIsFound;
        }

        private char GetNextCharacter(char currentCharacter)
        {
            if (currentCharacter == 'z')
                return 'a';
            else if (currentCharacter == 'Z')
                return 'A';

            else
                return (char)(((int)currentCharacter) + 1);
        }

        private bool IsEnglishLetter(char letter)
        {
            return char.IsLetter(letter) && ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'));
        }
    }
}
