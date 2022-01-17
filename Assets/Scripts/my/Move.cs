using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;

    private float horizontal_movement = 0f, vertical_movement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_movement = Input.GetAxis("Horizontal");
        vertical_movement = Input.GetAxis("Vertical");

        Vector3 moveTo = new Vector3(horizontal_movement, 0f, vertical_movement);

        transform.Translate(moveTo * Time.deltaTime * movementSpeed);
    }
}
