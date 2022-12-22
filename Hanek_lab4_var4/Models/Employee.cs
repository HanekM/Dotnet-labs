using Lab4.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    public sealed class Employee : ModelBase
    {
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int PositionID { get; set; }
        public int SubjectID { get; set; }
        public int HomeAddressID { get; set; }
        public int WorkplaceAddressID { get; set; }
        public decimal HourlyRate {get; set;}
        public int TotalHours {get; set;}

        public Position Position {get; set;} = null!;
        public Subject Subject {get; set;} = null!;
        public Location HomeAddress {get; set;} = null!;
        public Location WorkplaceAddress {get; set;} = null!;
    }
}
