using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XieChenProject.Api.Database;
using XieChenProject.Api.Models;

namespace XieChenProject.Api.Services
{
    public class ToristRouteRepository:ITouristRouteRepository
    {
        private readonly AppDbContext _context;
        public ToristRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.FirstOrDefault(n => n.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes;
        }
    }
}
