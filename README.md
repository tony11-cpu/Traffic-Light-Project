# MyTrafficLightProj

A custom WinForms Traffic Light UserControl in C# that cycles through Red, Green, and Orange lights with a live countdown and configurable durations.

---

## Features

- Auto-cycles Red → Green → Orange
- Configurable duration per light
- Live countdown timer
- Events fired on each light change
- Async/await, non-blocking UI
- Start / Stop support

---

## How It Works

Drop the control on any WinForms form, set the durations for each light, and call Start. The control handles the rest — cycling through each light, counting down, and firing events so your form can react to each change.

---

## Built With

- C# .NET Framework
- WinForms
- async / await + CancellationToken

---

## Author

Tony — self-taught C# developer building real-world Windows desktop projects.
