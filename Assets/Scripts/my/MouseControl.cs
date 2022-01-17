using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private Camera cam;
    private float xRotation = 0.0f, yRotation = 0.0f;
    private bool mouseToggle = false;

    [SerializeField] private float camera_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseToggle = (mouseToggle == true) ? false : true;

            print("Mouse = " + mouseToggle);
        }
            
        if(mouseToggle)
        {
            float mouseX = Input.GetAxis("Mouse X") * camera_speed;
            float mouseY = Input.GetAxis("Mouse Y") * camera_speed;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        }
    }
}
