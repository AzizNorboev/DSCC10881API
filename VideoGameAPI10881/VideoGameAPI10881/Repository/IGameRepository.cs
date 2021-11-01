using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI10881.Model;

namespace VideoGameAPI10881.Repository
{
    public interface IGameRepository
    {
        void CreateGame(Videogame game);
        void EditGame(Videogame game);
        void DeleteGame(int id);
        Videogame GetById(int id);
        IEnumerable<Videogame> GetAll();
    }
}
