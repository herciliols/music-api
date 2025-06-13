namespace music_api.Models
{
    public class Music
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public int Duration { get; set; }
        public int AlbumId { get; set; }
    }
}
