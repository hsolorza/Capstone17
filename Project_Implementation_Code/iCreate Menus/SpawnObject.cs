using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour {

    public Button myButton;

    public Transform prefab;

    // Use this for initialization
    void Start () {
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		//
	}

    public void TaskOnClick()
    {
        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }


}





