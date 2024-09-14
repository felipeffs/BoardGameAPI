using BoardGameAPI.Data;
using BoardGameAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly DataContext _context;
        public BoardGameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoardGame>>> GetAllBoardGames()
        {
            var boardGames = await _context.BoardGames.ToListAsync();

            return Ok(boardGames);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<BoardGame>>> GetBoardGame(int id)
        {
            var boardGame = await _context.BoardGames.FindAsync(id);

            if (boardGame is null) return NotFound("Board game not found.");

            return Ok(boardGame);
        }

        [HttpPost]
        public async Task<ActionResult<BoardGame>> AddBoardGame(BoardGame newGame)
        {
            await _context.BoardGames.AddAsync(newGame);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<BoardGame>> UpdateBoardGame(BoardGame newGame)
        {
            var gameInDb = await _context.BoardGames.FindAsync(newGame.Id);
            if (gameInDb is null) return BadRequest("this board game not exist.");

            gameInDb.Name = newGame.Name;
            gameInDb.Publisher = newGame.Publisher;
            gameInDb.MinPlayerCount = newGame.MinPlayerCount;
            gameInDb.MaxPlayerCount = newGame.MaxPlayerCount;
            gameInDb.CoreMechanic = newGame.CoreMechanic;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> RemoveBoardGame(int id)
        {
            var gameInDb = await _context.BoardGames.FindAsync(id);

            if (gameInDb is null)
                return BadRequest("This board game not exist.");

            _context.BoardGames.Remove(gameInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
