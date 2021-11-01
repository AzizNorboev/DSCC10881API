using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using VideoGameAPI10881.Model;
using VideoGameAPI10881.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameAPI10881.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        public VideogamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var games = _gameRepository.GetAll();
            return new OkObjectResult(games);
            //return new string[] { "value1", "value2" };
        }
        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var game = _gameRepository.GetById(id);
            return new OkObjectResult(game);
            //return "value";
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Videogame game)
        {
            using (var scope = new TransactionScope())
            {
                _gameRepository.CreateGame(game);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Videogame game)
        {
            if (game != null)
            {
                using (var scope = new TransactionScope())
                {
                    _gameRepository.EditGame(game);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _gameRepository.DeleteGame(id);
            return new OkResult();
        }
    }
}
