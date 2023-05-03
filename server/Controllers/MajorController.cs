using Microsoft.AspNetCore.Mvc;
using server.Domain;
using server.Repository;
using server.Usecase;
using server.Usecase.Repo;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class MajorController : ControllerBase
{
    private readonly ILogger<MajorController> _logger;
    private readonly IMajorRepo _majorRepo;

    public MajorController(ILogger<MajorController> logger)
    {
        _logger = logger;
        _majorRepo = new MysqlRepo("Server=localhost;User ID=root;Database=uni_choice;Password=rootpass");

    }
    
    [HttpGet, Route("/majors")]
    public async Task<List<Major>> GetTopMajorsByMark([FromQuery
        (Name = "threshold")] int threshold = 150)
    {
        var getTopMajorsByMarkUc = new GetTopMajorsByMark(_majorRepo, threshold);
        List<Major> result;
        try
        {
            result = await getTopMajorsByMarkUc.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }

    [HttpGet, Route("/major")]
    public async Task<List<Major>> GetMajorsOfUni([FromQuery
        (Name = "uni")] string uniCode)
    {
        var getMajorsOfUni = new GetMajorsOfUni(_majorRepo, uniCode);
        List<Major> result;
        try
        {
            result = await getMajorsOfUni.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }
    
    [HttpGet, Route("/major/at")]
    public async Task<List<string>> GetGroupSubject([FromQuery
        (Name = "major")] string majorCode)
    {
        var getGroupSubject = new GetGroupSubject(_majorRepo, majorCode);
        List<string> result;
        try
        {
            result = await getGroupSubject.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }
}