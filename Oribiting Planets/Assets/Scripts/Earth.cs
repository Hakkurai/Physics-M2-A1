using UnityEngine;
public class Earth : PlanetBase
{
    private void Start()
    {
        gravity = 9.81f; // Earth's gravity
    }

    public override void ApplyGravity(Moon moon)
    {
        Vector3 direction = (transform.position - moon.transform.position).normalized;
        moon.ApplyForce(direction * gravity);
    }
}
