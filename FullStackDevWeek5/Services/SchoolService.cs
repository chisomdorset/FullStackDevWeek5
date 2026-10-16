using FullStackDevWeek5.Models;
using System.Text.Json;

namespace FullStackDevWeek5.Services
{
    public class SchoolService
    {
        private readonly HttpClient _httpClient;
        public SchoolService(HttpClient httpClient)
        {
            _httpClient = httpClient    ;
        }

        public async Task<List<School>> GetSchoolsAsync()
        {
        
                var response = await _httpClient.GetAsync("https://edutots.net/api/school");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var schools = JsonSerializer.Deserialize<IEnumerable<School>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return schools.ToList();
            
        }


        public async Task<Models.School> GetSchoolByIdAsync(int schoolId)
        {

            var response = await _httpClient.GetAsync($"https://edutots.net/api/school/{schoolId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var school = JsonSerializer.Deserialize<Models.School>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return school;

        }


        public async Task<Models.School> AddSchoolAsync(Models.School school)
        {


            var response = await _httpClient.PostAsJsonAsync("https://edutots.net/api/school/", school);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdSchool = JsonSerializer.Deserialize<Models.School>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return createdSchool ?? school;

        }



        public async Task<bool> UpdateSchoolAsync(School school)
        {
            var response = await _httpClient.PutAsJsonAsync(
            $"https://edutots.net/api/school/{school.SchoolId}",
            school);

            return response.IsSuccessStatusCode;
        }




    }
}