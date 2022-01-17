using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour {
    [Header("Movement Parameters")]
    [Tooltip("Controls the mouse wheel camera speed")]
    public float moveSpeed = 10;
    [Tooltip("Controls how quickly the mouse pans")]
    public float panSpeed = 2.0f;
    [Tooltip("Check the invert boolean if you would like to invert the mouse controls")]
    public bool invertControls = false;
    [Space(5)]



    private float x;
    private float y;
    private float wheel;

    private Vector3 rotateValue;
    private Vector3 mouseOrigin;

    [HideInInspector]
    public Transform selectedObj;

    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        wheel = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit raycastHit = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
            {
                if (raycastHit.collider.tag == "Kitchen")
                {
                    selectedObj = raycastHit.collider.transform;

                }
            }
        }

            //Moves camera with scroll wheel. First checks if invertControls is true.
            if (invertControls)
        {
            if (wheel > 0f)
            {
                transform.Translate(0, 0, -wheel * moveSpeed, Space.Self);              
            }
            else if (wheel < 0f)
            {
                transform.Translate(0, 0, -wheel * moveSpeed, Space.Self);
            }

        } else
        {
            if (wheel > 0f)
            {
                transform.Translate(0, 0, wheel * moveSpeed, Space.Self);
            } else if (wheel < 0f)
            {
                transform.Translate(0, 0, wheel * moveSpeed, Space.Self);
            }
        }

        //Rotates the camera with the right mouse button
        if (Input.GetMouseButton(1))
        {
            rotateValue = new Vector3(x, y * -1, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
        }

        //Pans the camera in, out, left and right with the middle mouse button
        #region
        if (Input.GetMouseButtonDown(2))
        {
            mouseOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(2)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
        Vector3 move = new Vector3(pos.x * panSpeed, 0, pos.y * panSpeed);

        transform.Translate(move, Space.Self);
        #endregion
    }


}
