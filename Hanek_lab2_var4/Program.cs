using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static System.Console;
using Npgsql;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile(path: "appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<DbConnection>();
            DbConnection db = new DbConnection(optionsBuilder.UseNpgsql(config.GetConnectionString("DbConnection")).Options);

            var result = db.Employees.Include(p=>p.Position).Include(p=>p.Subject).Include(p=>p.HomeAddress).Include(p=>p.WorkplaceAddress).OrderBy(p=>p.Id);
            WriteLine(result.ToQueryString());
            WriteLine(String.Format("{0, -10} | {1,-11} | {2,10} | {3,15} | {4,20} | {5, 20} | {6,12} | {7,10}", "First Name", "Middle Name", "Last Name", "Phone Number", "Position", "Subject", "Hourly Rate", "Total Hours"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            foreach (var lecturer in result)
            {
                WriteLine(String.Format("{0, -10} | {1,-11} | {2,10} | {3,15} | {4,20} | {5, 20} | {6,12} | {7,10}", lecturer.FirstName, lecturer.MiddleName, lecturer.LastName, lecturer.PhoneNumber, lecturer.Position.Name, lecturer.Subject.Name, lecturer.HourlyRate, lecturer.TotalHours));
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
