namespace Lab2.DTOs
{
    public class tDTO
    {
    }
    //lidhja njo me shum
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }

    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public AuthorDto Author { get; set; }
    }
    //shum me shum

    public class BookAuthorDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<string> AuthorNames { get; set; }
    }
    //njo me njo
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public BookDto Book { get; set; }
    }

    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public AuthorDto Author { get; set; }
    }


}
