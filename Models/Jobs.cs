using System.ComponentModel.DataAnnotations;


namespace FindAMusicianApi.Models{

public class Jobs {
    [Key] 
    public int Id { get; set; } // Primærnøkkel
    public string Contact { get; set; }
    public string Occasion { get; set; }
    public string Instrument { get; set; }
    public double Price { get; set; }
    public int Week { get; set; }
    public string Genre { get; set; }
    public string Booked { get; set; }
    }
}