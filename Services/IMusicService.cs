using System.Collections.Generic;
using music_api.Models;

namespace music_api.Services
{
    public interface IMusicService
    {
        IEnumerable<Music> GetAll();
        Music GetById(int id);
        Music Add(Music music);
        bool Update(int id, Music music);
        bool Delete(int id);
    }
}
