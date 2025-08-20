namespace matthewshan.MinecraftUtils.Api.Rcon.Models;

/// <summary>
/// Class for Player Object
/// </summary>
public class Player
{
    /// <summary>
    /// Gets or sets username
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets player's uuid
    /// </summary>
    public string? Uuid { get; set; } = string.Empty;
    
}
