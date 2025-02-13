using UnityEngine;
public class Mars : PlanetBase
{
    private void Start()
    {
        gravity = 3.71f; // Mars' gravity
    }

    public override void ApplyGravity(Moon moon)
    {
        Vector3 direction = (transform.position - moon.transform.position).normalized;
        moon.ApplyForce(direction * gravity);
    }
}
