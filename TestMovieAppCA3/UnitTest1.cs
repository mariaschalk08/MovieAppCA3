using MovieAppCA3.Movies;

namespace TestMovieAppCA3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void GetMovie_Success()
        {
            HttpClient _httpClient = new HttpClient();
            MoviesService movieService = new MoviesService(_httpClient);
            SearchforMovie searchW = new SearchforMovie();
            searchW.SearchWord = "Star";

            // Assert
            Assert.AreEqual(4203, movieService.GetMovies(searchW).Result.Count);
        }
        [TestMethod]
        public void MovieCheck_SingleWord_SearchOK()
        {
            HttpClient _httpClient = new HttpClient();
            MoviesService movieService = new MoviesService(_httpClient);
            SearchforMovie searchW = new SearchforMovie();
            searchW.SearchWord = "Avengers";

            // Assert
            Assert.AreEqual(114, movieService.searchMovie(searchW).Result.Count);
        }
        public void MovieCheck_MoreThan1Word_SearchOK()
        {
            HttpClient _httpClient = new HttpClient();
            MoviesService movieService = new MoviesService(_httpClient);
            SearchforMovie searchW = new SearchforMovie();
            searchW.SearchWord = "Avengers Endgame";

            // Assert
            Assert.AreEqual(5, movieService.searchMovie(searchW).Result.Count);
        }
    }
}