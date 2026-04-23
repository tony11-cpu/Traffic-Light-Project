# 🚦 Traffic Light Control System

> A production-ready WinForms UserControl implementing a realistic traffic light simulation with asynchronous state management, customizable timing, and event-driven architecture.

---

## 📋 Overview

**Traffic Light Control System** is a sophisticated Windows Forms component that models real-world traffic light behavior with precise timing control and extensible event architecture. Rather than a simple visual control, this project demonstrates solid object-oriented design principles applied to hardware simulation—ideal for educational projects, traffic management systems, or GUI component development.

The control operates with **asynchronous non-blocking execution**, automatically cycles through light states (Red → Green → Orange → Red), and exposes rich event notifications for downstream consumers to react to state changes.

---

## ✨ Features

- **Autonomous Light Cycling** – Self-managing state machine that cycles through traffic light states without blocking the UI thread
- **Configurable Durations** – Independently set duration for each light state (Red, Green, Orange) via public properties
- **Live Countdown Display** – Real-time countdown timer synchronized with the current light state, color-coded for visual clarity
- **Event-Driven Architecture** – Dedicated event handlers (`OnRedLight`, `OnGreenLight`, `OnOrangeLight`) expose state transitions with metadata
- **Cancellation Support** – Graceful shutdown via `CancellationTokenSource` for clean resource management
- **Async/Await Pattern** – Non-blocking implementation using `Task.Delay()` ensures UI responsiveness during long durations
- **Reusable UserControl** – Drop-in WinForms component—instantiate multiple independent traffic lights in a single application

---

## 🏗️ Architecture & Design Decisions

### **Core Components**

| Component | Purpose |
|-----------|---------|
| `ctrlTrafic` | Main UserControl encapsulating traffic light logic and state management |
| `clsClassArgs.StatusChangedEventArgs` | Custom `EventArgs` class carrying state change metadata (status string, duration in seconds) |
| `enLightState` (Enum) | Strongly-typed light states (Red=1, Orange=2, Green=3) for type safety |

### **Design Patterns Applied**

1. **State Machine Pattern**
   - Discrete state representation via `enLightState` enum
   - State transitions enforced through property setter logic in `CurrentTraficStatus`
   - Each state invokes its corresponding visual update method (`_RedLight_Invokation()`, etc.)

2. **Event Aggregator Pattern**
   - Three specialized events (`OnRedLight`, `OnGreenLight`, `OnOrangeLight`) allow subscribers to react to specific state changes
   - `StatusChangedEventArgs` carries rich contextual data (state name, duration)
   - Decouples control logic from consumer logic via event subscription

3. **Async/Await with Cancellation**
   - `_RunLighy()` loop executes asynchronously, preventing UI thread stalls
   - `_EveryInterval()` method ticks countdown every 1000ms using `Task.Delay()` for precision
   - `CancellationTokenSource` enables clean, immediate shutdown without resource leaks

4. **Separation of Concerns**
   - Visual updates (`_RedLight_Invokation()`, `_OrangeLight_Invokation()`, `_GreenLight_Invokation()`) isolated from timing logic
   - Event invocation abstracted into `_LightChange_EventInvoke()`
   - Properties (`RedDuration`, `GreenDuration`, `OrangeDuration`) expose configuration without exposing internal state

### **Technical Strengths**

- **No UI Thread Blocking** – Task-based async pattern ensures the application remains responsive during long countdown intervals
- **Resource-Safe Shutdown** – `CancellationTokenSource` provides a signal for the background loop to exit gracefully
- **Type Safety** – Enum-based state representation prevents invalid state values
- **Immutable Event Data** – `StatusChangedEventArgs` uses read-only properties to prevent accidental mutation by subscribers
- **Configurable State Durations** – Byte-typed properties (0–255 seconds) for memory efficiency

---

## 🔄 How It Works

### **Lifecycle**

1. **Initialization** – Control loads in its initial state (Red, 10 seconds) when placed on a form
2. **Start Sequence** – Call `Start()` to begin the autonomous cycling loop
3. **Active Cycling** – The control transitions states at regular intervals:
   - Red (10s) → Green (15s) → Orange (5s) → Red (repeat)
