using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pin.LiveSports.Core.Enums;

namespace Pin.LiveSports.Core.Entities;

public class Duel {
    
    public Guid Id { get; set; }
    public Guid FencerAId { get; set; }
    public Fencer? FencerA { get; set; }
    public Guid FencerBId { get; set; }
    public Fencer? FencerB { get; set; }
    
   public int FencerAPoints { get; set; }
   public int FencerBPoints { get; set; }
   public List<Comment>? Comments { get; set; } = new List<Comment>();
   
    [Required(ErrorMessage = "Selecting a tournament is required")]
    public Guid TournamentId { get; set; }
    
    public Tournament Tournament { get; set; }
   
}