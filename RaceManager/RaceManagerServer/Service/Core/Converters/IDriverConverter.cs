using RaceManagerServer.DataAccess.Core.Domain;
using RaceManagerServer.Service.Core.DataTransferObjects;

namespace RaceManagerServer.Service.Core.Converters
{
    interface IDriverConverter : IConverter<Driver, DriverDTO>
    {
    }
}