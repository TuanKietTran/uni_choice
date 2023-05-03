using Microsoft.AspNetCore.Mvc;
using server.Repository;
using server.Usecase;
using server.Usecase.DTO;
using server.Usecase.Repo;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class EqualScoreController : ControllerBase
{
    private readonly ILogger<EqualScoreController> _logger;
    private readonly IEqualScoreRepo _equalScoreRepo;

    public EqualScoreController(ILogger<EqualScoreController> logger)
    {
        _logger = logger;
        _equalScoreRepo = new MysqlRepo("Server=localhost;User ID=root;Database=uni_choice;Password=rootpass");

    }
    
    [HttpGet, Route("/equal")]
    public async Task<EqualScore> GetTopEqualScoresByMark([FromQuery
        (Name = "major")] string major,[FromQuery
        (Name = "group")] string group)
    {
        var equivalentScore = new EquivalentScore(_equalScoreRepo, major, group);
        EqualScore result;
        try
        {
            result = await equivalentScore.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }
}