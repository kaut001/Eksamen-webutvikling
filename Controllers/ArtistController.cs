using Microsoft.AspNetCore.Mvc;
using FindAMusicianApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace FindAMusicianApi.Controllers{

    [ApiController] // må legges til for å få de egenskapene en controller skal ha
    [Route("[controller]")] // For at controlleren skal være tilgjengelig utenifra

    public class ArtistController : ControllerBase {
        private readonly FindAMusicianContext _context;  

        private readonly IWebHostEnvironment _hosting; 

        public ArtistController( FindAMusicianContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }


        [HttpGet] // Metode som returnerer en liste med alle artister i databasen
        public async Task<IEnumerable<Artist>> Get(){
            List<Artist> artistList = await _context.Artist.ToListAsync();
            return artistList;
        }


        [HttpGet] // Metode som henter ut artister fra databasen ut i fra sjanger
        [Route("[action]/{genre}")]
        public async Task<Artist> GetByGenre(string genre){
            Artist artist = await _context.Artist.FirstAsync( _artist => _artist.Genre.ToLower() == genre.ToLower() );
            return artist;
        }
        
        [HttpPost] // Metode som legger til en ny artist i databasen
        public async Task<Artist> Post(Artist newArtist){
            _context.Artist.Add( newArtist );
            await _context.SaveChangesAsync();
            return newArtist;
        }

        [HttpPost]
        [Route("[action]")] // Metode som laster opp bilde til databasen, dersom POST metoden over er OK.
        public void UploadImage(IFormFile file){
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");
            using(var fileStream = new FileStream(absolutePath, FileMode.Create )){
                file.CopyTo( fileStream );
            }
        }

    }

}