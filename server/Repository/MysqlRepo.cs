using server.Usecase.Repo;
using MySqlConnector;
using server.Domain;

namespace server.Repository;

public class MysqlRepo : IProvinceRepo, IUniversityRepo, IMajorRepo, ICandidateScoreRepo, IEqualScoreRepo
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

    public async Task<List<Province>> GetAllProvince()
    {
        var result = new List<Province>();
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM dimprovince";
        await using var reader = await cmd.ExecuteReaderAsync();
        {
            while (await reader.ReadAsync())
            {
                result.Add(new Province
                {
                    ProvinceCode = reader.GetInt16(0),
                    ProvinceName = reader.GetString(1)
                });
            }

            return result;
        }
    }

    public async Task<List<University>> GetAllUniversity()
    {
        var result = new List<University>();
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT DISTINCT UniCode, UniName FROM university";
        await using var reader = await cmd.ExecuteReaderAsync();
        {
            while (await reader.ReadAsync())
            {
                result.Add(new University
                (
                    reader.GetString(0),
                    reader.GetString(1)
                ));
            }

            return result;
        }
    }


    public async Task<List<Major>> GetTopMajorsByMark(int threshold = 20)
    {
        var result = new List<Major>();
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText =
            "SELECT DISTINCT UniCode, UniName, MajorCode, MajorName FROM university ORDER BY BenchMark DESC " +
            "LIMIT @threshold";
        cmd.Parameters.AddWithValue("@threshold", threshold);
        await using var reader = await cmd.ExecuteReaderAsync();
        {
            while (await reader.ReadAsync())
            {
                result.Add(new Major
                (
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                ));
            }

            return result;
        }
    }

    public async Task<double> GetMajorScoreByGroup(string majorCode, string groupCode)
    {
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText =
            "SELECT DISTINCT BenchMark, Year FROM university " +
            "where MajorCode = @majorCode " +
            "and SubjectGroup = @groupCode " +
            "Order by Year DESC";
        cmd.Parameters.AddWithValue("@majorCode", majorCode);
        cmd.Parameters.AddWithValue("@groupCode", groupCode);
        await using var reader = cmd.ExecuteReaderAsync().Result;
        {
            if (!reader.Read())
            {
                throw new Exception("Not Found");
            }
            return reader.GetDouble(0);
        }
    }

    public async Task<List<Major>> GetMajorsOfUni(string uniCode)
    {
        var result = new List<Major>();
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText =
            "SELECT DISTINCT UniCode, UniName, MajorCode, MajorName FROM university where UniCode = @uniCode";
        cmd.Parameters.AddWithValue("@uniCode", uniCode);
        await using var reader = await cmd.ExecuteReaderAsync();
        {
            while (await reader.ReadAsync())
            {
                result.Add(new Major
                (
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                ));
            }

            return result;
        }
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

    public async Task<University> GetUniversityByCode(string code)
    {
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT DISTINCT * FROM university WHERE university.Unicode = @code";
        cmd.Parameters.AddWithValue("@code", code);
        await using var reader = cmd.ExecuteReaderAsync().Result;
        {
            if (!reader.Read())
            {
                throw new UniNotFound(code);
            }

            return new University
            (
                reader.GetString(0),
                reader.GetString(1)
            );
        }
    }

    public async Task<Major> GetMajorByCode(string code)
    {
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM university WHERE university.Unicode = @code";
        cmd.Parameters.AddWithValue("@code", code);
        await using var reader = cmd.ExecuteReaderAsync().Result;
        {
            if (!reader.Read())
            {
                throw new UniNotFound(code);
            }

            return new Major
            (
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3)
            );
        }
    }

    public async Task<CandidateScore> GetMark(string studentId, int year)
    {
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM factscore WHERE studentID = @studentId AND year = @year";
        cmd.Parameters.AddWithValue("@studentId", studentId);
        cmd.Parameters.AddWithValue("@year", year);
        await using var reader = cmd.ExecuteReaderAsync().Result;
        {
            if (!reader.Read())
            {
                throw new IdNotFound(studentId);
            }

            var score = new CandidateScore
            {
                StudentId = reader.GetString(0),
                ProvinceCode = reader.GetInt16(10),
                Year = reader.GetInt16(11),
                Literature = reader.GetDouble(1),
                Math = reader.GetDouble(2),
                English = reader.GetDouble(3),
            };
            if (reader["physics"] != DBNull.Value) score.Physics = Math.Round(reader.GetDouble(4), 2);
            if (reader["chemistry"] != DBNull.Value) score.Chemistry = Math.Round(reader.GetDouble(5), 2);
            if (reader["biology"] != DBNull.Value) score.Biology = Math.Round(reader.GetDouble(6), 2);
            if (reader["history"] != DBNull.Value) score.History = Math.Round(reader.GetDouble(7), 2);
            if (reader["geography"] != DBNull.Value) score.Geography = Math.Round(reader.GetDouble(8), 2);
            if (reader["civil"] != DBNull.Value) score.Civil = Math.Round(reader.GetDouble(9), 2);

            return score;
        }
    }

    public async Task<List<string>> GetGroupSubject(string major)
    {
        var result = new List<string>();
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT DISTINCT SubjectGroup FROM university where MajorCode = @major";
        cmd.Parameters.AddWithValue("@major", major);
        await using var reader = await cmd.ExecuteReaderAsync();
        {
            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
            
            if (result.Count == 0) throw new MajorNotFound(major);

            return result;
        }
    }

    public async Task<List<string>> GetGroup(string groupCode)
    {
        var result = new List<string>();
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT DISTINCT subject FROM subjectgroup where id = @id";
        cmd.Parameters.AddWithValue("@id", groupCode);
        await using var reader = await cmd.ExecuteReaderAsync();
        {
            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
            
            if (result.Count == 0) throw new Exception("Not Found");

            return result;
        }
    }

    public async Task<HyperParam> GetParamBySubject(string subject)
    {
        await using var conn = new MySqlConnection(_connectionString);
        await using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM factequal WHERE subject = @subject";
        cmd.Parameters.AddWithValue("@subject", subject);
        await using var reader = cmd.ExecuteReaderAsync().Result;
        {
            if (!reader.Read())
            {
                throw new MajorNotFound(subject);
            }

            return new HyperParam
            {
                Mean = reader.GetDouble(1),
                Std = reader.GetDouble(2),
                MeanNow = reader.GetDouble(3),
                StdNow = reader.GetDouble(4)
            };
        }
    }
}