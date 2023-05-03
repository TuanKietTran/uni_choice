using Microsoft.AspNetCore.Mvc;
using server.Domain;
using server.Repository;
using server.Usecase;
using server.Usecase.Repo;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class UniversityController : ControllerBase
{
    private readonly ILogger<UniversityController> _logger;
    private readonly IUniversityRepo _universityRepo;

    public UniversityController(ILogger<UniversityController> logger)
    {
        _logger = logger;
        _universityRepo = new MysqlRepo("Server=localhost;User ID=root;Database=uni_choice;Password=rootpass");

    }
    
    [HttpGet, Route("/universities")]
    public async Task<List<University>> GetUniversities()
    {
        var getAllUniversityUc = new GetAllUniversity(_universityRepo);
        List<University> result;
        try
        {
            result = await getAllUniversityUc.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }

    [HttpGet, Route("/university")]
    public async Task<University> GetUniversityByCode([FromQuery
        (Name = "code")] string code = "QSB")
    {
        var getUniversityByCodeUc = new GetUniversityByCode(_universityRepo, code);
        University result;
        try
        {
            result = await getUniversityByCodeUc.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }
}