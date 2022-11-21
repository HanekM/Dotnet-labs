using Lab3.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Lab3.Services;

public class EmployeeService
{
    private readonly IMongoCollection<Employee> _employeesCollection;

    public EmployeeService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        _employeesCollection = mongoDatabase.GetCollection<Employee>(databaseSettings.Value.BooksCollectionName);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees() 
        => await _employeesCollection.Find(_ => true).ToListAsync();

    public async Task<Employee> GetAsync(string id) =>
        await _employeesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Employee newEmployee) =>
        await _employeesCollection.InsertOneAsync(newEmployee);

    public async Task UpdateAsync(string id, Employee updatedEmployee) =>
        await _employeesCollection.ReplaceOneAsync(x => x.Id == id, updatedEmployee);

    public async Task RemoveAsync(string id) =>
        await _employeesCollection.DeleteOneAsync(x => x.Id == id);
}
