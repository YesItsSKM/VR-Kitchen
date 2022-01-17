using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuSpawner : MonoBehaviour
{
    public GameObject menu;
    //public Transform menuLocation;
    public PlayerInput playerInput;
    
    public CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print(other.transform.name);

            if(playerInput.leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool selected) && selected)
            {
                cameraController.selectedObj = this.transform;

                Debug.Log(cameraController.selectedObj.transform.name);
            }

            if (playerInput.rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool rSelected) && rSelected)
            {
                cameraController.selectedObj = this.transform;

                Debug.Log(cameraController.selectedObj.transform.name);
            }
        }
    }
}
