using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class PositionController
        : GenericController<Position>
    {
        public PositionController(IRepository<Position> repository)
            : base(repository)
        {

        }
    }
}
