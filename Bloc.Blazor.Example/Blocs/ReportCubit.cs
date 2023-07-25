using Bloc.Blazor.Example.Services;
using Bloc.Blazor.Example.States;
using Bloc.Models;

namespace Bloc.Blazor.Example.Blocs;

public class ReportCubit : Cubit<ReportState>
{
    private readonly IReportService _reportService;

    public ReportCubit(IReportService reportService) : base(new ReportInitial())
    {
        _reportService = reportService;
    }

    public async void LoadReports(int page = 1, int pageSize = 3)
    {
        try
        {
            if (State is ReportInitial)
            {
                Emit(new ReportFirstTimeLoading());
            }
            else if (State is ReportIsLoaded)
            {
                var currentState = State as ReportIsLoaded;
                Emit(new ReportIsLoadPaging(currentState.Reports));
            }

            var reports = await _reportService.GetReports();
            Emit(new ReportIsLoaded(reports));
        }
        catch (Exception e)
        {
            Emit(new ReportLoadedError("Could not load reports"));
        }
    }

    public async void DeleteReport(int index)
    {
        if (State is ReportIsLoaded)
        {
            var currentState = State as ReportIsLoaded;
            var reports = currentState.Reports;
            currentState.Reports.RemoveAt(index);
            var newState = new ReportIsLoaded(reports);
            Emit(newState);
        }
    }
}