using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour {

    [HideInInspector]
    public Renderer granite;

    [HideInInspector]
    public List<Renderer> wood = new List<Renderer>();

    [HideInInspector]
    public List<Renderer> hardware = new List<Renderer>();

    [HideInInspector]
    public List<GameObject> hardwareMeshes = new List<GameObject>();

    [HideInInspector]
    public string objectName;

    [HideInInspector]
    public Transform uiLocator;


	
	void Start () {
        uiLocator = GetComponentInChildren<Locator>().gameObject.transform;
        PopulateData();
	}
	
    void PopulateData ()
    {
        objectName = transform.name;

        foreach (Transform item in transform)
        {
            if (item.CompareTag("CounterTop"))
            {
                granite = item.GetComponent<Renderer>();
            } else if (item.CompareTag("Drawers") || item.CompareTag("Doors") || item.CompareTag("Base"))
            {
                if (item.childCount > 0)
                {
                    foreach (Transform child in item.transform)
                    {
                        wood.Add(child.GetComponent<Renderer>());
                    }
                } else
                {
                    wood.Add(item.GetComponent<Renderer>());
                }
            } else if (item.CompareTag("Pulls") || item.CompareTag("Knobs"))
            {
                foreach (Transform child in item.transform)
                {
                    hardware.Add(child.GetComponent<Renderer>());
                    hardwareMeshes.Add(child.gameObject);
                }
            } 
        }
    }

}
