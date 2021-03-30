using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.Model
{
    [Index(nameof(Title), IsUnique = true)]
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Picture { get; set; }

        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song>();

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [Range(0d, double.MaxValue, ErrorMessage = "Price cannot be a negative value")]
        public double Price { get; set; }

        public DateTime Released { get; set; }

        [StringLength(15)]
        public string Distribution { get; set; }
    }
}
