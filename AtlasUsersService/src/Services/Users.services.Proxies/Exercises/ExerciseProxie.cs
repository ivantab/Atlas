using System;
using System.Threading.Tasks;
using Users.Services.Proxies.Exercises.Dtos;
using Users.Services.Proxies;
using Microsoft.Extensions.Options;
using Users.Services.Proxies.Exercises;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Users.Services.Proxies.Exercises
{
    public class ExerciseProxie : IExerciseProxie
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;
        private readonly EndpointsNames _endpoinstnames;

        public ExerciseProxie(IOptions<ApiUrls> apiurls, HttpClient httpclient, IOptions<EndpointsNames> endpointsnames)
        {
            _apiUrls = apiurls.Value;
            _httpClient = httpclient;
            _endpoinstnames = endpointsnames.Value;

        }

        public async Task<WorkoutProxyDto> GetWorkOutAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrls.ExerciseUrl + _endpoinstnames.ExerciseUrl.WorkOut + id);
                response.EnsureSuccessStatusCode();
                var contentResposne = await response.Content.ReadAsStringAsync();
                var Workout = JsonSerializer.Deserialize<WorkoutProxyDto>(contentResposne,new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
            }
            catch(HttpRequestException ex)
            {

            }                  
            return new WorkoutProxyDto();
        }
    }
}
