using UnityEngine;
using TMPro; // Add this

public class DoorInteraction : MonoBehaviour
{
    public float interactDistance = 1f;
    public Camera playerCamera;
    public TextMeshProUGUI interactionText; // Change type

    private DoorScript.Door currentDoor;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
{
    var door = hit.collider.GetComponent<DoorScript.Door>();
    if (door != null)
    {
        currentDoor = door;
        interactionText.text = door.open ? "Press E to close" : "Press E to open";
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.OpenDoor();
        }
        return;
    }
}

        currentDoor = null;
        interactionText.text = "";
    }
}