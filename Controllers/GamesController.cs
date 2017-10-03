using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Converters;
using TestWebAPI.Data;
using TestWebAPI.Data.DTO;
using TestWebAPI.Data.Entities;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "gamer")]
    public class GamesController : Controller
    {
        private GamesDbContext context;
        
        public GamesController(GamesDbContext context)
        {
            this.context = context;
        }

        // GET api/games
        [HttpGet]
        public IEnumerable<GameEntity> Get()
            => this.context.Games.Include(games => games.Folder);

        // GET api/games/79bc1393-4c5b-457d-9d4d-616dfb8eef13
        [HttpGet("{id}")]
        public async Task<GameEntity> Get(string id)
        {
            GameEntity game = await this.context.Games.FirstOrDefaultAsync(g => g.Id.Equals(id));
            if (game != null)
            {
                await this.context.Entry(game).Reference(g => g.Folder).LoadAsync();
            }
            
            return game;
        } 
        

        // POST api/games
        [HttpPost]
        public async Task Post([FromBody]GameDTO game)
        {
            GameEntity entity = GameConverter.ToEntity(game);
            
            this.context.Games.Add(entity);
            await this.context.SaveChangesAsync();
        }

        // DELETE api/games/79bc1393-4c5b-457d-9d4d-616dfb8eef15
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            GameEntity game = await this.context.Games.FirstAsync(g => g.Id.Equals(id));
            this.context.Games.Remove(game);
            await this.context.SaveChangesAsync();
        }
    }
}
