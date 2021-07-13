using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class QuestStatus : Notification
    {
        private bool _isComplete;
        public Quest Quest { get; }
        public bool IsComplete {
            get { return _isComplete; }
            set 
            {
                _isComplete = value;
                OnPropertyChanged();
            } 
        }

        public QuestStatus(Quest quest)
        {
            Quest = quest;
            IsComplete = false;
        }
    }
}
