using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetAllUniversity: IUsecase<List<University>>
{

    private readonly IUniversityRepo _universityRepo;

    public GetAllUniversity(IUniversityRepo universityRepo)
    {
        _universityRepo = universityRepo;
    }
    
    public Task<List<University>> ExecuteUsecase()
    {
        return _universityRepo.GetAllUniversity();
    }
}