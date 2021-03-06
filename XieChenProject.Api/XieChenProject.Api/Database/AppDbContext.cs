using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XieChenProject.Api.Models;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace XieChenProject.Api.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            //{
            //    Id = Guid.NewGuid(),
            //    Title = "ceshititle",
            //    Description = "shuoming",
            //    OriginalPrice = 0,
            //    CreateTime = DateTime.UtcNow
            //});

            var touristRouteJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/touristRoutesMockData.json");
            IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJsonData);
            modelBuilder.Entity<TouristRoute>().HasData(touristRoutes);

            var touristRoutePicturesJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/touristRoutePicturesMockData.json");
            IList<TouristRoutePicture> touristRoutePictures = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRoutePicturesJsonData);
            modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutePictures);

            base.OnModelCreating(modelBuilder);
        }

    }
}
