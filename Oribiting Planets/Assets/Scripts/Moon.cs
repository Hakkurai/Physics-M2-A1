using UnityEngine;

public class Moon : MonoBehaviour
{
    private Rigidbody rb;
    public Transform planet;
    public float orbitSpeed = 5f;  // Controls how fast the moon orbits

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // Prevent Unity gravity from interfering

        // Give the moon an initial orbit velocity
        Vector3 direction = (transform.position - planet.position).normalized;
        Vector3 perpendicularDirection = Vector3.Cross(direction, Vector3.up).normalized;

        rb.linearVelocity = perpendicularDirection * orbitSpeed;
    }

    void FixedUpdate()
    {
        ApplyGravity();
    }

    void ApplyGravity()
    {
        if (planet == null) return;

        Vector3 direction = (planet.position - transform.position).normalized;
        float distance = Vector3.Distance(planet.position, transform.position);
        float gravityStrength = 100f / Mathf.Pow(distance, 2); // Inverse square law

        rb.AddForce(direction * gravityStrength, ForceMode.Acceleration);
    }

    public void ApplyForce(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Acceleration);
    }
}
