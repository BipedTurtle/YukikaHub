using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.Model
{
    public class Album
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public List<Song> Songs { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime Released { get; set; }
        public string Distribution { get; set; }
    }
}
