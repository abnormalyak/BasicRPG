using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class QuestStatus
    {
        public Quest Quest { get; set; }
        public bool IsComplete { get; set; }

        public QuestStatus(Quest quest)
        {
            Quest = quest;
            IsComplete = false;
        }
    }
}
