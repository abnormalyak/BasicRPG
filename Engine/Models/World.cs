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
            Location loc = new Location();
            loc.XCoordinate = xCoord;
            loc.YCoordinate = yCoord;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = imgName;

            _locations.Add(loc);
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
