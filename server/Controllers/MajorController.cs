using Microsoft.AspNetCore.Mvc;
using server.Domain;
using server.Repository;
using server.Usecase;
using server.Usecase.Repo;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvinceController : ControllerBase
{
    private readonly ILogger<ProvinceController> _logger;
    private readonly IProvinceRepo _provinceRepo;

    public ProvinceController(ILogger<ProvinceController> logger)
    {
        _logger = logger;
        _provinceRepo = new MysqlRepo("Server=localhost;User ID=root;Database=uni_choice;Password=rootpass");

    }
    
    [HttpGet, Route("/provinces")]
    public async Task<List<Province>> GetProvinces()
    {
        var getAllProvinceUc = new GetAllProvince(_provinceRepo);
        List<Province> result;
        try
        {
            result = await getAllProvinceUc.ExecuteUsecase();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fetch failed");
            throw;
        }

        return result;
    }

    [HttpGet, Route("/province")]
    public async Task<Province> GetProvinceByCode([FromQuery
        (Name = "code")] int code = 1)
    {
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