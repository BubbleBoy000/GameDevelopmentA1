using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NeedlePowerUp : MonoBehaviour
{
    public int clicksToActivate = 5;
    private int clickCount = 0;
    public GameObject popEffect; // Particle effect prefab to instantiate on pop

    void Update()
    {
        // Nothing needed here for this feature
    }

    void OnMouseDown()
    {
        clickCount++;
        if (clickCount >= clicksToActivate)
        {
            PopAllBalloons();
            Destroy(gameObject);
        }
    }

    void PopAllBalloons()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
        if (popEffect != null)
            {
                Instantiate(popEffect, transform.position, Quaternion.identity);
            }
        foreach (GameObject balloon in balloons)
        {
            Destroy(balloon);
        }
    }
}
