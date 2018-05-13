using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
public class RayCastButton : MonoBehaviour {

    public float sightlength;

    void Update()
    {

        RaycastHit seen;
        Ray raydirection = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raydirection, out seen, sightlength))
        {
            if (seen.collider.tag == "buttons") //in the editor, tag anything you want to interact with and use it here
            {
                print("This is a button");
            }

        }
        Debug.DrawRay(transform.position, transform.forward, Color.black, 1); //unless you allow debug to be seen in game, this will only be viewable in the scene view
    }
}