using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.SqlClient;
using Npgsql;
using System.Collections.ObjectModel;

namespace Lab1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {

            NpgsqlConnection sqlConnection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=Lecturers1;User Id=postgres;Password=admin;");
            await sqlConnection.OpenAsync();

            NpgsqlCommand command = new NpgsqlCommand();

            command.Connection = sqlConnection;
            command.CommandText = "SELECT Employees.firstName, employees.middleName, employees.lastName, employees.phoneNumber, subjects.name AS subjectName, positions.name AS positionName, hourlyRate, totalHours FROM employees INNER JOIN subjects ON subjects.id = employees.subjectID INNER JOIN positions ON positions.id = employees.positionID;";
            NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();

            WriteLine(String.Format("{0, -10} | {1,-11} | {2,10} | {3,15} | {4,20} | {5, 20} | {6,12} | {7,10}", "First Name", "Middle Name", "Last Name", "Phone Number", "Position", "Subject", "Hourly Rate", "Total Hours"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");

            while (await dataReader.ReadAsync())
            {
                WriteLine(String.Format("{0, -10} | {1,-11} | {2,10} | {3,15} | {4,20} | {5, 20} | {6,12} | {7,10}", dataReader["firstName"], dataReader["middleName"], dataReader["lastName"], dataReader["phoneNumber"], dataReader["positionName"], dataReader["subjectName"], dataReader["hourlyRate"], dataReader["totalHours"]));
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
           await sqlConnection.CloseAsync();
        }
    }
}
