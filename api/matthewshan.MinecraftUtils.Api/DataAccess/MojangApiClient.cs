using matthewshan.MinecraftUtils.Api.Rcon.Interfaces;
using matthewshan.MinecraftUtils.Api.Rcon.Models;

namespace matthewshan.MinecraftUtils.Api.Rcon.DataAccess;

/// <inheritdoc/>
public class MojangApiClient : IMojangApiClient
{
    private readonly HttpClient _mojangApiClient;

    /// <inheritdoc/>
    public MojangApiClient(IHttpClientFactory httpClientFactory) 
    {

        _mojangApiClient = httpClientFactory.CreateClient(nameof(MojangApiClient));
        _mojangApiClient.BaseAddress = new Uri("https://api.mojang.com/");
    }

    /// <inheritdoc/>
    public async Task<List<MojangProfile>> GetUuidsAsync(List<string> usernames, CancellationToken cancellationToken)
    {
        var response = await _mojangApiClient.PostAsync("/profiles/minecraft", JsonContent.Create(usernames), cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<MojangProfile>>(cancellationToken) ?? [];
    }
}
