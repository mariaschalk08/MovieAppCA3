namespace MovieAppCA3.Movies
{
    public interface IMoviesService
    {
        Task<List<MoviesItem>> GetMovies(SearchforMovie searchWord);
    }
}
