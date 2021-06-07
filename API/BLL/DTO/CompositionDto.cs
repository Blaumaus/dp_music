using Microsoft.AspNetCore.Http;

namespace BLL.DTO
{
    public class CompositionDto
    {
        public string Id { get; set; }
        public string AlbumId { get; set; }
        public string Name { get; set; }
        public string BandId { get; set; }
        public string GenreId { get; set; }
        public int? Year { get; set; }
        public string Lyrics { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public IFormFile File { get; set; }
    }
}
