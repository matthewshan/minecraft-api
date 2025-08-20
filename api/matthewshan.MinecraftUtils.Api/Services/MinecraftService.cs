using matthewshan.MinecraftUtils.Api.Rcon.Interfaces;
using matthewshan.MinecraftUtils.Api.Rcon.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace matthewshan.MinecraftUtils.Api.Rcon.Services;

/// <inheritdoc/>
public class MinecraftService(IRconClient rconClient, IMojangApiClient mojangApiClient, IMemoryCache memoryCache, ILogger<MinecraftService> logger) : IMinecraftService
{
    /// <inheritdoc/>
    public async Task<List<Player>> GetOnlinePlayersAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching online players from the Minecraft server.");
        var players = new List<Player>();

        // Check Cache
        if (memoryCache.TryGetValue(nameof(GetOnlinePlayersAsync), out players))
        {
            logger.LogDebug("Cache hit for online players... Players: {Players}", players);
            return players ?? [];
        }

        // Make a call to the server on online players
        logger.LogDebug("Making a call to RCON...");
        var rconResponse = await rconClient.ListPlayersAsync();

        // Parse Response
        var parts = rconResponse.Split(':', 2);
        
        if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
        {
            logger.LogDebug("RCON server responded with no players. Returning empty list before hitting Mojang api...");

            memoryCache.Set(nameof(GetOnlinePlayersAsync), (List<Player>)[], TimeSpan.FromSeconds(1));
            return [];
        }

        var usernames = parts[1].Split(',')
            .Select(p => p.Trim())
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .ToList();

        // Get UUID from Mojang API
        logger.LogDebug("Fetching UUIDs for players from Mojang API... Usernames: '{Usernames}'", usernames);
        var mojangResponse = await mojangApiClient.GetUuidsAsync(usernames, cancellationToken);

        players = usernames.Select(username => new Player
        {
            Username = username,
            Uuid = mojangResponse.FirstOrDefault(x => x.Name == username)?.Id
        }).ToList();

        memoryCache.Set(nameof(GetOnlinePlayersAsync), players, TimeSpan.FromSeconds(5));
        return players;
    }
}
