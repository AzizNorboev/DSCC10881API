using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI10881.DAL;
using VideoGameAPI10881.Model;

namespace VideoGameAPI10881.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly VideoGameContext _dbContext;
        public GameRepository(VideoGameContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteGame(int id)
        {
            var game = _dbContext.Videogames.Find(id);
            _dbContext.Videogames.Remove(game);
            await Save();
        }
        public async Task<Videogame> GetById(int id)
        {
            //var game = _dbContext.Videogames.FindAsync(id);
            //_dbContext.Entry(game);
            return await _dbContext.Videogames.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<Videogame>> GetAll()
        {

            return await _dbContext.Videogames.ToListAsync();
        }
        public async Task CreateGame(Videogame game)
        {
            _dbContext.Add(game);
            await Save();
        }
        public async Task EditGame(Videogame game)
        {
            _dbContext.Entry(game).State = EntityState.Modified;
            //_dbContext.SaveChanges();
            _dbContext.Videogames.Update(game);
            await Save();
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
