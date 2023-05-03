using Microsoft.AspNetCore.Mvc;
using server.Domain;
using server.Repository;
using server.Usecase;
using server.Usecase.Repo;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ILogger<SearchController> _logger;
    private readonly IProvinceRepo _provinceRepo;

    public SearchController(ILogger<SearchController> logger)
    {
        _logger = logger;
        _provinceRepo = new MysqlRepo("Server=localhost;User ID=root;Database=uni_choice;Password=rootpass");

    }
    
    [HttpGet(Name = "GetProvince")]
    public async Task<Province> Get()
    {
        const int code = 1;
        var getProvinceByCodeUc = new GetProvinceByCode(_provinceRepo, code);
        Province result;
        try
        {
            result = await getProvinceByCodeUc.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }
}