using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSplineT : MonoBehaviour {

    // Number of times object in placed on a B-Spline Curve
    public int segments = 7;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables, Points of B-Spline Curve 1
    public float x1 = -4; // x1 of curve
    public float y1 = -3; // y1 of curve
    public float x2 = -7; // x2 of curve
    public float y2 = -1; // y2 of curve
    public float x3 = -5; // x3 of curve
    public float y3 = 4; // y3 of curve
    public float x4 = -3; // x4 of curve
    public float y4 = 6; // y4 of curve
    public float x5 = -1; // x5 of curve
    public float y5 = 7; // y5 of curve
    public float x6 = 1; // x6 of curve
    public float y6 = 4; // y6 of curve
    public float x7 = 3; // x7 of curve
    public float y7 = 6; // y7 of curve
    public float x8 = 5; // x8 of curve
    public float y8 = 7; // y8 of curve
    public float x9 = 3; // x9 of curve
    public float y9 = 9; // y9 of curve
    public float x10 = 1; // x10 of curve
    public float y10 = 11; // y10 of curve
    public float x11 = 2; // x11 of curve
    public float y11 = 13; // y11 of curve
    public float x12 = 8; // x12 of curve
    public float y12 = 10; // y12 of curve
    public float x13 = 7; // x13 of curve
    public float y13 = 7; // y13 of curve
    // List of Objects
    public List<GameObject> cube;
    // Some Variable
    private LineRenderer line;
    // User's GameObjects/objects
    public GameObject parent_object;
    // Public GameObject;
    public GameObject main_object;

    // Use this for initialization
    void Start () {

        // Setting up line components
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along B-Spline Curve
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Length of the list created above
        int list_length = 0;
        // Creating a GameObject for the object being used
        GameObject store_object;
        // Physical variables to use to define each object along the B-Spline Curve
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial t for the object
        float t = 0f;

        // Loop going through B-Spline Curve based off number of segments calculated earlier

        /*********************************************************************************/
        // Calculating Curve 1 of B-Spline
        /*********************************************************************************/

        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating t variable for B-Spline curve equation
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the B-Spline Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t < 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x1) + (3 * Mathf.Pow((1 - t), 2) * t * x2) + (3 * (1 - t) * Mathf.Pow(t, 2) * x3) + (Mathf.Pow(t, 3) * x4);
            y = (Mathf.Pow((1 - t), 3) * y1) + (3 * Mathf.Pow((1 - t), 2) * t * y2) + (3 * (1 - t) * Mathf.Pow(t, 2) * y3) + (Mathf.Pow(t, 3) * y4);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);
        }

        // Counts the number of GameObjects in the list
        list_length = cube.Count;

        // Makes all of the elements in the list above children of the user's created GameObject previously
        for (int i = 0; i < list_length; i++) {
            cube[i].transform.parent = main_object.transform;
        }

        /*********************************************************************************/
        // Calculating Curve 2 of B-Spline
        /*********************************************************************************/

        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating t variable for B-Spline curve equation
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the B-Spline Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t < 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x4) + (3 * Mathf.Pow((1 - t), 2) * t * x5) + (3 * (1 - t) * Mathf.Pow(t, 2) * x6) + (Mathf.Pow(t, 3) * x7);
            y = (Mathf.Pow((1 - t), 3) * y4) + (3 * Mathf.Pow((1 - t), 2) * t * y5) + (3 * (1 - t) * Mathf.Pow(t, 2) * y6) + (Mathf.Pow(t, 3) * y7);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);
        }

        // Counts the number of GameObjects in the list
        list_length = cube.Count;

        // Makes all of the elements in the list above children of the user's created GameObject previously
        for (int i = 0; i < list_length; i++) {
            cube[i].transform.parent = main_object.transform;
        }

        /*********************************************************************************/
        // Calculating Curve 3 of B-Spline
        /*********************************************************************************/

        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating t variable for B-Spline curve equation
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the B-Spline Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t < 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x7) + (3 * Mathf.Pow((1 - t), 2) * t * x8) + (3 * (1 - t) * Mathf.Pow(t, 2) * x9) + (Mathf.Pow(t, 3) * x10);
            y = (Mathf.Pow((1 - t), 3) * y7) + (3 * Mathf.Pow((1 - t), 2) * t * y8) + (3 * (1 - t) * Mathf.Pow(t, 2) * y9) + (Mathf.Pow(t, 3) * y10);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);
        }

        // Counts the number of GameObjects in the list
        list_length = cube.Count;

        // Makes all of the elements in the list above children of the user's created GameObject previously
        for (int i = 0; i < list_length; i++) {
            cube[i].transform.parent = main_object.transform;
        }

        /*********************************************************************************/
        // Calculating Curve 4 of B-Spline
        /*********************************************************************************/

        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating t variable for B-Spline curve equation
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the B-Spline Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t < 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x10) + (3 * Mathf.Pow((1 - t), 2) * t * x11) + (3 * (1 - t) * Mathf.Pow(t, 2) * x12) + (Mathf.Pow(t, 3) * x13);
            y = (Mathf.Pow((1 - t), 3) * y10) + (3 * Mathf.Pow((1 - t), 2) * t * y11) + (3 * (1 - t) * Mathf.Pow(t, 2) * y12) + (Mathf.Pow(t, 3) * y13);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Placing the user's object along the curve
            store_object = Instantiate(parent_object, new Vector3(x, y, z), Quaternion.identity) as GameObject;

            // Inserting object to list
            cube.Insert(i, store_object);
        }

        // Counts the number of GameObjects in the list
        list_length = cube.Count;

        // Makes all of the elements in the list above children of the user's created GameObject previously
        for (int i = 0; i < list_length; i++) {
            cube[i].transform.parent = main_object.transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
