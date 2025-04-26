

using System;
using System.Collections.Generic;

abstract class EmergencyUnit
{
    public string Name { get; set; }
    public int Speed { get; set; }

    public EmergencyUnit(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public abstract bool CanHandle(string incidentType);
    public abstract void RespondToIncident(Incident incident);
}

class Police : EmergencyUnit
{
    public Police(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Crime";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is responding to a crime at {incident.Location}.");
    }
}

class Firefighter : EmergencyUnit
{
    public Firefighter(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Fire";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is extinguishing fire at {incident.Location}.");
    }
}

class Ambulance : EmergencyUnit
{
    public Ambulance(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Medical";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is treating patients at {incident.Location}.");
    }
}

class EMT : EmergencyUnit
{
    public EMT(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Medical";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is providing emergency medical treatment at {incident.Location}.");
    }
}

class SAR : EmergencyUnit
{
    public SAR(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Search and Rescue";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is conducting search and rescue operations at {incident.Location}.");
    }
}

class Incident
{
    public string Type { get; set; }
    public string Location { get; set; }
    public int Difficulty { get; set; } // Difficulty from 1 to 5

    public Incident(string type, string location, int difficulty)
    {
        Type = type;
        Location = location;
        Difficulty = difficulty;
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        List<EmergencyUnit> units = new List<EmergencyUnit>
        {
            new Police("Police Unit 1", 60),
            new Firefighter("Firefighter Unit 1", 50),
            new Ambulance("Ambulance Unit 1", 70),
            new EMT("EMT Unit 1", 65),
            new SAR("SAR Unit 1", 45)
        };

        string[] incidentTypes = { "Fire", "Crime", "Medical", "Search and Rescue", "Earthquake", "Flood" };
        string[] locations = { "Central Park", "Downtown", "City Hall", "University", "Mall" };

        Console.WriteLine("Select simulation mode:");
        Console.WriteLine("1. Automatically-Respond ");
        Console.WriteLine("2. Manual-Respond ");
        Console.Write("Enter your choice(1 - 2) ");
        string choice = Console.ReadLine();

        bool isAuto = choice == "1";
        int score = 0;

        for (int turn = 1; turn <= 5; turn++)
        {
            Console.WriteLine($"\n--- Turn {turn} ---");

            string type = incidentTypes[random.Next(incidentTypes.Length)];
            string location = locations[random.Next(locations.Length)];
            int difficulty = random.Next(1, 6); // Difficulty from 1 to 5
            Incident incident = new Incident(type, location, difficulty);

            Console.WriteLine($"Incident: {type} at {location} (Difficulty: {difficulty})");

            int pointsAwarded = difficulty * 10; // Base points for handling the incident

            if (isAuto)
            {
                bool handled = false;
                foreach (var unit in units)
                {
                    if (unit.CanHandle(type))
                    {
                        unit.RespondToIncident(incident);
                        Console.WriteLine($"+{pointsAwarded} points");
                        score += pointsAwarded;
                        handled = true;
                        break;
                    }
                }

                if (!handled)
                {
                    Console.WriteLine("No unit available to handle this incident.");
                    Console.WriteLine("-5 points");
                    score -= 5;
                }
            }
            else // Manual-Respond mode
            {
                Console.WriteLine("Choose a unit to respond:");
                for (int i = 0; i < units.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {units[i].Name}");
                }

                Console.Write("Enter choice (1-5): ");
                string unitChoice = Console.ReadLine();
                int selectedIndex;

                if (int.TryParse(unitChoice, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= units.Count)
                {
                    EmergencyUnit selectedUnit = units[selectedIndex - 1];
                    if (selectedUnit.CanHandle(type))
                    {
                        selectedUnit.RespondToIncident(incident);
                        Console.WriteLine($"+{pointsAwarded} points");
                        score += pointsAwarded;
                    }
                    else
                    {
                        Console.WriteLine($"{selectedUnit.Name} cannot handle this type of incident.");
                        Console.WriteLine("-5 points");
                        score -= 5;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. -5 points.");
                    score -= 5;
                }
            }

            // Adding a bonus for faster response
            int responseTimeBonus = difficulty <= 3 ? 5 : 10; // easier incidents give smaller bonus
            score += responseTimeBonus;
            Console.WriteLine($"Response time bonus: {responseTimeBonus} points");

            Console.WriteLine($"Current Score: {score}");
        }

        Console.WriteLine($"\nFinal Score: {score}");
        Console.WriteLine("Simulation complete.");
    }
}
