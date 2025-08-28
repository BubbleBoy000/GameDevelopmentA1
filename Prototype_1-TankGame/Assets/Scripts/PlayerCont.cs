using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCont : MonoBehaviour
{
    public float speed; //speed for controller
    public float rotSpeed; //rotation speed for controller
    public float hInput; //store values for horizontal movement
    public float vInput; //store values for vertical movement

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, hInput * rotSpeed * Time.deltaTime); //Rotates side to side
        transform.Translate(Vector3.forward * vInput * speed * Time.deltaTime); //Move Forward and Back
    }
}
