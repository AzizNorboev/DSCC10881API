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
        public void DeleteGame(int id)
        {
            var game = _dbContext.Videogames.Find(id);
            _dbContext.Videogames.Remove(game);
            Save();
        }
        public Videogame GetById(int id)
        {
            var game = _dbContext.Videogames.Find(id);
            _dbContext.Entry(game);
            return game;
        }
        public IEnumerable<Videogame> GetAll()
        {

            return _dbContext.Videogames.ToList();
        }
        public void CreateGame(Videogame game)
        {
            _dbContext.Add(game);
            Save();
        }
        public void EditGame(Videogame game)
        {
            //_dbContext.Entry(game).State = EntityState.Modified;
            //_dbContext.SaveChanges();
            _dbContext.Videogames.Update(game);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
