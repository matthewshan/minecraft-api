using CoreRCON;
using Microsoft.Extensions.Options;
using matthewshan.MinecraftUtils.Api.Rcon.Configuration;
using matthewshan.MinecraftUtils.Api.Rcon.Interfaces;
using System.Net;
using System.Text.RegularExpressions;

namespace matthewshan.MinecraftUtils.Api.Rcon.DataAccess;

/// <inheritdoc/>
public class RconClient(IOptions<RconSettings> settings) : IRconClient
{
    /// <inheritdoc/>
    public async Task<string> ListPlayersAsync()
    {
        // Establish Connection
        using var rcon = new RCON(IPAddress.Parse(settings.Value.IpAddress), settings.Value.Port, settings.Value.Password);
        await rcon.ConnectAsync();

        // Send Command
        var command = await rcon.SendCommandAsync("list");

        return RemoveMinecraftColors(command);
    }

    /// <summary>
    /// Removes Minecraft color encoding
    /// </summary>
    /// <param name="value">Sting Value</param>
    /// <returns>Transformed string</returns>
    private string RemoveMinecraftColors(string value)
    {
        return Regex.Replace(value, @"§[0-9a-fk-or]", "", RegexOptions.IgnoreCase);
    }
}
