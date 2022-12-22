using Microsoft.AspNetCore.Components;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MovieAppCA3.Movies
{
    public class MoviesService : IMoviesService
    {
        private HttpClient _httpClient = new HttpClient();

        const string _baseURL = "https://movie-database-alternative.p.rapidapi.com/";
        const string _moviesEndpoint = "?s={SearchWord}&r=json&page=1";

        const string _host = "movie-database-alternative.p.rapidapi.com";
        const string _key = "4667e4c40amsh105af59a271f896p1aed8ejsndaec4e75f5ea";

        public string? SearchWord { get; set; }
        public MoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MoviesItem>> GetMovies(SearchforMovie searchMovie)
        {
            if (searchMovie.SearchWord != null)
            {
                try
                {
                    _httpClient = new HttpClient();

                    ConfigureHttpClient();

                    var response = await _httpClient.GetAsync(_moviesEndpoint);
                    response.EnsureSuccessStatusCode();

                    using var stream = await response.Content.ReadAsStreamAsync();

                    var dto = await JsonSerializer.DeserializeAsync<MoviesDto>(stream);
                    return dto.MoviesData.FirstOrDefault().Search.Select(n => new MoviesItem
                    {
                        Title = n.Title,
                        Year = n.Year,
                        Type = n.Type,
                        Poster = n.Poster
                        /*
                        MovieTitle = n.Title,
                        Year = n.Year,
                        Rated = n.Rated,
                        Released = n.Released,
                        Runtime = n.Runtime,
                        Genre = n.Genre,
                        Director = n.Director,
                        Actors = n.Actors,
                        Poster = n.Poster,
                        IMDBRating = n.imdbRating
                         */
                    }).ToList();
                }
                catch
                {
                    throw new ArgumentException("Couldn't find any movies that match your search");
                }

            }
            else
            {
                throw new ArgumentException("Couldn't find any movies that match your search");
            }
            

        }

        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _key);
        }
    }
}