using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Configurations
{
    internal sealed class RaceManagerDbConfiguration : DbMigrationsConfiguration<RaceManagerDbContext>
    {
        public RaceManagerDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}