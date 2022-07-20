namespace Pracownicy
{
    public class Address
    {
        public string Street { set; get; }
        public string StreetNumber { set; get; }
        public string FlatNumber { set; get; }
        public string City { set; get; }

        public Address(string street, string streetNumber, string flatNumber, string city)
        {
            this.Street = street;
            this.StreetNumber = streetNumber;
            this.FlatNumber = flatNumber;
            this.City = city;
        }

        public Address()
        {
        }
    }
}