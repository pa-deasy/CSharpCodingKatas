using NUnit.Framework;
using System.Collections.Generic;

namespace PhoneBoothDictionary.Tests.Unit
{
    [TestFixture]
    public class PhoneBookTests
    {
        [Test]
        public void Given_PhoneBook_When_Contacts_Updated_Then_As_Expected()
        {
            var phoneBook = new Dictionary<string, int>
            {
                { "Patrick", 1234 },
                { "Nicole", 5678 }
            };

            Assert.AreEqual(2, phoneBook.Count);

            phoneBook.Add("Michael", 9101);

            Assert.AreEqual(3, phoneBook.Count);
        }
    }
}
