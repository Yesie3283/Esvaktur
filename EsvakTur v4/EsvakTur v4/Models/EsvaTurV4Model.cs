using System;
using System.Data.Entity;
using System.Linq;

namespace EsvakTur_v4.Models
{
    public class EsvaTurV4Model : DbContext
    {

        public EsvaTurV4Model()
            : base("name=EsvaTurV4Model")
        {
        }
        public DbSet<TourCategory> TourCategories { get; set; }
        public DbSet<Tours> Tours { get; set; }

        public DbSet<Guides> Guides { get; set; }
        public DbSet<Managers> Managers { get; set; }

    }


}