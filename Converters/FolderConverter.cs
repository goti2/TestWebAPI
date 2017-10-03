using TestWebAPI.Data.DTO;
using TestWebAPI.Data.Entities;

namespace TestWebAPI.Converters
{
    public static class FolderConverter
    {
        public static FolderEntity ToEntity(FolderDTO dto)
        {
            FolderEntity entity = new FolderEntity();
            entity.Name = dto.Name;
            
            return entity;
        }

        public static FolderDTO ToDTO(FolderEntity entity)
        {
            FolderDTO dto = new FolderDTO();
            dto.Name = entity.Name;

            return dto;
        }
    }
}