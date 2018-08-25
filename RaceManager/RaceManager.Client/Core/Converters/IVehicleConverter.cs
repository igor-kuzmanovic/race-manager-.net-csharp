using RaceManager.Client.Models;
using RaceManager.Client.VehicleService;

namespace RaceManager.Client.Core.Converters
{
    interface IVehicleConverter : IConverter<Vehicle, VehicleDTO>
    {
    }
}