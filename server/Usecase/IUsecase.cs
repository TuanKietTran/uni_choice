namespace server.Usecase;

public interface IUsecase<TEntity>
{
    protected Task<TEntity> ExecuteUsecase();
}