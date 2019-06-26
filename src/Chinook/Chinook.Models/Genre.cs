using System.Collections.Generic;

namespace Chinook.WebApi.Models
{
    public class Genre
    {
        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
