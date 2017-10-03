using TestWebAPI.Data.Entities;

namespace TestWebAPI.Data.DTO
{
    public class GameDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public FolderEntity Folder { get; set; }
    }
}