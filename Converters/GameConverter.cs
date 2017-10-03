using TestWebAPI.Data.DTO;
using TestWebAPI.Data.Entities;

namespace TestWebAPI.Converters
{
    public static class GameConverter
    {
        public static GameEntity ToEntity(GameDTO dto)
        {
            GameEntity entity = new GameEntity();
            entity.Folder = dto.Folder;
            entity.Name = dto.Name;
            
            return entity;
        }

        public static GameDTO ToDTO(GameEntity entity)
        {
            GameDTO dto = new GameDTO();
            dto.Folder = entity.Folder;
            dto.Name = entity.Name;

            return dto;
        }
    }
}