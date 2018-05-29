using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;
using Valve;

public class SpawnObject : MonoBehaviour {

    public Button myButton;

    public Transform prefab;

    public float xoffset = 0;
    public float yoffset = 1;
    public float zoffset = 0;

    // Use this for initialization
    void Start () {
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        //xoffset = Camera.main.transform.position.x;
        //yoffset = Camera.main.transform.position.y;
        //zoffset = Camera.main.transform.position.z + 6;
    }
	
	// Update is called once per frame
	void Update () {
		//
	}

    public void TaskOnClick()
    {
        //prefab.transform.localScale = new Vector3(1, 1, 1);
        Instantiate(prefab, new Vector3(xoffset, yoffset, zoffset), Quaternion.identity);
        //prefab.transform.localScale = new Vector3(1, 1, 1);
    }


}





