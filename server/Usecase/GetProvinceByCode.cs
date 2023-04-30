using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetProvinceByCode: IUsecase<Province>
{

    private readonly IProvinceRepo _provinceRepo;
    private readonly int _code;

    public GetProvinceByCode(IProvinceRepo provinceRepo, int code)
    {
        _provinceRepo = provinceRepo;
        _code = code;
    }
    
    
    public Task<Province> ExecuteUsecase()
    {
        return _provinceRepo.GetProvinceByCode(_code);
    }
}