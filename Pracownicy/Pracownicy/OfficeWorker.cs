using System;
using System.Threading;

namespace Pracownicy
{
    public class OfficeWorker : Employee
    {
        private static int numberOfOfficeWorkers;

        public int OfficeWorkerID;
        private int _iq;

        public int iq
        {
            set
            {
                if (value > 150)
                    throw new ArgumentOutOfRangeException("iq", "IQ > 150");
                if (value < 70)
                    throw new ArgumentOutOfRangeException("iq", "IQ < 70");
                _iq = value;
            }
            get => _iq;
        }

        public OfficeWorker(string name, string surname, int age, int experience, Address address, int iq)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Experience = experience;
            Address = address;
            Id = GenerateIndex();
            OfficeWorkerID = GenerateOfficeWorkerID();
            if (iq > 150)
                throw new ArgumentOutOfRangeException("iq", "IQ > 150");
            if (iq < 70)
                throw new ArgumentOutOfRangeException("iq", "IQ < 70");
            _iq = iq;
        }

        private int GenerateOfficeWorkerID()
        {
            Interlocked.Increment(ref numberOfOfficeWorkers);
            return numberOfOfficeWorkers;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " age: " + Age + " exp: " + Experience;
        }

        public override int CalculateValue()
        {
            return Experience * _iq;
        }
    }
}