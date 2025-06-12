using System.Collections.Generic;
using System.Linq;
using music_api.Models;

namespace music_api.Services
{
    public class MusicService : IMusicService
    {
        private readonly List<Music> _musics;

        public MusicService()
        {
            _musics = new List<Music>
            {
                new Music { Id = 1, Title = "Imagine", Artist = "John Lennon", Album = "Imagine" },
                new Music { Id = 2, Title = "Bohemian Rhapsody", Artist = "Queen", Album = "A Night at the Opera" }
            };
        }

        public IEnumerable<Music> GetAll() => _musics;

        public Music GetById(int id) => _musics.FirstOrDefault(m => m.Id == id);

        public Music Add(Music newMusic)
        {
            newMusic.Id = _musics.Any() ? _musics.Max(m => m.Id) + 1 : 1;
            _musics.Add(newMusic);
            return newMusic;
        }

        public bool Update(int id, Music updatedMusic)
        {
            var music = _musics.FirstOrDefault(m => m.Id == id);
            if (music == null) return false;

            music.Title = updatedMusic.Title;
            music.Artist = updatedMusic.Artist;
            music.Album = updatedMusic.Album;
            return true;
        }

        public bool Delete(int id)
        {
            var music = _musics.FirstOrDefault(m => m.Id == id);
            if (music == null) return false;

            _musics.Remove(music);
            return true;
        }
    }
}
