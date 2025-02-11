using DapperEjerciciosPractice.Models;
using DapperEjerciciosPractice.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperEjerciciosPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGamRepository _videoGameRepository;

        public VideoGameController(IVideoGamRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAllAsync()
        {
            var videoGames = await _videoGameRepository.GetAllAsync();

            return Ok(videoGames);
        }

        [HttpGet("{id}", Name ="GetById")]
        public async Task<ActionResult<VideoGame>> GetByIdAsync(int id)
        {
            var videoGame = await _videoGameRepository.GetByIdAsync(id);

            if (videoGame == null)
            {
                return NotFound("Este videojuego no existe");
            }

            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(VideoGame videoGame)
        {
            await _videoGameRepository.AddAsync(videoGame);
            return CreatedAtAction("GetById", new { id = videoGame.Id }, videoGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, VideoGame videoGame)
        {
            var existingGame = await _videoGameRepository.GetByIdAsync(id);

            if (existingGame == null)
            {
                return NotFound("VideoGame not found");
            }

            videoGame.Id = id;

            await _videoGameRepository.UpdateAsync(videoGame);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingGame = await _videoGameRepository.GetByIdAsync(id);
            if (existingGame == null)
            {
                return NotFound("VideoGame not found");
            }
            await _videoGameRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}