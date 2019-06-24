using System.Collections.Generic;

namespace Chinook.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
