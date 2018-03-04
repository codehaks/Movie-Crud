using System.ComponentModel.DataAnnotations;

namespace MovieCrud.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public int Year { get; set; }
    }    
}