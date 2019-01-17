using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteInfo
{
    class Program
    {
        private static List<Address> AddrList = new List<Address>(); //threee lists of objects
        private static List<Company> ComList = new List<Company>();
        private static List<Person> PerList = new List<Person>();


        static void Main(string[] args)
        {
            InitializeAddresses();
            InitializePeople();
            InitializeCompanies();

            WritePeople();
            WriteCompanies();
        }

        static void InitializeAddresses()
        {
            Address Dave_GAddr = new Address("123 Me Street", "Markdale", "Oaklahoma", "N0C 1H0", "Japan");
            AddrList.Add(Dave_GAddr);

            Address Frank_BAddr = new Address("43 Shore Drive", "Lake Something", "Nebrahoma", "C0N 0H1", "Canada");
            AddrList.Add(Frank_BAddr);

            Address AerolithAddr = new Address("Unit 00001", "Science Division", "Halceon Tower", "101010", "Typhon");
            AddrList.Add(AerolithAddr);
        }

        static void InitializePeople()
        {
            Person Dave_G = new Person(AddrList[0], "Dave", "Green");
            PerList.Add(Dave_G);

            Person Frank_B = new Person(AddrList[1], "Frank", "Brown");
            PerList.Add(Frank_B);
        }

        static void InitializeCompanies()
        {
            Company DaveShop = new Company(AddrList[0], "Dave's Garage");
            ComList.Add(DaveShop);

            Company Aerolith = new Company(AddrList[2], "Aerolith Dynamics");
            ComList.Add(Aerolith);
        }


        static void WritePeople()
        {
            for(var i = 0; i < PerList.Count; i++)
            {
                Console.WriteLine(PerList[i].FirstName + " " + PerList[i].LastName); //Write name
                Console.WriteLine(PerList[i].ShippingAddress.StreetAddress); //Begin address
                Console.WriteLine(PerList[i].ShippingAddress.City);
                Console.WriteLine(PerList[i].ShippingAddress.State);
                Console.WriteLine(PerList[i].ShippingAddress.PostalCode);
                Console.WriteLine(PerList[i].ShippingAddress.Country); //end address

                Console.WriteLine();
                Console.WriteLine(); //Create whitespace
            }
        }

        static void WriteCompanies()
        {
            for (var i = 0; i < ComList.Count; i++)
            {
                Console.WriteLine(ComList[i].Name); //Write name
                Console.WriteLine(ComList[i].ShippingAddress.StreetAddress); //Begin address
                Console.WriteLine(ComList[i].ShippingAddress.City);
                Console.WriteLine(ComList[i].ShippingAddress.State);
                Console.WriteLine(ComList[i].ShippingAddress.PostalCode);
                Console.WriteLine(ComList[i].ShippingAddress.Country); //end address

                Console.WriteLine();
                Console.WriteLine(); //Create whitespace
            }
        }
    }


    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address(string _streetAdress, string _city, string _state, string _postalCode, string _country) //constructor
        {
            StreetAddress = _streetAdress;
            City = _city;
            State = _state;
            PostalCode = _postalCode;
            Country = _country;
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address ShippingAddress { get; set; } //composed of the Address class

        public Person(Address _address, string _firstName, string _lastName) //constructor
        {
            ShippingAddress = _address;
            FirstName = _firstName;
            LastName = _lastName;
        }
    }
    public class Company
    {
        public string Name { get; set; }
        public Address ShippingAddress { get; set; } //composed of the Address class

        public Company(Address _shippingAddress, string _name) //constructor
        {
            Name = _name;
            ShippingAddress = _shippingAddress;
        }
    }
}
