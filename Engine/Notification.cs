using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;

namespace Engine
{
    public class Notification : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            // ? after a variable performs a null check before calling the following method
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
