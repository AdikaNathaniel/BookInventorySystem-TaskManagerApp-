using BlazorWebAssemblyDotNetCrud.Shared.Entities;
using BookInventory.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookInventory.Controller
{
    [Route("api/videogames")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly DataContext _context;

        public VideoGameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAllVideoAsync()
        {
            return await _context.VideoGames.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetGameByIdAsync(int id)
        {
            var result = await _context.VideoGames.FindAsync(id);
            if (result == null)
            {
                return NotFound("Game Not Found");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameAsync(int id)
        {
            var result = await _context.VideoGames.FindAsync(id);
            if (result == null)
                return NotFound("Game Not Found");

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VideoGame>> UpdateGameAsync(int id, VideoGame updateGame)
        {
            var dbGame = await _context.VideoGames.FindAsync(id);
            if (dbGame == null)
                return NotFound("Game Not Found");

            dbGame.Title = updateGame.Title;
            dbGame.Publisher = updateGame.Publisher;
            dbGame.ReleaseYear = updateGame.ReleaseYear;

            await _context.SaveChangesAsync();

            return Ok(dbGame);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddGameAsync(VideoGame newGame)
        {
            _context.Add(newGame);
            await _context.SaveChangesAsync();

            return Ok(newGame);
        }
    }
}
