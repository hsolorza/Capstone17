﻿using UnityEngine;

public class ControllerGrabObject : MonoBehaviour
{
    // initialize the controller and the object in the hand
    private SteamVR_TrackedObject trackedObj;

    // Stores the GameObject that the trigger is currently colliding 
    // with, so you have the ability to grab the object.
    private GameObject collidingObject;

    // Stores the GameObject that the trigger is currently colliding 
    // with, so you have the ability to grab the object.
    private GameObject objectInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    private void SetCollidingObject(Collider col)
    {
        // Doesn’t make the GameObject a potential grab target if the player 
        // is already holding something or the object has no rigidbody.
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // Assigns the object as a potential grab target
        collidingObject = col.gameObject;
    }

    // When the trigger collider enters another, this sets up the other collider as a potential grab target.
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // Similar to section one (OnTriggerEnter), but different because it ensures that the 
    // target is set when the player holds a controller over an object for a while. 
    // Without this, the collision may fail or become buggy.
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // When the collider exits an object, abandoning an ungrabbed target, this code 
    // removes its target by setting it to null.
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // Move the GameObject inside the player’s hand and remove it from the collidingObject variable.
        objectInHand = collidingObject;
        collidingObject = null;
        // Add a new joint that connects the controller to the object using the AddFixedJoint() method below.
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // Make a new fixed joint, add it to the controller, and then set it up so it doesn’t break 
    // easily. Finally, you return it.
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // Make sure there’s a fixed joint attached to the controller.
        if (GetComponent<FixedJoint>())
        {
            // Remove the connection to the object held by the joint and destroy the joint.
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // Add the speed and rotation of the controller when the player releases the object, 
            // so the result is a realistic arc.
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // Remove the reference to the formerly attached object.
        objectInHand = null;
    }

    // Update is called once per frame
    void Update () {
        // When the player squeezes the trigger and there’s a potential grab target, this grabs it.
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // If the player releases the trigger and there’s an object attached to the controller, this releases it.
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

        // Get the position of the finger when it’s on the touchpad and write it to the Console.
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // When you squeeze the hair trigger, this line writes to the Console. 
        // The hair trigger has special methods to check whether it is pressed or not: 
        // GetHairTrigger(), GetHairTriggerDown() and GetHairTriggerUp()
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");
        }

        // If you release the hair trigger, this if statement writes to the Console.
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // If you press a grip button, this section writes to the Console.
        // Using the GetPressDown() method is the standard method to check if a button was pressed.
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
        }

        // When you release one of the grip buttons, this writes that action to the Console. 
        // Using the GetPressUp() method is the standard way to check if a button was released.
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }
    }
}
