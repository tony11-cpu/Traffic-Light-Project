# MyTrafficLightProj

A custom WinForms **Traffic Light UserControl** built in C# .NET. It cycles through Red, Green, and Orange lights automatically with configurable durations, a live countdown timer, and events you can subscribe to for each light change.

---

## Features

- Animated traffic light that cycles Red → Green → Orange automatically
- Configurable duration for each light (in seconds)
- Live countdown label that updates every second
- Custom events fired on each light change (`OnRedLight`, `OnOrangeLight`, `OnGreenLight`)
- Async/await based — non-blocking UI
- Start and Stop support with cancellation

---

## Project Structure

```
MyTrafficLightProj/
│
├── ctrlTrafic.cs         # The main UserControl — handles light cycling, timing, and events
├── clsClassArgs.cs       # Custom EventArgs class (StatusChangedEventArgs)
├── Form1.cs              # Demo form that starts the control and listens to events
└── Resources/            # Red, Orange, Green light images
```

---

## How to Use

**1. Drop the control on a form**

Add `ctrlTrafic` to your WinForms form via the designer or in code.

**2. Set durations (optional)**

```csharp
ctrlTrafic1.RedDuration    = 10;
ctrlTrafic1.GreenDuration  = 15;
ctrlTrafic1.OrangeDuration = 5;
```

**3. Start and stop**

```csharp
await ctrlTrafic1.Start();  // starts the cycle
ctrlTrafic1.Stop();         // cancels the cycle
```

**4. Subscribe to events**

```csharp
ctrlTrafic1.OnRedLight    += (s, e) => Console.WriteLine($"Red for {e.Duration}s");
ctrlTrafic1.OnGreenLight  += (s, e) => Console.WriteLine($"Green for {e.Duration}s");
ctrlTrafic1.OnOrangeLight += (s, e) => Console.WriteLine($"Orange for {e.Duration}s");
```

Each event passes a `StatusChangedEventArgs` with:
- `e.NewStatus` — the light name (`"RED"`, `"GREEN"`, `"ORANGE"`)
- `e.Duration` — how long that light lasts in seconds

---

## Screenshots

> _Add screenshots of the running control here_

---

## Built With

- C# .NET Framework
- Windows Forms (WinForms)
- `async` / `await` + `CancellationToken`

---

## Author

Tony — self-taught C# developer building real-world Windows desktop projects.
