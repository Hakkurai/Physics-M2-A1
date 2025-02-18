using UnityEngine;

public class Mars : PlanetBase
{
    void Start()
    {
        gravityStrength = 50f; // Stronger gravity
    }

    public override void ApplyGravity()
    {
        foreach (Moon moon in moons)
        {
            if (moon != null)
            {
                Vector3 direction = (transform.position - moon.transform.position).normalized;
                float distance = Vector3.Distance(transform.position, moon.transform.position);
                float gravityForce = (mass * gravityStrength) / Mathf.Pow(distance, 2); // Newton's Law

                moon.ApplyForce(direction * gravityForce);
            }
        }
    }
}
