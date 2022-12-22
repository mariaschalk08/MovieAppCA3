using System.ComponentModel.DataAnnotations;

namespace MovieAppCA3.Movies
{
    public class SearchforMovie
    {
        [RegularExpression(@"[a-zA-Z0-9]+$", ErrorMessage = "Only letters and numbers allowed")]
        public string? SearchWord { get; set; }
    }
}
