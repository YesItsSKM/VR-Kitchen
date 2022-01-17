using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerInput : MonoBehaviour
{
    /*
    public GameObject player;
    public Animator leftHandAnimator, rightHandAnimator;

    public Rigidbody carRigidBody;
    public Transform carForward;

    [SerializeField] float moveSpeed = 0.2f;
    [SerializeField] float rotateSpeed = 0.25f;
    */

    public InputDevice leftController, rightController;

   // Vector3 moveDirection;

    //int i = 0;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        leftController = devices[0];
        rightController = devices[1];

        //carRigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        //AnimateHands();

        //if (leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool selected) && selected) ;
    }

    /*
    private void AnimateHands()
    {
        if (leftController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            leftHandAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            leftHandAnimator.SetFloat("Trigger", 0f);
        }

        if (leftController.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            leftHandAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            leftHandAnimator.SetFloat("Grip", 0f);
        }



        if (rightController.TryGetFeatureValue(CommonUsages.trigger, out float rTriggerValue))
        {
            rightHandAnimator.SetFloat("Trigger", rTriggerValue);
        }
        else
        {
            rightHandAnimator.SetFloat("Trigger", 0f);
        }

        if (rightController.TryGetFeatureValue(CommonUsages.grip, out float rGripValue))
        {
            rightHandAnimator.SetFloat("Grip", rGripValue);
        }
        else
        {
            rightHandAnimator.SetFloat("Grip", 0f);
        }
    }
    */
}
