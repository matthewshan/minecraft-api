using Microsoft.AspNetCore.Mvc;
using matthewshan.MinecraftUtils.Api.Rcon.Controllers.Responses;
using matthewshan.MinecraftUtils.Api.Rcon.Interfaces;

namespace matthewshan.MinecraftUtils.Api.Rcon.Controllers;

[Route("api/players")]
[ApiController]
public class PlayersController(IMinecraftService minecraftService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetPlayersResponse>> GetPlayers(CancellationToken cancellationToken)
    {
        var result = await minecraftService.GetOnlinePlayersAsync(cancellationToken);

        return Ok(new GetPlayersResponse
        {
            Players = result
        });
    }
}
