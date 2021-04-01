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
        public string Title { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
