using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpUp : MonoBehaviour
{
    public float speed = 3.0f;
    public float wiggleAmount = 0.5f;      // How far to wiggle left/right

    private Vector3 startPosition;
    private float startTime;
    private const float wiggleFrequency = 2.0f; // Fixed wiggle frequency

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        // Calculate elapsed time since start
        float elapsed = Time.time - startTime;
        float newY = startPosition.y + speed * elapsed;
        float wiggle = Mathf.Sin(Time.time * wiggleFrequency) * wiggleAmount;
        transform.position = new Vector3(startPosition.x + wiggle, newY, startPosition.z);
    }
}
