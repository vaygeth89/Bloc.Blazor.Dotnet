using Bloc.Models;

namespace Bloc.Blazor.Example.States;

public abstract record ReportState() : BlocState;

public record ReportInitial() : ReportState;

public record ReportFirstTimeLoading() : ReportState;

public record ReportIsLoaded(List<string> Reports) : ReportState;

public record ReportIsLoadPaging(List<string> Reports) : ReportIsLoaded(Reports);

public record ReportLoadedError(string ErrorMessage) : ReportState;