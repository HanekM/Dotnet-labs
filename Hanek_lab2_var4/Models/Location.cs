using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2
{
    public class Location
    {
        public int Id { get; set; }
        public string Country {get; set;} = null!;
        public string State {get; set;} = null!;
        public string City {get; set;} = null!;
        public string Street {get; set;} = null!;
        public string Number {get; set;} = null!;
        public int? ApartmentNumber {get; set;}
        public int? Floor {get; set;}
    }
}
