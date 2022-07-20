using System;

namespace Pracownicy
{
    public class ManualWorker : Employee
    {
        private int _strength;

        public int Strength
        {
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("value", "Strength > 100");
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "Strength < 1");
                _strength = value;
            }
            get { return _strength; }
        }


        public ManualWorker(string name, string surname, int age, int experience, Address address, int strength)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Experience = experience;
            Address = address;
            if (strength > 100)
                throw new ArgumentOutOfRangeException("strength", "Strength > 100");
            if (strength < 1)
                throw new ArgumentOutOfRangeException("strength", "Strength < 1");
            _strength = strength;
            Id = GenerateIndex();
        }

        public override string ToString()
        {
            return Name + " " + Surname + " age: " + Age + " exp: " + Experience;
        }

        public override int CalculateValue()
        {
            return Experience * _strength / Age;
        }
    }
}