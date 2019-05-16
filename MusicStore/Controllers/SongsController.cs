using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class SongsController : ApiController
    {
        MusicStoreDBContext _context;

        public SongsController()
        {
            _context = new MusicStoreDBContext();
        }


        // Sort songs by given field name.
        // e.g. /api/songs/sortBy/Title

        [Route("api/songs/sortBy/{fieldName}")]
        [HttpGet]
        public IEnumerable<Song> sortBy(string fieldName)
        {
            if (fieldName == "ReleaseYear")
            {
                var songs = _context.Songs.OrderBy(s => s.ReleaseYear).ToList();
                return songs;
            }
            else if(fieldName == "Artist")
            {
                var songs = _context.Songs.OrderBy(s => s.Artist).ToList();
                return songs;
            } else if (fieldName == "Title")
            {
                var songs = _context.Songs.OrderBy(s => s.Title).ToList();
                return songs;
            } else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // Search songs between given years. Provide from year and to year
        // eg /api/songs/search/1940,1950

        [Route("api/songs/search/{fromYear:int},{toYear:int}")]
        [HttpGet]
        public IEnumerable<Song> search(int fromYear, int toYear)
        {
            var songs = _context.Songs.Where(s => s.ReleaseYear >= fromYear && s.ReleaseYear <= toYear).ToList();
            return songs;
        }


        //  Fetch all songs.
        //  GET - /api/songs 
        [HttpGet]
        public IEnumerable<Song> GetSongs()
        {
           return _context.Songs.ToList();
        }

        //  Fetch a song based on provided id.
        //  GET - /api/songs/{id} 
        [HttpGet]
        public Song GetSong(int id)
        {
            var song = _context.Songs.SingleOrDefault(s => s.Id == id);

            // if resource not found.
            if (song == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Song with Id = {0}", id)),
                    ReasonPhrase = "Requested Song Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return song;
        }

        //  Create a new song.
        //  POST - /api/songs
        [HttpPost]
        public Song CreateSong(Song song)
        {
            // If validations fail
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            else
            {
                _context.Songs.Add(song);
                _context.SaveChanges();

                return song;
            }
        }

        //  Update an existing song.
        //  PUT - /api/songs/{id}
        [HttpPut]
        public void UpdateSong(int id, Song song)
        {
            // If validations fail
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var songInDB = _context.Songs.SingleOrDefault(s => s.Id == id);

            // If provided id is not valid.
            if (songInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
            {
                songInDB.Title = song.Title;
                songInDB.Artist = song.Artist;
                songInDB.ReleaseYear = song.ReleaseYear;

                _context.SaveChanges();
            }
        }

        //  Remove an existing song.
        //  DELETE - /api/songs/{id}
        [HttpDelete]
        public void RemoveSong(int id)
        {
            var songInDB = _context.Songs.SingleOrDefault(s => s.Id == id);

            // If provided id is not valid.
            if (songInDB == null)
                new HttpResponseException(HttpStatusCode.NotFound);
            else
            {
                _context.Songs.Remove(songInDB);
                _context.SaveChanges();
            }
        }
    }
}
