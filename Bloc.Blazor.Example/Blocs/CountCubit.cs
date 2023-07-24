using Bloc.Blazor.Example.States;
using Bloc.Models;

namespace Bloc.Blazor.Example.Blocs;

public class CountCubit : Cubit<CountState>
{
    public CountCubit() : base(new CountState())
    {
    }

    public void Increment()
    {
        int currentCount = State.Count;
        Emit(new CountState(currentCount + 1));
    }

    public void Decrement()
    {
        int currentCount = State.Count;
        if (currentCount > 0)
        {
            Emit(new CountState(currentCount - 1));
        }
    }
}