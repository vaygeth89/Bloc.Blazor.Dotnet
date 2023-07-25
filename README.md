# BLoC Blazor

### Overview

This package aims to implement Business Logic Component (BLoC) Design Pattern for Handling State Changes. This package
is inspired from the Dart package https://pub.dev/packages/flutter_bloc

### What This Package Aims To Solve

* Listen To State Changes
* Share UI State Across Multiple Components
* Reduces UI Rebuilds Overhead by Calling StateHasChanged When Suits when there's no User Action
* Organize Code by Separating Business Logic from the UI Components
* Provides a Design Pattern For Developers that Handles Most Complex Scenarios

### About The Design Pattern

![](Bloc.Blazor.Example/Architecture.png)

### Classes/Interfaces

* **States**
    * Class responsible for holding data that is expected to be changed by User/System Events
* **BLoC/Cubit**
    * Class responsible for Coordinating the User/System Events to Produce New States
* **Events**
    * BLoC/Cubit Class Methods that can be triggered/called to execute the Business Logic in order to mutate the State
* **BLoCBuilder**
    * Class responsible to wrap both the BLoC and State in order to be shared and listened to
* **BlocListener Component**
    * Razor component that simplifies listening to changes

### How To Use

#### Setup
Add the required dependencies into your Project
```
  dotnet add package Vaygeth.Bloc
  dotnet add package Vaygeth.Bloc.Blazor
```

#### Creating State Class
Create the class that will hold the data. In this example we will use Counter example
```csharp

public record CountState(int Count = 0) : BlocState;

```

#### Creating BLoC/Cubit Class

```csharp

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

```

#### Injecting BLocBuilder

#### Program.cs
```csharp
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    // rest of the code....
    // ...

    builder.Services.AddScoped(sp => new BlocBuilder<CountCubit, CountState>(new CountCubit()));
    // rest of the code....
    // ...

    await builder.Build().RunAsync();
```

#### Handling Events
You can use the **Builder** to invoke the desired events, in this example **Increment**/**Decrement**

```csharp
    private void IncrementCount()
    {
        Builder.Bloc.Increment();
    }
```

#### Listening to State Changes

You have two options when it comes to listening to State changes:

* Using BlocBuilder
* Using BlocListener Razor Component

You can use whatever convenient

### Using BlocBuilder Class
You can register the listener in your OnInitialized method
#### Using BLocBuilder
In your Razor C# Class Component (Count.razor.cs)

Inject your builder in your component specifying the the BLoC/Cubit and State and listen to the changes

```csharp
[Inject]
private BlocBuilder<CountCubit, CountState> Builder { get; set; }

protected override void OnInitialized(){
   // Rest of the code
   // Here we are listenting to the changes and passing the new state to our listner method **ListenToChanges** 
   Builder.Bloc.OnStateChanged+= ListenToChanges;
   // Rest of the code
}

private void ListenToChanges(CountState newState){
   //Do whatever
   //Choose when you want to rebuild the UI
   StateHasChanged();
}

```


#### Using BlocListener Blazor Component
The second method, is just to Use the BlocStateListner Razor Component and Listen to it using **ListenToChanges**

In your Razor Component (Count.razor)
```html

<div>
    <h1>Welcome To Bloc Blazor</h1>
    <h3>Current Count @Count</h3>
</div>

<BlocStateListener TBloc="CountCubit" TState="CountState" OnInitializeState="ListenToChanges" OnStateChange="ListenToChanges">

</BlocStateListener>

```


### Disclosure & Notes

As of now the package is in early release, and enhancements is still required



