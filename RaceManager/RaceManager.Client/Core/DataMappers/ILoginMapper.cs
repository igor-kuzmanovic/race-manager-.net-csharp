using RaceManager.Client.Models;
using RaceManager.Client.LoginService;

namespace RaceManager.Client.Core.DataMappers
{
    interface ILoginMapper : IDataMapper<User, LoginDTO>
    {
    }
}