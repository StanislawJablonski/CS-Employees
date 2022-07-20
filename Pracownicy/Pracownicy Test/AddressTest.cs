using NUnit.Framework;
using Pracownicy;

namespace Pracownicy_Test
{
    public class AddressTest
    {
        private Address _example;

        [SetUp]
        public void Setup()
        {
            _example = new Address("Derdowskiego", "1", "10", "Gdansk");
        }

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckIfCanCreate()
        {
            Assert.That(_example, Is.Not.Null);
        }

        [Test]
        public void CheckIfStreetIsCorrect()
        {
            Assert.That(_example.Street, Is.EqualTo("Derdowskiego"));
        }

        [Test]
        public void CheckIfStreetNumberIsCorrect()
        {
            Assert.That(_example.StreetNumber, Is.EqualTo("1"));
        }

        [Test]
        public void CheckIfCityIsCorrect()
        {
            Assert.That(_example.City, Is.EqualTo("Gdansk"));
        }

        [Test]
        public void CheckIfStreetCanBeChanged()
        {
            _example.Street = "Tetmajera";
            Assert.That(_example.Street, Is.EqualTo("Tetmajera"));
        }

        [Test]
        public void CheckIfStreetNumberCanBeChanged()
        {
            _example.StreetNumber = "2";
            Assert.That(_example.StreetNumber, Is.EqualTo("2"));
        }

        [Test]
        public void CheckIfCityCanBeChanged()
        {
            _example.City = "Gdynia";
            Assert.That(_example.City, Is.EqualTo("Gdynia"));
        }
    }
}