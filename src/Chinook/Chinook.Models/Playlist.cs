using System.Collections.Generic;

namespace Chinook.WebApi.Models
{
    public class Playlist
    {
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
