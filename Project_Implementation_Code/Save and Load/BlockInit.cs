using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class BlockInit : MonoBehaviour {

	public double x_coord; 
	public double y_coord; 
	public double z_coord; 

	public Type type; 

	public double x_scale; 
	public double y_scale; 
	public double z_scale; 


	public double x_rotation; 
	public double y_rotation; 
	public double z_rotation; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
	
public enum Type{
	Cube,
	Sphere,
	Cylinder
}
