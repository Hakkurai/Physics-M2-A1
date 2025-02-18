using UnityEngine;

public class Moon : MonoBehaviour
{
    private Rigidbody rb;
    public PlanetBase planet;  // Assign this in Unity Inspector
    public float orbitSpeed = 5f;  // Adjust to balance orbit

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // Prevent Unity�s built-in gravity

        planet.RegisterMoon(this); // Register moon to the planet

        // Set initial velocity perpendicular to planet's position
        Vector3 direction = (transform.position - planet.transform.position).normalized;
        Vector3 orbitDirection = Vector3.Cross(direction, Vector3.up).normalized;

        rb.linearVelocity = orbitDirection * orbitSpeed;
    }

    void FixedUpdate()
    {
        if (planet != null)
        {
            planet.ApplyGravity(); // Planet applies gravity
            StabilizeOrbit();
        }
    }

    public void ApplyForce(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Acceleration);
    }

    void StabilizeOrbit()
    {
        // Ensure the moon's movement is balanced between falling and forward movement
        Vector3 toPlanet = (planet.transform.position - transform.position).normalized;
        Vector3 velocityDirection = rb.linearVelocity.normalized;
        rb.linearVelocity = Vector3.Lerp(velocityDirection, Vector3.Cross(toPlanet, Vector3.up), Time.deltaTime * 0.1f) * orbitSpeed;
    }
}
