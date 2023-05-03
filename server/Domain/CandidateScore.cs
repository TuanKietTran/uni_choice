namespace server.Domain;

public class Score
{
    public string StudentId { get; set; } = string.Empty;
    public int ProvinceCode { get; set; }
    public int Year { get; set; }
    public double Literature { get; set; }
    public double Math { get; set; }
    public double English { get; set; }

    public double? Physics { get; set; } = null;
    public double? Chemistry { get; set; } = null;
    public double? Biology { get; set; } = null;

    public double? History { get; set; } = null;
    public double? Geography { get; set; } = null;
    public double? Civil { get; set; } = null;
}