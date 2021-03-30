using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.Model
{
    [Index(nameof(Title), IsUnique = true)]
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Composer { get; set; }
        public string Lyricist { get; set; }
        public int Ratings { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
