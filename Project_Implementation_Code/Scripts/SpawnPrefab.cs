using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnPrefab : MonoBehaviour {

    public Transform prefab;

    // Use this for initialization
   void Start() { 
         //do nothing
		
	}
	
	// Update is called once per frame
	void Update () {
		//do nothing
	}

    public void Spawn()
    {
        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}