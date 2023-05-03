using Microsoft.AspNetCore.Mvc;
using server.Domain;
using server.Repository;
using server.Usecase;
using server.Usecase.Repo;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoreController : ControllerBase
{
    private readonly ILogger<ScoreController> _logger;
    private readonly ICandidateScoreRepo _candidateScoreRepo;

    public ScoreController(ILogger<ScoreController> logger)
    {
        _logger = logger;
        _candidateScoreRepo = new MysqlRepo("Server=localhost;User ID=root;Database=uni_choice;Password=rootpass");

    }
    
    [HttpGet, Route("/score")]
    public async Task<CandidateScore> GetScore([FromQuery
        (Name = "id")] string studentId, [FromQuery
        (Name = "year")] int year = 2018)
    {
        var getCandidateScore = new GetCandidateScore(_candidateScoreRepo, studentId, year);
        CandidateScore result;
        try
        {
            result = await getCandidateScore.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }
}