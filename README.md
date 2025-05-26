Express Elevator is a time-based puzzle and management game where the player takes control of one or more elevators in a multi-story building. 
The challenge lies in efficiently managing the flow of passengers by navigating elevators, making quick decisions, and ensuring everyone reaches their desired floor as quickly and accurately as possible.

>Gameplay Video - https://drive.google.com/file/d/1fDjCLMzeTZgD0XXdBAGp73VVR7toGTbV/view?usp=drive_link

> Core Gameplay Loop:
- Passengers spawn on random floors with a visible destination below them.
- Players click to select a passenger, then click on an elevator to board them.
- Once boarded, the elevator moves to the correct floor and drops them off.
  

> In this project, I implemented several design patterns to ensure clean, modular, and scalable architecture:

 * I utilized the **Service Locator pattern** in the `GameService` to centrally manage and access core game systems and services.
 * To enable flexible communication between components, I applied **Dependency Injection**, allowing decoupled interactions across scripts.
 * The **Observer pattern** was used extensively, especially to manage interactions between elevators and passengers in a responsive and event-driven manner.
 * For level configuration, I leveraged **ScriptableObjects**, enabling easy creation and management of new levels without modifying the codebase.
 * Both **MVC (Model-View-Controller)** and **State Machine patterns** were applied to the Elevator and Passenger systems, promoting code reusability, separation of concerns, and maintainability.


