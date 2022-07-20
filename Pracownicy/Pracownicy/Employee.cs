using System.Threading;

namespace Pracownicy
{
    public abstract class Employee
    {
        private static int _numberOfEmployees = 0;

        public int Id;
        public string Name;
        public string Surname;
        public int Age;
        public int Experience;
        public Address Address;

        public Employee()
        {
        }

        protected static int GenerateIndex()
        {
            Interlocked.Increment(ref _numberOfEmployees);
            return _numberOfEmployees;
        }

        public abstract int CalculateValue();
    }
}