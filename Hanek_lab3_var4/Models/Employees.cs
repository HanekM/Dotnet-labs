using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Lab3.Models
{
    public partial class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;} = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public decimal HourlyRate {get; set;}
        public int TotalHours {get; set;}

        public Position Position {get; set;} = null!;
        public Subject Subject {get; set;} = null!;
        public Location HomeAddress {get; set;} = null!;
        public Location WorkplaceAddress {get; set;} = null!;
    }
}
