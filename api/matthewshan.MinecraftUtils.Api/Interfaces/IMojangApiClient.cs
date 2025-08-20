using matthewshan.MinecraftUtils.Api.Rcon.Models;

namespace matthewshan.MinecraftUtils.Api.Rcon.Interfaces;

/// <summary>
/// Class responsible for interacting with the Mojang API
/// </summary>
public interface IMojangApiClient
{
    /// <summary>
    /// Gets Minecraft UUIDs
    /// </summary>
    /// <param name="usernames">List of usernames</param>
    /// <param name="cancellationToken">Cancellation Tokens</param>
    /// <returns></returns>
    Task<List<MojangProfile>> GetUuidsAsync(List<string> usernames, CancellationToken cancellationToken);
}
