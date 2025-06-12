using System.Collections.Generic;
using music_api.Models;

namespace music_api.Services
{
    public interface IMusicService
    {
        IEnumerable<Music> GetAll();
        Music GetById(int id);
        Music Add(Music newMusic);
        bool Update(int id, Music updatedMusic);
        bool Delete(int id);
    }
}
