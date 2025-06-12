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
            if (music == null) return NotFound();
            return Ok(music);
        }

        [HttpPost]
        public ActionResult<Music> Post(Music newMusic)
        {
            var createdMusic = _musicService.Add(newMusic);
            return CreatedAtAction(nameof(Get), new { id = createdMusic.Id }, createdMusic);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Music updatedMusic)
        {
            var updated = _musicService.Update(id, updatedMusic);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _musicService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
