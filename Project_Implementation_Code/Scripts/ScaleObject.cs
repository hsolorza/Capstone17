using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ScaleObject : MonoBehaviour {

    public float scale = 1f;

    void Update()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void AdjustScale(float newscale)
    {
        scale = newscale;
    }




    /*
    public GameObject myObj;
    public Slider sliderLength;

    public float X ;
    public float Y ;
    public float Z ;

    // Use this for initialization
    void Start () {
  
    }
    
	// Update is called once per frame
	public void update () {
        Debug.LogError("Fail--------------------------------------------------------------------");
        Debug.LogWarning("Fail--------------------------------------------------------------------");
        Debug.Log("Fail--------------------------------------------------------------------");
        Debug.LogError(sliderLength.value);
        Debug.LogWarning(sliderLength.value);
        Debug.Log(sliderLength.value);
        X = sliderLength.value;
        Y = sliderLength.value;
        Z = sliderLength.value;

        myObj.transform.position = new Vector3(X, Y, Z);
        myObj.transform.localScale = new Vector3(X, Y, Z);
	}*/
}
