using Lab2.Models.PlanetSatelliteAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    //detyra planet satelit pa dto
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanetSatelliteAPI.Models
    {
        public class Planet
        {
            [Key]
            public int PlanetID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public bool IsDeleted { get; set; }

            public ICollection<Satellite> Satellites { get; set; }
        }
    }

    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetSatelliteAPI.Models
    {
        public class Satellite
        {
            [Key]
            public int SatelliteID { get; set; }
            public string Name { get; set; }
            public bool IsDeleted { get; set; }

            [ForeignKey("Planet")]
            public int PlanetID { get; set; }
            public Planet Planet { get; set; }
        }
    }
    //detyra planet satelit me dto
    public class Planet
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Satellite> Satellites { get; set; }
    }

    public class Satellite
    {
        public int SatelliteId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }
    }


}
