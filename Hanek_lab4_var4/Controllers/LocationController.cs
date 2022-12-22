using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class LocationController
    : GenericController<Location>
    {
        public LocationController(IRepository<Location> repository)
            : base(repository)
        {

        }
    }
}
