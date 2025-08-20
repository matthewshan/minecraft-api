namespace matthewshan.MinecraftUtils.Api.Rcon.Interfaces;

/// <summary>
/// Class Responsible for making RCON Protocol related calls
/// </summary>
public interface IRconClient
{
    /// <summary>
    /// List the players currently playing on the server
    /// </summary>
    /// <returns>Return list of usernames logged in</returns>
    Task<string> ListPlayersAsync();
}
