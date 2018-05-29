/* VR_walklocomotion.cs
 * 
 * INSTRUCTIONS 
 * 
 * About: It's a code to enable easily rotating the paly area so user can tranverse the scene only by walking. This is done by holding the trackpad
 * on the vive controler and then the user turn around to adjust the scene to better fit the play area.
 * 
 * Use this code however you want.
 * 
 * HOW TO USE IT
 * 
 * What you need: HTC Vive, SteamVR plugin, Importing Effects standard package on your project (you just need BlurOptimized effect), this code.
 * 
 * 1) Check if you are using SteamVR plugin.
 * 2) Import Effects standard package: Click on Assets -> Import Package -> Effects. You'll
 * 3) Find the GameObject which has the SteamVR_Camera script (it's probably named as "Camera (eye)") and add the component "BlurOptimized" script.
 * 4) Go to the controller gameobject which you want to activate the code (can be just one controle or bouth) and add this code as a component.
 * 5) Click on play scene, put the HTC vive onde, hold the touchpad on the controller and rotate yourself around. Tã dã
 * 
 *  */


using UnityEngine;
using System.Collections;
//using UnityStandardAssets.ImageEffects;

public class VR_walklocomotion : MonoBehaviour
{

    Camera headsetCamera;
    //BlurOptimized cameraBlur;
    Transform cameraRig;

    Vector3 lastHeadRot;

    bool freezeYCameraRotation = false;

    // Use this for initialization
    void Start()
    {
        headsetCamera = GameObject.FindObjectOfType<SteamVR_Camera>().GetComponent<Transform>().GetComponent<Camera>();
        //cameraBlur = GameObject.FindObjectOfType<SteamVR_Camera>().GetComponent<Transform>().GetComponent<BlurOptimized>();

        cameraRig = GameObject.FindObjectOfType<SteamVR_ControllerManager>().GetComponent<Transform>();

        /*if (cameraBlur == null)
        {
            Debug.LogError("Cannot find BlurOptimized script on SteamVR_Camera object");
            return;
        }*/

        if (headsetCamera == null)
        {
            Debug.LogError("Cannot find SteamVR_Camera");
            return;
        }

        var trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null)
        {
            trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
        }

        trackedController.PadClicked += new ClickedEventHandler(BlurAndFreezeCamera);
        trackedController.PadUnclicked += new ClickedEventHandler(UnblurAndDefreezeCamera);



        //cameraBlur.enabled = false;
    }

    void BlurAndFreezeCamera(object sender, ClickedEventArgs e)
    {
        Valve.VR.OpenVR.Chaperone.ForceBoundsVisible(true);

        //cameraBlur.enabled = true;
        //cameraBlur.downsample = 2;
        //cameraBlur.blurSize = 3.5f;
        //cameraBlur.blurIterations = 3;

        lastHeadRot = headsetCamera.transform.eulerAngles;

        freezeYCameraRotation = true;
        SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0.92f), 0.5f);
    }

    void LateUpdate()
    {
        if (freezeYCameraRotation)
        {
            cameraRig.transform.RotateAround(headsetCamera.transform.position, Vector3.up, -(headsetCamera.transform.eulerAngles.y - lastHeadRot.y));
            lastHeadRot = headsetCamera.transform.eulerAngles;
        }


    }

    void UnblurAndDefreezeCamera(object sender, ClickedEventArgs e)
    {
        //cameraBlur.enabled = false;
        SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0f), 0.5f);

        freezeYCameraRotation = false;
        Valve.VR.OpenVR.Chaperone.ForceBoundsVisible(false);
    }



}