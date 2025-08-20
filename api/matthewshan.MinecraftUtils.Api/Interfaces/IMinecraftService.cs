using matthewshan.MinecraftUtils.Api.Rcon.Models;

namespace matthewshan.MinecraftUtils.Api.Rcon.Interfaces;

/// <summary>
/// Class for handling minecraft related business logic
/// </summary>
public interface IMinecraftService
{
    /// <summary>
    /// Get Online Players and information about them
    /// </summary>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Player list information</returns>
    Task<List<Player>> GetOnlinePlayersAsync(CancellationToken cancellationToken);
}
