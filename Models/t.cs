namespace Lab2.Models
{
    public class t
    {
    }
    // lidhja njo me shum 
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        //per lidhjen shum me shum 
        public class Author
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }

            public ICollection<BookAuthor> BookAuthors { get; set; }
        }

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }

            public ICollection<BookAuthor> BookAuthors { get; set; }
        }

        public class BookAuthor
        {
            public int BookId { get; set; }
            public Book Book { get; set; }

            public int AuthorId { get; set; }
            public Author Author { get; set; }
        }


        //njo me njo

        public class Author
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }
            public Book Book { get; set; }
        }

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }

            public int AuthorId { get; set; }
            public Author Author { get; set; }
        }

    }
}
