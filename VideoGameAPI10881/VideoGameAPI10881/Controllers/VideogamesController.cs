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
        /// <summary>
        /// List of all items.
        /// </summary>
        /// <returns>The list of video games.</returns>
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameRepository.GetAll();
            return new OkObjectResult(games);
            //return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Details of a single item.
        /// </summary>
        /// <returns>A single video game.</returns>
        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _gameRepository.GetById(id);
            return new OkObjectResult(game);
            //return "value";
        }
        /// <summary>
        /// Create a new item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Videogames
        ///     {        
        ///       "name": "Hades",
        ///       "genre": "roguelike",
        ///       "price": "12",
        ///       "publisher" : "Supergiant Games"
        ///     }
        /// </remarks>  
        /// <returns>Created video game.</returns>
        /// <response code="201">If returns created video game</response>
        /// <response code="400">If created video game is null</response>  
        // POST: api/Product
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Videogame game)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _gameRepository.CreateGame(game);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                finally
                {
                    scope.Complete();
                }

                return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
            }
        }

        /// <summary>
        /// Update a selected item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT api/Videogames/{id}
        ///     {  
        ///       "id" : {id}
        ///       "name": "Hades",
        ///       "genre": "roguelike",
        ///       "price": "12",
        ///       "publisher" : "Supergiant Games"
        ///     }
        /// </remarks>   
        /// <returns>A newly updated video game.</returns>
        /// <response code="200">If requested video game was updated</response>
        /// <response code="400">If requested vidoe game was not updated</response>   
        // PUT: api/Product/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] Videogame game)
        {
            if (game != null)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        await _gameRepository.EditGame(game);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                    finally
                    {
                        scope.Complete();
                    }
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        /// <summary>
        /// Delete a selected item.
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameRepository.DeleteGame(id);
            return new OkResult();
        }
    }
}
