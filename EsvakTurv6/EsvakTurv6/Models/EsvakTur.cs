using System;
using System.Data.Entity;
using System.Linq;

namespace EsvakTurv6.Models
{
    public class EsvakTur : DbContext
    {
        // Your context has been configured to use a 'EsvakTur' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EsvakTurv6.Models.EsvakTur' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EsvakTur' 
        // connection string in the application configuration file.
        public EsvakTur()
            : base("name=EsvakTur")
        {
        }

        public DbSet<TourCategories> TourCategories { get; set; }

        public DbSet<Tours> Tours { get; set; }
        public DbSet<Guides> Guides { get; set; }
        public DbSet<Managers> Managers { get; set; }

        public DbSet<Users> Users { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}