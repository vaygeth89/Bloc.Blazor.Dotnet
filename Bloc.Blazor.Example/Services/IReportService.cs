namespace Bloc.Blazor.Example.Services;

public interface IReportService
{
    Task<List<string>> GetReports(int delayInSeconds =3);
}