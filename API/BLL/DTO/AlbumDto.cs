using Microsoft.AspNetCore.Http;

namespace BLL.DTO
{
    public class AlbumDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BandId { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile File { get; set; }
    }
}
