using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperbolaT : MonoBehaviour {

    // Equation for an Hyperbola (Vertex Form)
    // 1 = (((x-h)^2)/a^2) - (((y-k)^2)/b^2)

    // Number of times object in placed on Hyperbola
    private int segments = 60;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables
    public float xoffset = 5; // h of equation
    public float yoffset = 5; // v of equation
    public float zoffset = 0;
    public float shrink = 1;
    // Asymptotes of the Hyperbola
    public float xradius; // a of equation
    public float yradius; // b of equation
    // List of Objects
    public List<GameObject> cube;
    // Some Variable
    private LineRenderer line;

    // Use this for initialization
    void Start () {

        // Calculating number of spaces an object will be placed at on Hyperbola
        // segments = (360) / (asin(objectWidth/radius)) * 180/3.1415 
        //segments = (int)(360 / (Mathf.Asin(objectWidth / (xradius)) * 180.0 / 3.1415));
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along Hyperbola
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCube;
        // Physical variables to use to define each object along the Hyperbola
        float x; // x of equation
        float y; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;

        // Loop going through Hyperbola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radius of the Hyperbola
            // x = a*sec(angle) + xoffset = a*(1/cos(angle)) + xoffset
            // y = b*tan(angle) + yoffset
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            x = xradius * (1 / Mathf.Cos(Mathf.Deg2Rad * angle)) * +xoffset;
            y = yradius * Mathf.Tan(Mathf.Deg2Rad * angle) + yoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cube as the GameObject being used
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            /*tempCube.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Hyperbola
            // angle = acos((x-xoffset)/(m))
            // m = -(x-xoffset) / (y-yoffset)
            float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);

            // Rotating object based off calculated angle from earlier
            tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube..?
            cube.Insert(i, tempCube);

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
