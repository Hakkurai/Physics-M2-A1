using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetBase : MonoBehaviour
{
    public float mass = 1000f; // Mass of the planet
    public float gravity = 9.81f; // Gravitational force
    public List<Moon> moons = new List<Moon>(); // List of moons

    // Abstract method for applying gravity
    public abstract void ApplyGravity(Moon moon);
}
