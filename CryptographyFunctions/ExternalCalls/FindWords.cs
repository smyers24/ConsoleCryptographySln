using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CryptographyFunctions.Enums;
using CryptographyFunctions.Objects;
using CryptographyFunctions.ExternalCalls;
using Newtonsoft.Json;


namespace CryptographyFunctions.ExternalCalls
{
    public class FindWords
    {
        private static readonly string _baseUrl = "https://api.datamuse.com";

        private HttpClient _client;

        public FindWords()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<List<WordDTO>> GetWords(char letter, QueryType queryType)
        {
            var queryString = QueryBuilder.BuildQuery(letter, queryType);
            var response = await _client.GetAsync(queryString);
         
            var wordList = new List<WordDTO>();
            
            if (response.IsSuccessStatusCode)
            {
                var wordResponse = response.Content.ReadAsStringAsync().Result;
                wordList = JsonConvert.DeserializeObject<List<WordDTO>>(wordResponse);
            }

            return wordList;
        }

        public WordDictionary PopulateDictionary()
        {
            var findWords = new FindWords();
            var dictionary = new NullCipherDictionary();
            for(var letter = 'A'; letter <= 'Z'; letter++) 
            {
                var words = findWords.GetWords(char.ToLowerInvariant(letter), QueryType.WordStartsWith).Result;
                dictionary.AvailableWords.Add(letter, words);
            }
            
            dictionary.AvailableWords.Add(' ', new List<WordDTO>{new WordDTO{score = 1, word = " "}});

            return dictionary;
        }
    }
}