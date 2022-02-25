using PlatformService.Dtos;
using System.Threading.Tasks;

namespace PlatfromService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
        
        
    }
}