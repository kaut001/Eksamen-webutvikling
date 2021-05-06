using System.ComponentModel.DataAnnotations;


namespace FindAMusicianApi.Models{

public class Artist {
    [Key] 
    public int Id { get; set; } // Primærnøkkel
    public string Name { get; set; }
    public double Price { get; set; }
    public string Instrument { get; set; }
    public string Image { get; set; }
    public bool IsAvailable {get; set; } // OBS ikke brukt i denne oppgaven, men muliggjør for videre utvikling
    public string Genre { get; set; }

    }
}