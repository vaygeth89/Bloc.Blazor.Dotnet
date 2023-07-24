# Bloc Blazor

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
* States
  * Class responsible for holding data that is expected to be changed by User/System Events
* BLoC/Cubit
  * Class responsible for Coordinating the User/System Events to Produce New States
* Events 
  * BLoC/Cubit Class Methods that can be triggered/called to execute the Business Logic in order to mutate the State
* BLoCBuilder
  * Class responsible to wrap both the BLoC and State in order to be shared and listened to
* BlocListener Component
  * Razor component that simplifies listening to changes

### Disclosure & Notes
As if now the package is in early release, and enhancements is still required



