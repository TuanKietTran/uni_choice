using server.Usecase.Repo;
using MySqlConnector;
using server.Domain;

namespace server.Repository;

public class MysqlRepo : IProvinceRepo
{
    private readonly string _connectionString;

    public MysqlRepo(string connectionString)
    {
        _connectionString = connectionString;
        try
        {
            var connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Can't connect DB. Error: {0}", e);
        }
    }

    public Task<List<Province>> GetAllProvince()
    {
        throw new NotImplementedException();
    }

    public async Task<Province> GetProvinceByCode(int code)
    {
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM dimprovince WHERE dimprovince.ProvinceCode = @code";
        cmd.Parameters.AddWithValue("@code", code);
        await using var reader = cmd.ExecuteReaderAsync().Result;
        {
            if (!reader.Read())
            {
                throw new ProvinceNotFound(code);
            }

            return new Province
            {
                ProvinceCode = reader.GetInt16(0),
                ProvinceName = reader.GetString(1)
            };
        }
    }
}