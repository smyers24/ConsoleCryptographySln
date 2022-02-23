using System.Collections.Generic;

namespace CryptographyFunctions.Objects
{
    public class WordDictionary
    {
        public Dictionary<char, List<WordDTO>> AvailableWords;

        public WordDictionary()
        {
            AvailableWords = new Dictionary<char, List<WordDTO>>();
        }
    }
}