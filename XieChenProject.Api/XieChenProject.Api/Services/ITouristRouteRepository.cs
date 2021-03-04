using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XieChenProject.Api.Models;

namespace XieChenProject.Api.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid touristRouteId);
    }
}
