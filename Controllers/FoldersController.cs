using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Converters;
using TestWebAPI.Data;
using TestWebAPI.Data.DTO;
using TestWebAPI.Data.Entities;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FoldersController : Controller
    {
        private readonly GamesDbContext context;
        
        
        public FoldersController(GamesDbContext context)
        {
            this.context = context;
        }

        // GET api/folders
        [HttpGet]
        public IEnumerable<FolderEntity> Get() 
            => this.context.Folders.Include(folder => folder.Games);

        
        // GET api/folders/79bc1393-4951-457d-9d4d-616dfb8eef23
        [HttpGet("{id}")]
        public async Task<FolderEntity> Get(string id)
        {
            FolderEntity entity = await this.context.Folders.FirstOrDefaultAsync(folder => folder.Id.Equals(id));
            if (entity != null)
            {
                await this.context.Entry(entity).Collection(e => e.Games).LoadAsync();    
            }
            
            return entity;
        }

        // POST api/folders
        [HttpPost]
        public async Task Post([FromBody]FolderDTO folder)
        {
            FolderEntity entity = FolderConverter.ToEntity(folder);

            this.context.Folders.Add(entity);
            await this.context.SaveChangesAsync();
        }

        // DELETE api/folders/ee3f05fe-1278-4919-b73a-ba5cbe66abf9
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            FolderEntity folder = await this.context.Folders.FirstAsync(f => f.Id.Equals(id));
            await this.context.Entry(folder).Collection(e => e.Games).LoadAsync();
            
            this.context.Games.RemoveRange(folder.Games);
            
            this.context.Folders.Remove(folder);
            await this.context.SaveChangesAsync();
        }
    }
}
