using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Lab3.Models
{
    public partial class Location
    {
        public string Id { get; set; } = null!;
        public string Country {get; set;} = null!;
        public string State {get; set;} = null!;
        public string City {get; set;} = null!;
        public string Street {get; set;} = null!;
        public string Number {get; set;} = null!;
        public int? ApartmentNumber {get; set;}
        public int? Floor {get; set;}
    }
}
