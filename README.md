# 🚦 Traffic Light Control System

> WinForms UserControl for async, event-driven, auto-cycling traffic light simulation. State machine logic, live countdown, simple API.

---

## Overview
A reusable Windows Forms component that cycles autonomously between Red, Green, and Orange lights. It updates a countdown label, exposes events for each state, and is UI-thread safe (async/await inside). Hook events, set per-state durations, and you're ready to go.

*Class, file, and event names use one "f" — ctrlTrafic is intentional.*

---
## Features
- Autonomous async state machine — cycles Red → Green → Orange → Red
- Public duration props: RedDuration, GreenDuration, OrangeDuration
- Color-coded, live countdown display
- Event-driven — hooks for state change events
- CancellationToken-based stop (no UI freeze)
- Multiple controls on one form

---
## Architecture
- Enum defines the state: enLightState (Red, Orange, Green)
- Events for each state: OnRedLight, OnGreenLight, OnOrangeLight (currently, only OnRedLight is fired—extend _LightChange_EventInvoke if needed)
- Per-state invocation methods switch images/colors & relabel countdown
- All logic internally handles timing, events, and visual updates

---
## Setup & Installation
- .NET Framework 4.8
- Visual Studio 2019+
- Windows OS

```bash
git clone https://github.com/tony11-cpu/Traffic-Light-Project.git
cd Traffic-Light-Project
# Open MyTraficLightProj.sln in Visual Studio
# Build & run
```

---
## Usage
```csharp
var light = new ctrlTrafic { RedDuration = 10, GreenDuration = 15, OrangeDuration = 5 };
light.OnRedLight    += (s, e) => Console.WriteLine($"🔴 {e.NewStatus} — {e.Duration}s");
// Expand event firing for per-color events if you need
this.Controls.Add(light);
_ = light.Start();
// ... later
light.Stop();
```

**Multiple intersections:**
```csharp
var northSouth = new ctrlTrafic { RedDuration = 20, GreenDuration = 25, OrangeDuration = 4 };
var eastWest   = new ctrlTrafic { RedDuration = 25, GreenDuration = 20, OrangeDuration = 4 };
_ = northSouth.Start();
_ = eastWest.Start();
```

---
## Roadmap / Ideas
- Pedestrian/crosswalk logic
- Adaptive timing per load
- More realistic intersection phases

---
