using Microsoft.AspNetCore.Http;

namespace BLL.DTO
{
    public class GenreDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
