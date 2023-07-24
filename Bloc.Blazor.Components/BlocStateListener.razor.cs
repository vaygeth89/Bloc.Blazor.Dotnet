using Bloc.Models;
using Microsoft.AspNetCore.Components;

namespace Bloc.Blazor.Components;

public partial class BlocStateListener<TBloc, TState> : ComponentBase
    where TBloc : BlocBase<TState> where TState : BlocState
{
    [Parameter] public RenderFragment? ChildContent { get; set; } = default!;
    [Inject] public BlocBuilder<TBloc, TState> Builder { get; set; }
    [Parameter] public EventCallback<TState> OnInitializeState { get; set; }
    [Parameter] public EventCallback<TState> OnStateChange { get; set; }

    protected override void OnInitialized()
    {
        Builder.Bloc.OnStateChanged += ListenToChanges;
        OnInitializeState.InvokeAsync(Builder.State);
        base.OnInitialized();
    }

    private async void ListenToChanges(TState state)
    {
        await OnStateChange.InvokeAsync(state);
    }
}