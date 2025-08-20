namespace matthewshan.MinecraftUtils.Api.Rcon.Configuration;

/// <summary>
/// Class for RconSettings configuration section
/// </summary>
public class RconSettings
{
    /// <summary>
    /// Gets or sets the Minecraft Server IP Address
    /// </summary>
    public string IpAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or setes the Minecraft Server RCON Port
    /// </summary>
    public ushort Port { get; set; }

    /// <summary>
    /// Gets or sets the Minecraft Server RCON Password
    /// </summary>
    public string Password { get; set; }= string.Empty;
}

