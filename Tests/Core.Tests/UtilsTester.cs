using NUnit.Framework;
using odec.Framework.Infrastructure.Crypto;

namespace odec.Framework.CP.Tests
{
    public class UtilsTester : Tester
    {
        [Test]
        public void CheckEncriptDecript()
        {
            var phrase = "key";
            var key = "key1234";
            string encryption = string.Empty;
            string dectiption = string.Empty;
            Assert.DoesNotThrow(() => encryption = EncryptionHelper.Encrypt(phrase, key));
            Assert.DoesNotThrow(() => dectiption = EncryptionHelper.Decrypt(encryption, key));
            Assert.AreEqual(dectiption, phrase);
        }

    }
}
