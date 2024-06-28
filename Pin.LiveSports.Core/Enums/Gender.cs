namespace Pin.LiveSports.Core.Enums;

public enum Gender{
Male,
Female,
}
public static class AnimalsGenderExtensions
{
    public static string ToText(this Gender gender){

        return gender switch{
            Gender.Male => "Male",
            Gender.Female => "Female",
            _ => "Unknown gender"
        };

    }
}

