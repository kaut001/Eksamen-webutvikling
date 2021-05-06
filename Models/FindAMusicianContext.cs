using Microsoft.EntityFrameworkCore;

namespace FindAMusicianApi.Models{

    public class FindAMusicianContext : DbContext {

        //Konstruktør
        public FindAMusicianContext(DbContextOptions<FindAMusicianContext> options):base(options){}

        // De to modellklasse som skal jobbes mot
        public DbSet<Artist> Artist { get; set; }

        public DbSet<Jobs> Jobs { get; set; }

    }

}