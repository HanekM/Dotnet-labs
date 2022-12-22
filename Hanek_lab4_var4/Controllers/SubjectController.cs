using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class SubjectController
    : GenericController<Subject>
    {
        public SubjectController(IRepository<Subject> repository)
            : base(repository)
        {

        }
    }
}
