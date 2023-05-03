using server.Domain;

namespace server.Usecase.Repo;

public interface ISubjectRepo
{
    Task<List<string>> GetGroup(string groupCode);
}