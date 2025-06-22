using Microsoft.AspNetCore.Mvc;
using music_api.Models;
using music_api.Services;
using System.Collections.Generic;

namespace music_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Music>> Get()
        {
            var musics = _musicService.GetAll();
            return Ok(musics);
        }

        [HttpGet("{id}")]
        public ActionResult<Music> Get(int id)
        {
            var music = _musicService.GetById(id);
            if (music == null)
                return NotFound();

            return Ok(music);
        }

        [HttpPost]
        public ActionResult<Music> Post([FromBody] Music newMusic)
        {
            if (newMusic == null)
                return BadRequest("Invalid music data.");

            var createdMusic = _musicService.Add(newMusic);

            if (createdMusic == null)
                return StatusCode(500, "An error occurred while saving the music.");

            return CreatedAtAction(nameof(Get), new { id = createdMusic.Id }, createdMusic);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Music updatedMusic)
        {
            if (updatedMusic == null || id != updatedMusic.Id)
                return BadRequest("Invalid music data.");

            var updated = _musicService.Update(id, updatedMusic);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _musicService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
