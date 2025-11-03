namespace BooksApp.dto
{
    public class SearchBook
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public Int64? ISBN { get; set; }
        public int? Year { get; set; }
    }
}
