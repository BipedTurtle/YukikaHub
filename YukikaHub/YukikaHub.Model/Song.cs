using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.Model
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Composer { get; set; }
        public string Lyricist { get; set; }
        public int Ratings { get; set; }
    }
}
