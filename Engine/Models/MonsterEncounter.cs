using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class MonsterEncounter
    {
        public int MonsterID { get; set; }
        public int EncounterChance { get; set; }

        public MonsterEncounter(int monsterID, int encounterChance)
        {
            MonsterID = monsterID;
            EncounterChance = encounterChance;
        }
    }
}
