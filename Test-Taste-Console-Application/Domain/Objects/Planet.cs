// Planet.cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity { get; set; } // Add AverageMoonGravity property

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                }
            }
            // Initialize AverageMoonGravity property
            AverageMoonGravity = CalculateAverageMoonGravity(Moons);
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }

        private float CalculateAverageMoonGravity(ICollection<Moon> moons)
        {
            if (moons == null || moons.Count == 0)
                return 0.0f;

            float totalMoonGravity = 0.0f;
            foreach (var moon in moons)
            {
                totalMoonGravity += moon.Gravity;
            }
            return totalMoonGravity / moons.Count;
        }
    }
}