4. **Event Emission** – On each state change, the corresponding event fires with metadata
5. **Live Display Update** – Label displays countdown (e.g., "10", "9", "8"...), color-coded per state
6. **Graceful Termination** – Call `Stop()` to cancel the background task

### **State Transition Flow**

```
Start (Red @ 10s countdown)
    ↓
Wait 10s (countdown: 10→0)
    ↓
Transition to Green @ 15s countdown
    ↓
Wait 15s (countdown: 15→0)
    ↓
Transition to Orange @ 5s countdown
    ↓
Wait 5s (countdown: 5→0)
    ↓
Loop back to Red
```

---

## 🛠️ Setup & Installation

### **Prerequisites**

- **.NET Framework 4.7.2+** (or target framework specified in `.csproj`)
- **Visual Studio 2019+** or any C# IDE supporting WinForms
- Windows OS (WinForms is Windows-specific)

### **Quick Start**

1. **Clone the Repository**
   ```bash
   git clone https://github.com/tony11-cpu/Traffic-Light-Project.git
   cd Traffic-Light-Project
   ```

2. **Open the Solution**
   ```bash
   # Using Visual Studio
   start MyTraficLightProj.sln
   
   # Or open manually in your IDE
   ```

3. **Build the Project**
   - Press `Ctrl+Shift+B` or go to **Build → Build Solution**

4. **Run the Application**
   - Press `F5` or click **Debug → Start Debugging**

---

## 💡 Usage

### **Basic Integration in a Form**

```csharp
// In your Form's designer or code-behind
ctrlTrafic trafficControl = new ctrlTrafic();

// Configure durations (in seconds)
trafficControl.RedDuration = 10;
trafficControl.GreenDuration = 15;
trafficControl.OrangeDuration = 5;

// Subscribe to events
trafficControl.OnRedLight += (sender, args) => {
    Console.WriteLine($"🔴 {args.NewStatus} for {args.Duration}s");
};

trafficControl.OnGreenLight += (sender, args) => {
    Console.WriteLine($"🟢 {args.NewStatus} for {args.Duration}s");
};

trafficControl.OnOrangeLight += (sender, args) => {
    Console.WriteLine($"🟠 {args.NewStatus} for {args.Duration}s");
};

// Add to form and start
this.Controls.Add(trafficControl);
await trafficControl.Start();  // Runs asynchronously

// Stop when needed
trafficControl.Stop();  // Cancels the cycling loop
```

### **Real-World Example**

```csharp
// Traffic intersection with multiple lights
var northSouthLight = new ctrlTrafic { RedDuration = 20, GreenDuration = 25, OrangeDuration = 4 };
var eastWestLight = new ctrlTrafic { RedDuration = 25, GreenDuration = 20, OrangeDuration = 4 };

// Log state changes to a monitoring system
northSouthLight.OnGreenLight += async (s, args) => {
    await LogToTrafficSystemAsync("N/S", args.NewStatus, args.Duration);
};

// Start both independently
_ = northSouthLight.Start();  // Fire-and-forget async tasks
_ = eastWestLight.Start();
```

---

## 🔮 Future Enhancements

- **Pedestrian Signal Integration** – Add crosswalk countdown and pedestrian crossing events
- **Adaptive Timing** – Machine learning-based duration adjustment based on traffic density
- **Multi-Phase Support** – Support advanced intersection patterns (left-turn arrows, advanced green)
- **Data Persistence** – Save/load timing configurations per intersection
- **Remote Control API** – REST endpoint to dynamically adjust light durations and state
- **Accessibility Features** – Audio alerts for visually impaired pedestrians
- **Theme Customization** – Pluggable image resources for different traffic light styles
- **Performance Metrics** – Track state change frequency and average cycle time

---

## 📊 Project Metadata

- **Language:** C# (.NET Framework)
- **Framework:** Windows Forms (WinForms)
- **Architecture:** Component-based, event-driven
- **Async Model:** Task-based Asynchronous Pattern (TAP)
- **License:** Open Source
- **Status:** Production-Ready

---

## 🤝 Contributing

Contributions are welcome! Please:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit changes with clear messages
4. Push to your branch and open a Pull Request

---

**Built with precision. Designed for scale.** 🚦✨