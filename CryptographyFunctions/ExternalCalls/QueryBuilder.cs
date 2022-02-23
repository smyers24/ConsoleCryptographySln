using CryptographyFunctions.Enums;


namespace CryptographyFunctions.ExternalCalls
{
    public static class QueryBuilder
    {
        private const string _wordsWithTheLetter = "words?sp=";

        public static string BuildQuery(char letter, QueryType queryType)
        {
            var query = queryType switch
            {
                QueryType.WordStartsWith => $"{_wordsWithTheLetter}{letter.ToString()}*",
                QueryType.WordEndsWith => $"{_wordsWithTheLetter}*{letter.ToString()}",
                _ => "ERROR"
            };

            return query;
        }
    }
}