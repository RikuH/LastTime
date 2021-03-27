using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivy = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    public bool mouseEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseEnabled)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivy * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivy * Time.deltaTime;

            xRotation -= mouseY;
            yRotation += mouseX;

            xRotation = Mathf.Clamp(xRotation, -40.0f, 40.0f);
            //yRotation = Mathf.Clamp(yRotation, -80.0f, 80.0f);

            //transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            //Debug.Log(yRotation);
            //if(yRotation > 70 || yRotation < -70)
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
