      Zewdu Werede DBU1501601

# 🚨 Emergency Response Simulation

## Overview
This project simulates an **Emergency Response System** where different emergency units (like Police, Firefighters, EMTs, Ambulance, and Search and Rescue) respond to random incidents across a city.

The simulation allows you to either:
- **Auto-respond**: Units automatically handle incidents.
- **Manual-respond**: You manually select which unit responds to an incident.

Your **score** increases or decreases based on how well the incidents are handled!

---

## Features
- Different types of emergency units:
  - Police 🚓
  - Firefighter 🚒
  - Ambulance 🚑
  - EMT 👨‍⚕️
  - Search and Rescue 🧭
- Randomly generated incidents like:
  - Crime
  - Fire
  - Medical emergencies
  - Search and Rescue missions
- Automatic or Manual response modes
- Scoring system based on:
  - Correct handling
  - Difficulty of the incident
  - Response time bonuses

---

## How to Run
1. Make sure you have **.NET SDK** installed ([Download Here](https://dotnet.microsoft.com/en-us/download)).
2. Save the code into a file named something like:  
   ```bash
   EmergencySimulation.cs
   ```
3. Open a terminal in the file's directory and compile:
   ```bash
   dotnet new console -o EmergencySimulation
   cd EmergencySimulation
   Replace the auto-generated `Program.cs` with your saved code.
   dotnet run
   ```

---

## How the Game Works
1. **Choose a mode**:  
   - **Auto**: The system picks the best unit.
   - **Manual**: You pick which unit should respond.
   
2. **Incidents appear randomly** each turn:
   - Incidents have a **type** (like Fire, Crime, etc.)
   - Each has a **difficulty level** from 1 (easy) to 5 (hard).

3. **Score Points**:
   - Correctly responding gains points (`difficulty * 10` + bonus).
   - Incorrect response or wrong selection loses 5 points.
   - Faster incidents (easier ones) give smaller bonuses; harder ones give bigger bonuses.

4. **Final Score** is displayed after 5 turns!

---

## Example Gameplay

```
Select simulation mode:
1. Automatically-Respond
2. Manual-Respond
Enter your choice(1 - 2) 1

--- Turn 1 ---
Incident: Crime at Downtown (Difficulty: 3)
Police Unit 1 is responding to a crime at Downtown.
+30 points
Response time bonus: 5 points
Current Score: 35
```

---

## Future Improvements (Optional Ideas 💡)
- Add more emergency unit types (e.g., Disaster Response Teams).
- Introduce multiple simultaneous incidents.
- Add a time-based penalty for delayed manual response.
- Create a GUI version using Windows Forms or WPF.
- Add unit stamina, availability, or failure rates.

---



---

