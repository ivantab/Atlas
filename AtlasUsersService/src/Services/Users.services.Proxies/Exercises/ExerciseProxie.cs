using System;
using System.Threading.Tasks;
using Users.services.Proxies.Exercises.Dtos;
using Users.Services.Proxies;
using Microsoft.Extensions.Options;
using Users.Services.Proxies.Exercises;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Users.services.Proxies
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
            _endpoinstnames = (EndpointsNames)endpointsnames;

        }

        public async Task<WorkoutDto> GetWorkOutAsync(int id)
        {
            var request = await _httpClient.GetAsync(_apiUrls.ExerciseUrl + _endpoinstnames.ExerciseUrl.WorkOut + id);
            request.EnsureSuccessStatusCode();
            return new WorkoutDto();
        }
    }
}
