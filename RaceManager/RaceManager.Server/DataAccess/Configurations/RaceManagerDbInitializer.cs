using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence.Configurations
{
    class RaceManagerDbInitializer : CreateDatabaseIfNotExists<RaceManagerDbContext>
    {
        public RaceManagerDbInitializer() { }

        protected override void Seed(RaceManagerDbContext context)
        {
            var races = new List<RaceDAO>()
            {
                new RaceDAO()
                {
                    EventDate = new DateTime(2015, 3, 22),
                    EventLocation = "Indianapolis",
                },
                new RaceDAO()
                {
                    EventDate = new DateTime(2019, 4, 12),
                    EventLocation = "Texas",
                },
                new RaceDAO()
                {
                    EventDate = new DateTime(2018, 1, 6),
                    EventLocation = "Las Vegas",
                },
                new RaceDAO()
                {
                    EventDate = new DateTime(2011, 12, 12),
                    EventLocation = "Dover",
                }
            };

            foreach (var race in races)
                context.Races.AddOrUpdate(race);

            var drivers = new List<DriverDAO>()
            {
                new DriverDAO()
                {
                    FirstName = "Barry",
                    LastName = "Reagan",
                    UMCN = "3246937295843"
                },
                new DriverDAO()
                {
                    FirstName = "Milburn",
                    LastName = "Lukeson",
                    UMCN = "5739265837109"
                },
                new DriverDAO()
                {
                    FirstName = "John",
                    LastName = "Oliver",
                    UMCN = "3759372917375"
                }
            };

            foreach (var driver in drivers)
                context.Drivers.AddOrUpdate(driver);

            var vehicles = new List<VehicleDAO>()
            {
                new VehicleDAO()
                {
                    Manufacturer = "Nissan",
                    Model = "350Z",
                    Type = "WSDFS32",
                    EngineHorsepower = 300,
                    EngineDisplacement = 2,
                    DriverId = 1
                },
                new VehicleDAO()
                {
                    Manufacturer = "Ford",
                    Model = "Mustang GT",
                    Type = "FWEWVR43",
                    EngineHorsepower = 250,
                    EngineDisplacement = 2,
                    DriverId = 1
                },
                new VehicleDAO()
                {
                    Manufacturer = "Toyota",
                    Model = "Corolla GT-S",
                    Type = "DDGREVZ",
                    EngineHorsepower = 350,
                    EngineDisplacement = 3,
                    DriverId = 2
                },
                new VehicleDAO()
                {
                    Manufacturer = "Toyota",
                    Model = "Supra SZ-R",
                    Type = "GSGRGR34",
                    EngineHorsepower = 325,
                    EngineDisplacement = 3,
                    DriverId = 2
                },
                new VehicleDAO()
                {
                    Manufacturer = "Mitsubishi",
                    Model = "Eclipse",
                    Type = "GAR3GGR",
                    EngineHorsepower = 370,
                    EngineDisplacement = 3,
                    DriverId = 3
                }
            };

            foreach (var vehicle in vehicles)
                context.Vehicles.AddOrUpdate(vehicle);

            var users = new List<UserDAO>()
            {
                new UserDAO()
                {
                    Username = "admin",
                    Password = "admin",
                    FirstName = "John",
                    LastName = "Doe",
                    SecurityToken = string.Empty,
                    IsAdmin = true
                },
                new UserDAO()
                {
                    Username = "user",
                    Password = "user",
                    FirstName = "Mary",
                    LastName = "Doe",
                    SecurityToken = string.Empty,
                    IsAdmin = false
                }
            };

            foreach (var user in users)
                context.Users.AddOrUpdate(user);

            var raceDrivers = new List<RaceDriverDAO>()
            {
                new RaceDriverDAO()
                {
                    RaceId = 1,
                    DriverId = 1
                },
                new RaceDriverDAO()
                {
                    RaceId = 1,
                    DriverId = 2
                },
                new RaceDriverDAO()
                {
                    RaceId = 2,
                    DriverId = 2
                },
                new RaceDriverDAO()
                {
                    RaceId = 2,
                    DriverId = 3
                },
                new RaceDriverDAO()
                {
                    RaceId = 3,
                    DriverId = 3
                },
                new RaceDriverDAO()
                {
                    RaceId = 3,
                    DriverId = 1
                },
                new RaceDriverDAO()
                {
                    RaceId = 4,
                    DriverId = 1
                },
                new RaceDriverDAO()
                {
                    RaceId = 4,
                    DriverId = 2
                },
                new RaceDriverDAO()
                {
                    RaceId = 4,
                    DriverId = 3
                }
            };

            foreach (var raceDriver in raceDrivers)
                context.RaceDrivers.AddOrUpdate(raceDriver);

            context.SaveChanges();
        }
    }
}