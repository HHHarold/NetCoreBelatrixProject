using System.Collections.Generic;

namespace Chinook.WebApi.Models
{
    public class Track
    {
        public Track()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int TrackId { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }


        public Album Album { get; set; }
        public MediaType MediaType { get; set; }
        public Genre Genre { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
