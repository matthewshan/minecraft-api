namespace matthewshan.MinecraftUtils.Api.Rcon.Models;

/// <summary>
/// Class for Mojang Profile from thier API
/// </summary>
public class MojangProfile
{
    /// <summary>
    /// Gets or Sets Player's UUID
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Player's Username
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
