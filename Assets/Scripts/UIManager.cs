using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour {
    [HideInInspector]
    public ObjectData objectData;
    private CameraController camControl;
    [HideInInspector]
    public GameObject currentSelection;
    public TextMeshProUGUI objectTitle;
	
	void Start () {
        camControl = Camera.main.GetComponent<CameraController>();
        

	}
	
	// Update is called once per frame
	void Update () {
        if (camControl.selectedObj != null)
        {
            if (camControl.selectedObj.gameObject != currentSelection)
            {
                currentSelection = camControl.selectedObj.gameObject;
                objectData = currentSelection.GetComponent<ObjectData>();
                objectTitle.text = objectData.objectName;
            }
        }
	}

    public void SwapMat (Material mat)
    {
        if (EventSystem.current.currentSelectedGameObject.CompareTag("Wood"))
        {
            foreach (var woodMat in objectData.wood)
            {
                woodMat.material = mat;
            }
        } else if (EventSystem.current.currentSelectedGameObject.CompareTag("Granite"))
            {
                objectData.granite.material = mat;
            } else if (EventSystem.current.currentSelectedGameObject.CompareTag("Metal"))
        {
            foreach (var metalMat in objectData.hardware)
            {
                metalMat.material = mat;
            }
        }
    }

    public void ToggleHardware ()
    {
        foreach (GameObject hardware in objectData.hardwareMeshes)
        {
            if (hardware.activeSelf == true)
            {
                hardware.SetActive(false);
            } else
            {
                hardware.SetActive(true);
            }
        }
    }
}
