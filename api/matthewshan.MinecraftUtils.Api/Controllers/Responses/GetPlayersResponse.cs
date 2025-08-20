using matthewshan.MinecraftUtils.Api.Rcon.Models;

namespace matthewshan.MinecraftUtils.Api.Rcon.Controllers.Responses;

/// <summary>
/// Response Body for GetPlayers method
/// </summary>
public class GetPlayersResponse
{
    /// <summary>
    /// Information on players
    /// </summary>
    public List<Player> Players { get; set; } = [];
}

