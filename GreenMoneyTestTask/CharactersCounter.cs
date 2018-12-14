using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class CharactersCounter
    {
        public bool TryGetMissedCharacter(IEnumerable<char> characters, out char missedCharacter)
        {
            missedCharacter = (char)0;
            var missedCharacterIsFound = false;
            var enumerator = characters.GetEnumerator();

            if (enumerator.MoveNext())
            {
                var currentChar = enumerator.Current;

                while (enumerator.MoveNext())
                {
                    var nextChar = enumerator.Current;

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
    }
}
