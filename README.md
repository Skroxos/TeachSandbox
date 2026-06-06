# TechSandbox

[![Made with Unity](https://img.shields.io/badge/Made_with-Unity-000000.svg?style=for-the-badge&logo=unity)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)

A Unity-based sandbox for prototyping, exploring, and documenting game programming concepts — design patterns, game systems, performance techniques, and more.

Each topic lives in its own self-contained folder and was developed independently as a focused implementation exercise.

---

## Modules

### Design Patterns
Implementations of common software design patterns applied in a Unity context.

| Module | Pattern | Description |
|---|---|---|
| `Patterns/Decorator` | Decorator | Dynamically extend object behavior at runtime |
| `Patterns/Factory` | Factory | Centralized object creation with type abstraction |
| `Patterns/Command` | Command | Encapsulate actions as objects; supports undo/redo |
| `Patterns/Strategy` | Strategy | Swap algorithms/behaviors at runtime |
| `FSM` | Finite State Machine | Generic FSM for AI and game state management |
| `EventBus` | Event Bus | Decoupled pub/sub communication system with a live demo |

---

### Game Systems

| Module | Description |
|---|---|
| `Coding exercise` | Modular inventory system with a crafting system built on top |
| `BuffSystem` | Skeletal implementation of a stackable buff/debuff system |
| `Zero_GC` | Zero-allocation damage system using structs to avoid GC pressure |

---

### Unity & Performance

| Module | Description |
|---|---|
| `Addressables` | Async asset loading with Unity Addressables |
| `Async_Unitask` | Side-by-side comparison: Coroutine vs `async/await` vs UniTask |
| `PlayGround` | VContainer (DI framework) integration with REST API calls |
| `SpatialHashGrid` | Spatial hashing for fast proximity queries |
| `Multithreading` | Unity multithreading experiments (Job System, threads) |
| `MainMenu` | Hub scene with ScenePortals for modular scene navigation |
| `ExtensionMethod` | Utility extension methods for Unity types (e.g. `Vector3`) |

---

## Project Structure

```
Assets/
├── Addressables/          # Unity Addressables asset loading
├── Async_Unitask/         # Coroutine vs Async vs UniTask
├── BuffSystem/            # Buff/debuff system skeleton
├── Coding exercise/       # Inventory & crafting system
├── Editor/                # Custom Unity Editor tools
├── EventBus/              # Event Bus with demo
├── ExtensionMethod/       # C# extension methods for Unity
├── FSM/                   # Finite State Machine
├── MainMenu/              # Hub scene + ScenePortals
├── Multithreading/        # Unity multithreading examples
├── Patterns/              # Design patterns (Decorator, Factory, Command, Strategy)
├── PlayGround/            # VContainer DI + API calls demo
├── SpatialHashGrid/       # Spatial hashing for proximity queries
├── Zero_GC/               # Zero-allocation damage system
└── ZZ_TemplateFolder/     # Template for new modules
```

---

## Tech Stack

| Technology | Usage |
|---|---|
| Unity 2022+ | Game engine & editor |
| C# | Core logic and systems |
| UniTask | High-performance async for Unity |
| VContainer | Lightweight DI framework for Unity |

---

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/Skroxos/TechSandbox.git
```
2. Open the project in **Unity 2022+** via Unity Hub.
3. Open the **Hub scene** (`Assets/MainMenu`) to navigate between individual module demos via ScenePortals.

Each module folder contains its own scene(s) demonstrating the implemented concept.

---

## Purpose

This repository serves as a living reference and learning log — each module is a focused, self-contained proof of concept. The goal is to explore advanced Unity patterns and systems beyond what typical tutorials cover.
