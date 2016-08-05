using NUnit.Framework;
using Rebilly;

namespace Tests
{
    [TestFixture]
    public class SignatureUnitTests
    {
        [Test]
        public void TestConstructIsNotNull()
        {
            var CurrentSignature = new Signature();
            Assert.IsInstanceOf<Signature>(CurrentSignature);
        }


        [Test]
        public void TestNonceIsEqualTo()
        {
            var CurrentSignature = new Signature();
            var Nonce = CurrentSignature.GenerateNonce(15);

            Assert.AreEqual(15, Nonce.Length);
        }

        [Test]
        public void TestGenerateSignatureIsEqualTo()
        {
            var CurrentSignature = new Signature();
            var Signature = CurrentSignature.Generate("12123", "XDB1234OFCEXq9UhwL7wDD6TestUL3vBfs55555");
            Assert.IsNotEmpty(Signature);
        }
    }
}
