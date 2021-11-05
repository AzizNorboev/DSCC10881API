using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI10881.Model;

namespace VideoGameAPI10881.Repository
{
    public interface IGameRepository
    {
        Task CreateGame(Videogame game);
        Task EditGame(Videogame game);
        Task DeleteGame(int id);
        Task<Videogame> GetById(int id);
        Task<List<Videogame>> GetAll();
    }
}
