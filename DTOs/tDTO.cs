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

    //detyra palanet satelit me dto
    public class PlanetDTO
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SatelliteDTO
    {
        public int SatelliteId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int PlanetId { get; set; }
    }


}
