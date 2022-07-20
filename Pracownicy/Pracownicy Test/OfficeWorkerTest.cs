using System;
using NUnit.Framework;
using Pracownicy;

namespace Pracownicy_Test
{
    public class OfficeWorkerTest
    {
        private Address _exampleAddress;
        private OfficeWorker _example;

        [SetUp]
        public void Setup()
        {
            _exampleAddress = new Address("Trzcina", "22", "7", "Szczebrzeszyn");
            _example = new OfficeWorker("Szymon", "Chrząszcz", 27, 5, _exampleAddress, 100);
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
        public void CheckIfIqIsCorrect()
        {
            Assert.That(_example.iq, Is.EqualTo(100));
        }

        [Test]
        public void CheckIfIqThrowsArgumentOutOfRangeExceptionTooHigh()
        {
            OfficeWorker example2;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                example2 = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 151));
        }

        [Test]
        public void CheckIfIqThrowsArgumentOutOfRangeExceptionTooLow()
        {
            OfficeWorker example2;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                example2 = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 68));
        }

        [Test]
        public void CheckIfValueIsCorrect()
        {
            Assert.That(_example.CalculateValue(), Is.EqualTo(500));
        }

        [Test]
        public void CheckIfOfficeCounterWorks()
        {
            var example2 = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 120);
            var id = example2.OfficeWorkerID;
            example2 = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 125);
            Assert.That(example2.OfficeWorkerID, Is.EqualTo(id + 1));
        }
    }
}