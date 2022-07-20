using System.Collections.Generic;
using NUnit.Framework;
using Pracownicy;

namespace Pracownicy_Test
{
    public class RegisterTest
    {
        private Register _example;
        private Address _exampleAddress;
        private OfficeWorker _exampleOfficeWorker;
        private ManualWorker _exampleManualWorker;
        private Trader _exampleTrader;

        [SetUp]
        public void Setup()
        {
            _exampleAddress = new Address("Trzcina", "22", "7", "Szczebrzeszyn");
            _example = Register.Instance;
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
        public void CheckIfCanCreateOtherRegister()
        {
            var example2 = Register.Instance;
            Assert.That(_example, Is.EqualTo(example2));
        }

        [Test]
        public void CheckIfCanAddMultipleEmployees()
        {
            var count = _example.GetListCount();
            var list = new List<Employee>();

            _exampleOfficeWorker = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 150);
            _exampleManualWorker = new ManualWorker("Sasza", "Suchy", 40, 15, _exampleAddress, 100);
            _exampleTrader = new Trader("Szymon", "Chrząszcz", 27, 5, _exampleAddress, TraderEfficiency.MEDIUM, 30);
            list.Add(_exampleOfficeWorker);
            list.Add(_exampleManualWorker);
            list.Add(_exampleTrader);
            _example.Add(list);
            Assert.That(_example.GetListCount(), Is.EqualTo(count + 3));
        }

        [Test]
        public void CheckIfCanAdd()
        {
            var count = _example.GetListCount();
            _exampleManualWorker = new ManualWorker("Szymon", "Chrząszcz", 27, 5, _exampleAddress, 100);
            _example.Add(_exampleManualWorker);
            Assert.That(_example.GetListCount(), Is.EqualTo(count + 1));
        }

        [Test]
        public void CheckIfCanRemoveEmployee()
        {
            _exampleOfficeWorker = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 150);
            _example.Add(_exampleOfficeWorker);
            var count = _example.GetListCount();
            _example.Remove(_exampleOfficeWorker.Id);

            Assert.That(_example.GetListCount(), Is.EqualTo(count - 1));
        }

        [Test]
        public void CheckPrintSortedListWorks()
        {
            _example.ClearList();
            _exampleOfficeWorker = new OfficeWorker("Franciszek", "Kimono", 35, 10, _exampleAddress, 150);
            _exampleManualWorker = new ManualWorker("Sasza", "Suchy", 40, 15, _exampleAddress, 100);
            _exampleTrader = new Trader("Szymon", "Chrząszcz", 27, 5, _exampleAddress, TraderEfficiency.MEDIUM, 30);
            var exampleOfficeWorker2 = new OfficeWorker("Jan", "Adamski", 35, 10, _exampleAddress, 150);
            var exampleManualWorker2 = new ManualWorker("Stanislaw", "Jablonski", 45, 15, _exampleAddress, 100);
            var exampleTrader2 = new Trader("John", "Smith", 28, 5, _exampleAddress, TraderEfficiency.MEDIUM, 30);
            _example.Add(_exampleOfficeWorker);
            _example.Add(_exampleManualWorker);
            _example.Add(_exampleTrader);
            _example.Add(exampleOfficeWorker2);
            _example.Add(exampleManualWorker2);
            _example.Add(exampleTrader2);
            var result = _exampleManualWorker + "\n" + exampleManualWorker2 + "\n" + exampleOfficeWorker2 + "\n" +
                         _exampleOfficeWorker + "\n" + _exampleTrader + "\n" + exampleTrader2 + "\n";
            Assert.That(_example.PrintSortedList(), Is.EqualTo(result));
        }

        [Test]
        public void CheckIfPrintByCityWorks()
        {
            _example.ClearList();
            _exampleOfficeWorker = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 150);
            _exampleManualWorker = new ManualWorker("Sasza", "Suchy", 40, 15, _exampleAddress, 100);
            _exampleTrader = new Trader("Szymon", "Chrząszcz", 27, 5, _exampleAddress, TraderEfficiency.MEDIUM, 30);
            _exampleTrader.Address = new Address("Piękna", "2", "7", "Chrząszczyrzewoszyce");
            _example.Add(_exampleOfficeWorker);
            _example.Add(_exampleManualWorker);
            _example.Add(_exampleTrader);
            var result = _exampleOfficeWorker + "\n" + _exampleManualWorker + "\n";
            Assert.That(_example.PrintByCity("Szczebrzeszyn"), Is.EqualTo(result));
        }

        [Test]
        public void CheckIfPrintWithValueForCompanyWorks()
        {
            _example.ClearList();
            _exampleOfficeWorker = new OfficeWorker("Franciszek", "Kimono", 30, 10, _exampleAddress, 150);
            _exampleManualWorker = new ManualWorker("Sasza", "Suchy", 40, 15, _exampleAddress, 100);
            _exampleTrader = new Trader("Szymon", "Chrząszcz", 27, 5, _exampleAddress, TraderEfficiency.MEDIUM, 30);
            _example.Add(_exampleOfficeWorker);
            _example.Add(_exampleManualWorker);
            _example.Add(_exampleTrader);
            var result = _exampleOfficeWorker + " Value for company: " + _exampleOfficeWorker.CalculateValue() + "\n" +
                         _exampleManualWorker + " Value for company: " + _exampleManualWorker.CalculateValue() + "\n" +
                         _exampleTrader + " Value for company: " + _exampleTrader.CalculateValue() + "\n";
            Assert.That(_example.PrintWithValueForCompany(), Is.EqualTo(result));
        }
    }
}