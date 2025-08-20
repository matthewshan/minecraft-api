using Microsoft.Extensions.Caching.Memory;
using matthewshan.MinecraftUtils.Api.Rcon.Interfaces;
using matthewshan.MinecraftUtils.Api.Rcon.Models;

namespace matthewshan.MinecraftUtils.Api.Rcon.Services;

/// <inheritdoc/>
public class MinecraftService(IRconClient rconClient, IMojangApiClient mojangApiClient, IMemoryCache memoryCache) : IMinecraftService
{
    /// <inheritdoc/>
    public async Task<List<Player>> GetOnlinePlayersAsync(CancellationToken cancellationToken)
    {
        var players = new List<Player>();

        // Check Cache
        if (memoryCache.TryGetValue(nameof(GetOnlinePlayersAsync), out players))
        {
            return players ?? [];
        }

        // Make a call to the server on online players
        var rconResponse = await rconClient.ListPlayersAsync();

        // Parse Response
        var parts = rconResponse.Split(':', 2);

        if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
        {
            memoryCache.Set(nameof(GetOnlinePlayersAsync), (List<Player>)[], TimeSpan.FromSeconds(5));
            return [];
        }

        var usernames = parts[1].Split(',')
            .Select(p => p.Trim())
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .ToList();

        // Don't call Mojang API if empty list
        if (usernames.Count == 0)
        {
            memoryCache.Set(nameof(GetOnlinePlayersAsync), (List<Player>)[], TimeSpan.FromSeconds(30));
            return [];
        }

        // Get UUID from Mojang API
        var mojangResponse = await mojangApiClient.GetUuidsAsync(usernames, cancellationToken);

        players = usernames.Select(username => new Player
        {
            Username = username,
            Uuid = mojangResponse.FirstOrDefault(x => x.Name == username)?.Id
        }).ToList();

        memoryCache.Set(nameof(GetOnlinePlayersAsync), players, TimeSpan.FromSeconds(30));
        return players;
    }
}
