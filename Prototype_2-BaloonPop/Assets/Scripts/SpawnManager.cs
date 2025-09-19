using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balloonPrefabs; // Array to store balloon objects
    public float startDelay = 0.5f;
    public float spawnInterval = 1f;
    public float xRange = 10f;
    public float ypos = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomBalloon", startDelay, spawnInterval);
    }

    void SpawnRandomBalloon()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), ypos, 0);
        int balloonIndex = Random.Range(0, balloonPrefabs.Length);
        Instantiate(balloonPrefabs[balloonIndex], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
        Debug.Log(spawnPos);
    }
}
