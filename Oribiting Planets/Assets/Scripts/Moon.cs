using UnityEngine;

public class Moon : MonoBehaviour
{
    public Rigidbody rb;
    public PlanetBase planet;
    public float orbitSpeed = 5f;
    public float stabilizationSpeed = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (planet != null)
        {
            // Apply gravity force from the planet
            planet.ApplyGravity(this);

            // Orbit around the planet
            Vector3 orbitDirection = Vector3.Cross(transform.position - planet.transform.position, Vector3.up);
            rb.linearVelocity = orbitDirection.normalized * orbitSpeed;

            // Stabilize orbit using Lerp
            transform.position = Vector3.Lerp(transform.position, GetStableOrbitPosition(), Time.deltaTime * stabilizationSpeed);
        }
    }

    public void ApplyForce(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Acceleration);
    }

    private Vector3 GetStableOrbitPosition()
    {
        Vector3 direction = (transform.position - planet.transform.position).normalized;
        return planet.transform.position + direction * 5f; // Set a stable orbit radius
    }
}
