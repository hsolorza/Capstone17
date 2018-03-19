using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ScaleObject : MonoBehaviour {

    public Slider sliderLength;
    public Slider sliderWidth;
    public Slider sliderHeight;

    //public Transform prefab;

    private float X = 0f;
    private float Y = 0f;
    private float Z = 0f;

    // Use this for initialization
    void Start () {
        //sliderLength.value = 1;
        //sliderWidth.value = 1;
        //sliderHeight.value = 1;
    }
    

	
	// Update is called once per frame
	public void Scale () {

        X = sliderLength.value;
        Y = sliderHeight.value;
        Z = sliderWidth.value;

        transform.localScale = new Vector3(X, Y, Z);
	}
}
