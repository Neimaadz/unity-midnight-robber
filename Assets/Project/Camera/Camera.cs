using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float zCamValue;
    [SerializeField] private float yCamValue;
    [SerializeField] private float camTransition;
    [SerializeField] private int yCoeff = 2;
    public Transform player;
    public float mouseSensitivity = 800f; // Sensitivity of the mouse movement

    private float xRotation = 0f; // Store the current x rotation

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // LateUpdate is called after all action are done
    void LateUpdate()
    {
        Vector3 playerCamPos = player.transform.position - (player.transform.forward * zCamValue)  + (Vector3.up * yCamValue);

        // transition camera between current and future position with the delay
        transform.position = Vector3.Lerp(transform.position, playerCamPos, camTransition);

        transform.LookAt(player.transform.position + Vector3.up * (yCamValue / yCoeff));
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply mouse input to rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the vertical rotation to avoid flipping

        // Apply rotation to camera and player body
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
