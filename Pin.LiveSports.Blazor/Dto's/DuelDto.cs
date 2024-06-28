using Pin.LiveSports.Core.Enums;

namespace Pin.LiveSports.Blazor.Dto_s;


    public class DuelDto
    {
        public Guid Id { get; set; }

        public string FencerAName{ get; set; }
        public string FencerAFlag { get; set; } 
        public int FencerAPoints { get; set; } 
        public int FencerARating { get; set; }
       
        public string FencerBName { get; set; }
        public string FencerBFlag { get; set; }
        public int FencerBRating { get; set; }
        public int FencerBPoints { get; set; } 
        public bool LightA { get; set; }
        public bool LightB { get; set; }
        
        
      public TimeSpan TimeLeft { get; set; }
       public List<string> Comments { get; set; } = new List<string>();

       public Guid TournamentId { get; set; }
    }

