using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageName { get; }
        public List<Quest> QuestsAvailableHere { get; } = 
            new List<Quest>();
        public List<MonsterEncounter> MonstersHere { get; } =
            new List<MonsterEncounter>();

        public Trader TraderHere { get; set; }

        public Location(int xCoordinate, int yCoordinate, string name,
            string description, string imageName)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ImageName = imageName;
        }

        public void AddMonster(int monsterID, int encounterChance)
        {
            // If monster is already present, update encounter chance
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                MonstersHere.First(m => m.MonsterID == monsterID)
                    .EncounterChance = encounterChance;
            }
            // Otherwise, add new monster
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterID, encounterChance));
            }
        }

        public Monster FindMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }
            
            /* The total percentage (encounter chance) of all monsters at
            the location */
            int totalChances = MonstersHere.Sum(m => m.EncounterChance);

            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            /* For every monster, if the random number generated is less than
             * the chance of encountering (i.e. within the encounter chance),
             * then return that monster.
             */
            int currentTotal = 0;

            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                currentTotal += monsterEncounter.EncounterChance;

                if (randomNumber <= currentTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            // Fail-safe
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}
