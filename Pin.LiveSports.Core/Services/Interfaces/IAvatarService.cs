using Pin.LiveSports.Utilities;

namespace Pin.LiveSports.Core.Services.Interfaces;

public interface IAvatarService{
    string GetAvatarUrl(string gender, string idToString);
}