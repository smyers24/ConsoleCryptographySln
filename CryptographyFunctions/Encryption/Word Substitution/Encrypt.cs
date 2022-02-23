using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CryptographyFunctions.Objects;

namespace CryptographyFunctions.Encryption
{
    public class Encrypt
    {
        private WordDictionary _dictionary;
        private Random _random;
        
        public Encrypt(WordDictionary dictionary)
        {
            _dictionary = dictionary;
            _random = new Random();
        }
        
        public string EncryptText(string text)
        {
            try
            {
                if (!ValidateInputString(text))
                {
                    return "The entered text is not valid for this encryption method";
                }

                var sb = new StringBuilder();

                foreach (var letter in text)
                {
                    var letterOptions = _dictionary.AvailableWords[char.ToUpperInvariant(letter)];
                    var selectedWord = letterOptions[_random.Next(0, letterOptions.Count - 1)].word;

                    sb.Append(char.ToUpper(selectedWord[0]) + selectedWord[1..]);
                }

                return sb.ToString();
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return string.Empty;
        }

        private bool ValidateInputString(string text)
        {
            return !text.Any(char.IsDigit);
        }
    }
}