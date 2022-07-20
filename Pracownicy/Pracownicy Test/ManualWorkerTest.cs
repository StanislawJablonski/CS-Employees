using System;
using NUnit.Framework;
using Pracownicy;

namespace Pracownicy_Test
{
    public class ManualWorkerTest
    {
        private Address exampleAddress;
        private ManualWorker example;

        [SetUp]
        public void Setup()
        {
            exampleAddress = new Address("Trzcina", "22", "7", "Szczebrzeszyn");
            example = new ManualWorker("Szymon", "Chrząszcz", 27, 5, exampleAddress, 100);
        }

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckIfCanCreate()
        {
            Assert.That(example, Is.Not.Null);
        }

        [Test]
        public void CheckIfStrengthIsCorrect()
        {
            Assert.That(example.Strength, Is.EqualTo(100));
        }

        [Test]
        public void CheckIfStrengthThrowsArgumentOutOfRangeExceptionTooHighInConstructor()
        {
            ManualWorker example2;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                example2 = new ManualWorker("Sasza", "Suchy", 40, 15, exampleAddress, 101));
        }

        [Test]
        public void CheckIfStrengthThrowsArgumentOutOfRangeExceptionTooLowInContructor()
        {
            ManualWorker example2;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                example2 = new ManualWorker("Sasza", "Suchy", 40, 15, exampleAddress, 0));
        }

        [Test]
        public void CheckIfStrengthThrowsArgumentOutOfRangeExceptionTooHighInSetter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => example.Strength = 101);
        }

        [Test]
        public void CheckIfStrengthThrowsArgumentOutOfRangeExceptionTooLowInSetter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => example.Strength = 0);
        }

        [Test]
        public void CheckIfValueIsCorrect()
        {
            Assert.That(example.CalculateValue(), Is.EqualTo(18));
        }
    }
}