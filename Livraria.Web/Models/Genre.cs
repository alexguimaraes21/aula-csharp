using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Web.Models
{
    public class Genre
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
