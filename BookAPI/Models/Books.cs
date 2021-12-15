using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Nombre { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Autor { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Editorial { get; set; }
    }
}
