using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour
{

    public SteamVR_TrackedObject trackedObj;

    private PropperLineRenderer currLine;

    private int numClicks = 0;

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.LogError("Yip it works!");

            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<PropperLineRenderer>();

            currLine.SetWidth(.1f);

            numClicks = 0;
        }

        else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            //currLine.SetVertexCount(numClicks + 1);
            //currLine.SetPosition(numClicks, trackedObj.transform.position);
            currLine.AddPoint(trackedObj.transform.position);
            numClicks++;
        }
    }
}