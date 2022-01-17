using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlacement : MonoBehaviour {
    public UIManager uiManager;
    public Transform currentLoc;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (uiManager.objectData != null)
        {
            if (currentLoc != uiManager.objectData.uiLocator)
            {
                currentLoc = uiManager.objectData.uiLocator;
                this.gameObject.transform.position = currentLoc.position;
            }
        }

    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
