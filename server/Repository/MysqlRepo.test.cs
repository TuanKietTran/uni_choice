using Xunit;

namespace server.Repository;

public class MysqlRepoTest
{
    private const string ConnectionString = "Server=localhost;User ID=root;Database=uni_choice;Password=rootpass";
    private readonly MysqlRepo _repo = new MysqlRepo(ConnectionString);
    
    [Fact]
    public async void TestMajorInUni()
    {
        // Arrange

        // Act
        var result = await _repo.GetMajorsOfUni("QSB");

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Distinct(result);
    }

    [Fact]
    public async void TestTopMajorsByMark()
    {
        const int threshold = 100;
        
        var result = await _repo.GetTopMajorsByMark(threshold);

        // Assert
        Assert.NotEmpty(result);
        Assert.Distinct(result);
        Assert.NotNull(result);
        Assert.Equal(threshold, result.Count);
    }
    
    [Fact]
    public async void TestScore()
    {
        const string studentId = "10000002";
        const int year = 2018;
        var result = await _repo.GetMark(studentId, year);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async void TestLogic()
    {
        string majorCode = "106";
        string subjectGroup = "A01";
        var result = await _repo.GetMajorScoreByGroup(majorCode, subjectGroup);

        // Assert
        Assert.NotEqual(0.0, result);
    }
}