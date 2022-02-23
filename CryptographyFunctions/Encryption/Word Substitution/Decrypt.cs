using System.Text;

namespace CryptographyFunctions.Decryption
{
    public class Decrypt
    {
        public static string DecryptText(string text)
        {
            var sb = new StringBuilder();
            foreach (var letter in text)
            {
                if (char.IsUpper(letter))
                {
                    sb.Append(letter);
                }
                else if (char.IsWhiteSpace(letter))
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();
        }
    }
}