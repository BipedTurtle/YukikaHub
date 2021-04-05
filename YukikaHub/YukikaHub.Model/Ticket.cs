using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.Model
{
    [Index(nameof(Title), IsUnique = true)]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Ticket price cannot be a negative value")]
        public double Price { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public string Description { get; set; }
    }
}
