using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetAllProvince: IUsecase<List<Province>>
{

    private readonly IProvinceRepo _provinceRepo;

    public GetAllProvince(IProvinceRepo provinceRepo)
    {
        _provinceRepo = provinceRepo;
    }
    
    public Task<List<Province>> ExecuteUsecase()
    {
        return _provinceRepo.GetAllProvince();
    }
}