using Lab5.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public sealed class Location : ModelBase
    {
        public string Country {get; set;} = null!;
        public string State {get; set;} = null!;
        public string City {get; set;} = null!;
        public string Street {get; set;} = null!;
        public string Number {get; set;} = null!;
        public int? ApartmentNumber {get; set;}
        public int? Floor {get; set;}
    }
}
