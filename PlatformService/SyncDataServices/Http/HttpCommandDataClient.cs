using System.Threading.Tasks;
using PlatformService.Dtos;
using System.Net.Http;
using System.Text;
using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

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
        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "aplication/json");

            //POST async request to our client
            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync POST to CommandService was OK !");
            }
            else
            {
                Console.WriteLine("Sync POST to CommandService was NOT OK !");
            }
        }
    }
}