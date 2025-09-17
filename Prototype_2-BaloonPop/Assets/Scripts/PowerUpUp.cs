using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpUp : MonoBehaviour
{
    public float speed = 3.0f;
    public float wiggleAmount = 0.5f;      // How far to wiggle left/right
    public float wiggleFrequency = 2.0f;   // How fast to wiggle

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate new position based on time
        float newY = startPosition.y + speed * (Time.time - Time.timeSinceLevelLoad);
        float wiggle = Mathf.Sin(Time.time * wiggleFrequency) * wiggleAmount;
        transform.position = new Vector3(startPosition.x + wiggle, newY, startPosition.z);
    }
}
