using Bloc.Models;

namespace Bloc.Blazor.Example.States;

public record CountState(int Count = 0) : BlocState;