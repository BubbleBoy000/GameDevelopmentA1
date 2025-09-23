using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DelateEffect : MonoBehaviour
{
    public int timer = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
