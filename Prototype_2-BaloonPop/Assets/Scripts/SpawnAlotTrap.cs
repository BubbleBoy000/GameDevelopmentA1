using UnityEngine;

public class SpawnAlotTrap : MonoBehaviour
{
    public GameObject[] balloonPrefabs; // Array to store balloon objects
    public float xRange = 1f;
    public float ypos = 0f;
    public int balloonsToSpawn = 10; // Number of balloons to spawn at once

    // Call this method when you want to trigger the trap (e.g., OnMouseDown or from another script)
    public void SpawnRandomBalloons()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        float minX = Camera.main.transform.position.x - horzExtent - 1f;
        float maxX = Camera.main.transform.position.x + horzExtent - 1f;

        for (int i = 0; i < balloonsToSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), ypos, 0);
            int balloonIndex = Random.Range(0, balloonPrefabs.Length);
            Instantiate(balloonPrefabs[balloonIndex], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
            Debug.Log(spawnPos);
        }
    }
}
