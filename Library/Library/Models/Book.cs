namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; } 
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Category { get; set; }
        public required string BookType { get; set; }
        public int? Volume { get; set; }
        public required bool Available { get; set; }
    }
}
