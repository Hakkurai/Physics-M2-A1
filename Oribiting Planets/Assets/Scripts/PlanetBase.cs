using UnityEngine;
using System.Collections.Generic;

public abstract class PlanetBase : MonoBehaviour
{
    public float mass = 1000f; // Affects gravity
    public float gravityStrength = 100f; // Higher values pull moons more

    // List of moons affected by this planet
    protected List<Moon> moons = new List<Moon>();

    public abstract void ApplyGravity();

    public void RegisterMoon(Moon moon)
    {
        if (!moons.Contains(moon))
            moons.Add(moon);
    }
}
