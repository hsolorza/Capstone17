using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierC : MonoBehaviour {

    // Number of times object in placed on Bezier Curve
    public int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables, Points of Bezier Curve
    public float x1 = -5; // x1 of curve
    public float y1 = -1; // y1 of curve
    public float x2 = -1; // x2 of curve
    public float y2 = 5; // y2 of curve
    public float x3 = 1; // x3 of curve
    public float y3 = -5; // y3 of curve
    public float x4 = 5; // x4 of curve
    public float y4 = 1; // y4 of curve
    // List of Objects
    public List<GameObject> cube;
    public List<GameObject> sphere;
    public List<GameObject> capsule;
    public List<GameObject> cylinder;
    // Some Variable
    private LineRenderer line;

    // Use this for initialization
    void Start () {

        // Calculating number of spaces an object will be placed at on Bezier Curve
        // segments = (360) / (asin(objectWidth/radius)) * 180/3.1415 
        Debug.Log("Segments: " + segments);

        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along Bezier Curve
        CreatePoints(); // Main object used is a cube

        //CreatePoints_Sphere(); // Main object used is a sphere
        //CreatePoints_Capsule(); // Main object used is a capsule
        //CreatePoints_Cylinder(); // Main object used is a cylinder
    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCube;
        // Physical variables to use to define each object along the Bezier Curve
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial t for the object
        float t = 0f;

        // Loop going through Bezier Curve based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the Bezier Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t< 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x1) + (3 * Mathf.Pow((1 - t), 2) * t * x2) + (3 * (1 - t) * Mathf.Pow(t, 2) * x3) + (Mathf.Pow(t, 3) * x4);
            y = (Mathf.Pow((1 - t), 3) * y1) + (3 * Mathf.Pow((1 - t), 2) * t * y2) + (3 * (1 - t) * Mathf.Pow(t, 2) * y3) + (Mathf.Pow(t, 3) * y4);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Creating a cube as the GameObject being used
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            /*tempCube.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Bezier Curve
            //float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            //Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube
            cube.Insert(i, tempCube);

            // Calculating next angle based off an additional segment calculated from earlier
            //angle += (360f / segments);
            //angle += xAngle;
        }

    }

    void CreatePoints_Sphere() {

        // Create a new list for objects
        sphere = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempSphere;
        // Physical variables to use to define each object along the Bezier Curve
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial t for the object
        float t = 0f;

        // Loop going through Bezier Curve based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the Bezier Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t< 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x1) + (3 * Mathf.Pow((1 - t), 2) * t * x2) + (3 * (1 - t) * Mathf.Pow(t, 2) * x3) + (Mathf.Pow(t, 3) * x4);
            y = (Mathf.Pow((1 - t), 3) * y1) + (3 * Mathf.Pow((1 - t), 2) * t * y2) + (3 * (1 - t) * Mathf.Pow(t, 2) * y3) + (Mathf.Pow(t, 3) * y4);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Creating a sphere as the GameObject being used
            tempSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            /*tempSphere.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempSphere.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Bezier Curve
            //float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            //Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempSphere.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing sphere
            sphere.Insert(i, tempSphere);

            // Calculating next angle based off an additional segment calculated from earlier
            //angle += (360f / segments);
            //angle += xAngle;
        }

    }

    void CreatePoints_Capsule () {

        // Create a new list for objects
        capsule = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCapsule;
        // Physical variables to use to define each object along the Bezier Curve
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial t for the object
        float t = 0f;

        // Loop going through Bezier Curve based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the Bezier Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t< 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x1) + (3 * Mathf.Pow((1 - t), 2) * t * x2) + (3 * (1 - t) * Mathf.Pow(t, 2) * x3) + (Mathf.Pow(t, 3) * x4);
            y = (Mathf.Pow((1 - t), 3) * y1) + (3 * Mathf.Pow((1 - t), 2) * t * y2) + (3 * (1 - t) * Mathf.Pow(t, 2) * y3) + (Mathf.Pow(t, 3) * y4);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Creating a capsule as the GameObject being used
            tempCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            /*tempCapsule.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCapsule.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Bezier Curve
            //float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            //Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCapsule.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing capsule
            capsule.Insert(i, tempCapsule);

            // Calculating next angle based off an additional segment calculated from earlier
            //angle += (360f / segments);
            //angle += xAngle;
        }

    }

    void CreatePoints_Cylinder() {

        // Create a new list for objects
        cylinder = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCylinder;
        // Physical variables to use to define each object along the Bezier Curve
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial t for the object
        float t = 0f;

        // Loop going through Bezier Curve based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            t = i / (float)segments;

            // Calculating x and y of an object based off the four points and t of the Bezier Curve
            // x = (1-t)^3*x1 + 3(1-t)^2*t*x2 + 3(1-t)*t^2*x3 + t^3*x4, where 0 < t< 1
            // y = (1-t)^3*y1 + 3(1-t)^2*t*y2 + 3(1-t)*t^2*y3 + t^3*y4, where 0 < t < 1
            x = (Mathf.Pow((1 - t), 3) * x1) + (3 * Mathf.Pow((1 - t), 2) * t * x2) + (3 * (1 - t) * Mathf.Pow(t, 2) * x3) + (Mathf.Pow(t, 3) * x4);
            y = (Mathf.Pow((1 - t), 3) * y1) + (3 * Mathf.Pow((1 - t), 2) * t * y2) + (3 * (1 - t) * Mathf.Pow(t, 2) * y3) + (Mathf.Pow(t, 3) * y4);

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log("X-Position: " + line.GetPosition(i).x);
            Debug.Log("Y-Position: " + line.GetPosition(i).y);

            // Creating a cylinder as the GameObject being used
            tempCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            /*tempCylinder.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCylinder.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Bezier Curve
            //float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            //Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCylinder.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cylinder
            cylinder.Insert(i, tempCylinder);

            // Calculating next angle based off an additional segment calculated from earlier
            //angle += (360f / segments);
            //angle += xAngle;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
