using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptographyFunctions.Encryption;
using CryptographyFunctions.Decryption;
using CryptographyFunctions.Enums;
using CryptographyFunctions.ExternalCalls;
using CryptographyFunctions.Objects;
using static System.Int32;

namespace ConsoleCryptography
{
    class Program
    {
        private static FindWords _findWords;
        private static WordDictionary _availableWords;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CryptographyDotNet.");
            _findWords = new FindWords();
            
            ChooseCypher();
        }

        static void ChooseCypher()
        {
            while (true)
            {
                Console.WriteLine("Please enter select your input to begin:");
                Console.WriteLine("[0] Word Substitution Cypher");
                Console.WriteLine("[1] or Exit to exit the program");

                TryParse(Console.ReadLine(), out var inputValue);
                switch (inputValue)
                {
                    case 0:
                        WordSubstituion();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        // InvalidInput();
                        break;
                }

                break;
            }
        }

        private static void WordSubstituion()
        {
            _availableWords = _findWords.PopulateDictionary();

            if (_availableWords == null)
            {
                Console.WriteLine("There was an error in populating the dictionary. This cypher cannot be completed.");
                ChooseCypher();
            }
            Console.WriteLine("The dictionary was successfully populated.");
            Console.WriteLine("[0] Encrypt text");
            Console.WriteLine("[1] Decrypt text");
            Console.WriteLine("[2] or Exit to exit the program");

            while (true)
            {
                TryParse(Console.ReadLine(), out var inputValue);
                switch (inputValue)
                {
                    case 0:
                        var encrypt = new Encrypt(_availableWords);
                        Console.WriteLine("Please enter text to encrypt");
                        var input = Console.ReadLine();
                        var output = encrypt.EncryptText(input);
                        Console.WriteLine(output);
                        continue;

                    case 1:
                        Console.WriteLine("Please enter text to decrypt");
                        input = Console.ReadLine();
                        var decrypted = Decrypt.DecryptText(input);
                        Console.WriteLine(decrypted);
                        continue;

                    case 2:
                        Environment.Exit(0);
                        break;

                    default:
                        // InvalidInput();
                        break;
                }
            }
        }
    }
}