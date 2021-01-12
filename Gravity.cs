using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static float maxGravDist = 30f;


    public static float maxGravity = 0.1f;


    public GameObject[] planets;

    public float lookAngle;

    public Vector2 lookDirection;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        planets = GameObject.FindGameObjectsWithTag("black_holes");

        foreach (var planet in planets)
        {
            maxGravity = 1;
            maxGravDist = 10;

            var size = planet.transform.localScale.y;
            var Mass = size - 0.3f;

            maxGravity += Mass;
            maxGravDist += Mass * 1.2f;

            // Distance to the planet
            var dist = Vector3.Distance(planet.transform.position, transform.position);

            // Gravity
            var v = planet.transform.position - transform.position;
            rb.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
        }
    }
}