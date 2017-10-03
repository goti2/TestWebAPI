namespace TestWebAPI.Data.Entities
{
    public class GameEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public FolderEntity Folder { get; set; }
    }
}