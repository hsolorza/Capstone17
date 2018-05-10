using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseT : MonoBehaviour {

    // Equation for an Ellipse
    // 1 = (((x-h)^2)/a^2) + (((y-v)^2)/b^2)

    // Number of times object in placed on Ellipse
    private int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables
    public float xoffset = 0; // h of equation
    public float yoffset = 0; // v of equation
    public float zoffset = 0;
    public float shrink = 1;
    // Radius of the Ellipse
    public float xradius; // a of equation
    public float yradius; // b of equation
    // List of Objects
    public List<GameObject> cube;
    // Some Variable
    private LineRenderer line;

    // Use this for initialization
    void Start () {

        // Having object spawn in front of user
        xoffset = Camera.main.transform.position.x;
        yoffset = Camera.main.transform.position.y;
        zoffset = Camera.main.transform.position.z + 6;

        // Calculating number of spaces an object will be placed at on Ellipse

        // segments = (360) / (asin(objectWidth/radius)) * 180/3.1415 
        //segments = (int)(360 / (Mathf.Asin(objectWidth / ((xradius + yradius) / 2)) * (180.0 / 3.1415)));

        // segements = perimeter of Ellipse / objectWidth
        int segs = (int)(((2 * 3.1415) * Mathf.Sqrt(((xradius * xradius) + (yradius * yradius)) / 2)) / objectWidth);

        segments = (5*segs) / 4;

        Debug.Log("Segments: " + segments);

        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;

        // Calling function to place objects along Ellipse
        CreatePoints();

    }

    void CreatePoints() {

        // Create a new list for objects
        cube = new List<GameObject>(segments);
        // Creating a GameObject for the object being used
        GameObject tempCube;
        // Physical variables to use to define each object along the Ellipse
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Initial angle for the object
        float angle = 20f;

        // Loop going through Ellipse based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            // Calculating x and y of an object based off angle and radii of the Ellipse
            // x = a*cos(angle)
            // y = b*sin(angle)
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            x = xradius * Mathf.Cos(Mathf.Deg2Rad * angle) + xoffset;
            y = yradius * Mathf.Sin(Mathf.Deg2Rad * angle) + yoffset;

            // OR...
            // Solving for y in respects to x
            // y = sqrt((1 - (((x-h)^2) / a^2)) * b^2) + k
            //x = x + objectWidth;
            //y = Mathf.Sqrt((1 - ((Mathf.Pow((x - xoffset), 2)) / Mathf.Pow(xradius, 2))) / Mathf.Pow(yradius, 2)) + yoffset;

            // Setting position calculated
            line.SetPosition(i, new Vector3(x, y, z));
            // Printing out x position of object
            Debug.Log(line.GetPosition(i).x);

            // Creating a cube as the GameObject being used
            tempCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            /*tempCube.AddComponent<Rigidbody>();*/

            // Placing object at calculated position
            tempCube.transform.position = new Vector3(line.GetPosition(i).x, line.GetPosition(i).y, line.GetPosition(i).z);

            // Calculating angle of the object of the Ellipse
            //float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / xradius) * (float)(180.0 / 3.1415) * (line.GetPosition(i).y - xoffset) / Mathf.Abs((line.GetPosition(i).y - xoffset));
            //Debug.Log("Angle:" + xAngle);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube..?
            cube.Insert(i, tempCube);

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
            //angle += xAngle;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
