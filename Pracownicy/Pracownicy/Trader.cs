namespace Pracownicy
{
    public class Trader : Employee
    {
        public TraderEfficiency efficiency { get; set; }
        public int commission { get; set; } // prowizja w %

        public Trader(string name, string surname, int age, int experience, Address address,
            TraderEfficiency efficiency, int commission)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Experience = experience;
            Address = address;
            this.efficiency = efficiency;
            this.commission = commission;
            Id = GenerateIndex();
        }

        public override string ToString()
        {
            return Name + " " + Surname + " age: " + Age + " exp: " + Experience;
        }

        public override int CalculateValue()
        {
            return Experience * (int) efficiency;
        }
    }

    public enum TraderEfficiency
    {
        LOW = 60,
        MEDIUM = 90,
        HIGH = 120
    }
}