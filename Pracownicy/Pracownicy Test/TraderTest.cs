using NUnit.Framework;
using Pracownicy;

namespace Pracownicy_Test
{
    public class TraderTest
    {
        private Address _exampleAddress;
        private Trader _example;

        [SetUp]
        public void Setup()
        {
            _exampleAddress = new Address("Trzcina", "22", "7", "Szczebrzeszyn");
            _example = new Trader("Szymon", "Chrząszcz", 27, 5, _exampleAddress, TraderEfficiency.MEDIUM, 30);
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
        public void CheckIfCommissionIsCorrect()
        {
            Assert.That(_example.commission, Is.EqualTo(30));
        }

        [Test]
        public void CheckIfEfficiencyIsCorrect()
        {
            Assert.That((int) _example.efficiency, Is.EqualTo(90));
        }

        [Test]
        public void CheckIfCorrectlyCalculatesValue()
        {
            Assert.That(_example.CalculateValue(), Is.EqualTo(450));
        }
    }
}