namespace Pin.LiveSports.Core.Entities;

public class Comment {
    public int Id { get; set; }
    public string Content { get; set; }
    public Guid DuelId { get; set; }
    public Duel Duel { get; set; }
}