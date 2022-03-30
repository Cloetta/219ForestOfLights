using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PULIRE

public class MouseController : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation;

    private void Start()
    {
        xRotation = 0f;
        //Makes the cursor disappear from the screen when in playmode and lock it at the center of the screen.
        Cursor.lockState = CursorLockMode.Locked;        
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; //https://www.youtube.com/watch?v=_QajrabyTJc 

        //Limits the vertical rotation of the mouse to 90° both up and down, so that the body doesn't end up rotating on itself.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector2.up * mouseX);

    }
}
