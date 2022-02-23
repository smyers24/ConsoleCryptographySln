using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyFunctions.Encryption;
using CryptographyFunctions.ExternalCalls;
using CryptographyFunctions.Objects;

namespace Cryptography.Tests
{
    [TestClass]
    public class EncryptionTests
    {
        private FindWords _findWords;
        private WordDictionary _availableWords;

        [TestMethod]
        public void Encrypt_Works()
        {
            var encryption = new Encrypt();
        }
    }
}