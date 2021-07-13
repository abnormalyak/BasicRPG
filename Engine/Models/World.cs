using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        internal void AddLocation(int xCoord, int yCoord, string name,
            string description, string imgName)
        {
            _locations.Add(new Location(xCoord, yCoord, name, 
                description, $"pack://application:,,,/Engine;component/Images/Locations/{imgName}"));
        }

        public Location LocationAt(int xCoord, int yCoord)
        {
            foreach (Location l in _locations)
            {
                if (l.XCoordinate == xCoord && l.YCoordinate == yCoord)
                {
                    return l;
                }
            }

            return null;
        }
    }
}
