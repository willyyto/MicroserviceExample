using PlatformService.Dtos;
using PlatfromService.SyncDataServices.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json");

            var response = _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent).Result;
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Error sending platform to command service");
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }   

        }
    }
}