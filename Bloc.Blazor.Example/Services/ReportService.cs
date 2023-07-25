namespace Bloc.Blazor.Example.Services;

public class ReportService : IReportService
{
    public async Task<List<string>> GetReports(int delayInSeconds = 3)
    {
        await Task.Delay(new TimeSpan(0, 0, delayInSeconds));
        return new() { "Report 1", "Report 2", "Report 3" };
    }
}