namespace EsvakTurv6.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EsvakTurv6.Models.EsvakTur>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EsvakTurv6.Models.EsvakTur context)
        {
            context.Managers.AddOrUpdate(
    r => r.Email,
    new Models.Managers
    {
        Name = "Ali Selim",
        LastName = "İkiz",
        NickName = "Aselim",
        Email = "Esvaktur@esvak.com",
        Password = "123",

        // DOĞRU KULLANIM: Tırnak işaretleri olmadan direkt true veriyoruz
        IsActive = true,

        JoinTime = DateTime.Now
    }
);

            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // ... mevcut catch blokların kalabilir
                throw;
            }
        }
    }

}
