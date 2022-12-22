using Microsoft.AspNetCore.Components;

namespace MovieAppCA3.Movies
{
    public class MoviesItem
    {
        // Add properties
        
        public string? Title { get; set; }
        public string? Year { get; set; }
        public string? ImdbID { get; set; }
        public string? Type { get; set; }
        public string? Poster { get; set; }
        public int totalResults { get; set; }
    }

    /* Diff Endpoint
        public string? MovieTitle { get; set; }
        public string? Year { get; set; }
        public string? Rated { get; set; }
        public string? Released { get; set; }
        public string? Runtime { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? Writer { get; set; }
        public string? Actors { get; set; }
        public string? Poster { get; set; }
        public string? IMDBRating { get; set; }
     */
}
