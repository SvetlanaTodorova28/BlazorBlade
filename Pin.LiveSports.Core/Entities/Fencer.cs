using Pin.LiveSports.Core.Enums;

namespace Pin.LiveSports.Core.Entities;

public class Fencer:BaseEntity{
    
    public int Rating { get; set; }
    public Guid TeamId { get; set; }
    public Team Team { get; set; }
    public string AvatarPicture { get; set; }
    
    public Gender Gender { get; set; }
    public bool IsMale
    {
        get => Gender == Gender.Male;
        set
        {
            if (value) Gender = Gender.Male;
        }
    }

    public bool IsFemale
    {
        get => Gender == Gender.Female;
        set
        {
            if (value) Gender = Gender.Female;
        }
    }
    
}