using System.Collections.Generic;

namespace TestWebAPI.Data.Entities
{
    public class FolderEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<GameEntity> Games { get; set; }
    }
}