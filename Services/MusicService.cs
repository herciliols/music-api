using System;
using System.Collections.Generic;
using System.Linq;
using music_api.Data;
using music_api.Models;

namespace music_api.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicDbContext _context;

        public MusicService(MusicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Music> GetAll()
        {
            try
            {
                return _context.Tracks.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return new List<Music>();
            }
        }

        public Music GetById(int id)
        {
            try
            {
                return _context.Tracks.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }

        public Music Add(Music music)
        {
            try
            {
                _context.Tracks.Add(music);
                _context.SaveChanges();
                return music;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }

        public bool Update(int id, Music music)
        {
            try
            {
                var existing = _context.Tracks.Find(id);
                if (existing == null) return false;

                existing.Title = music.Title;
                existing.Duration = music.Duration;
                existing.AlbumId = music.AlbumId;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var music = _context.Tracks.Find(id);
                if (music == null) return false;

                _context.Tracks.Remove(music);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
    }
}
