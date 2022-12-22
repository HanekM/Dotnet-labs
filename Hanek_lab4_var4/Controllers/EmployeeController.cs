using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class EmployeeController
        : GenericController<Employee>
    {
        public EmployeeController(IRepository<Employee> repository)
            : base(repository)
        {

        }
    }
}
