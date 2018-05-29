using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperbolaT : MonoBehaviour {

    // Equation for an Hyperbola (Vertex Form)
    // 1 = (((x-h)^2)/a^2) - (((y-k)^2)/b^2)

    // Number of times object in placed on Hyperbola
    public int segments = 10;
    // Width of the Object
    public float objectWidth = 1;
    // User Input Variables
    public float xoffset = 0; // h of equation
    public float yoffset = 0; // v or k of equation
    public float zoffset = 0;
    // Asymptotes of the Hyperbola
    public float xradius = 1; // a of equation
    public float yradius = 2; // b of equation
    // List of Objects
    public List<GameObject> cube;
    // Some Variable
    private LineRenderer line;
    // User's GameObjects/objects
    public GameObject parent_object;

    // Use this for initialization
    void Start () {

        // Having object spawn in front of user
        xoffset = Camera.main.transform.position.x;
        yoffset = Camera.main.transform.position.y;
        zoffset = Camera.main.transform.position.z + 6;

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
        float x = 0f; // x of equation
        float y = 0f; // y of equation
        float z = 0f;
        // Starting angle for the object
        float angle = 20f;
        float t = 0;

        // Loop going through Hyperbola based off number of segments calculated earlier
        for (int i = 0; i < (segments + 1); i++)
        {
            /*********************************************************************************/
            // Calculating Curve 1, Side 1 of Hyperbola
            /*********************************************************************************/

            // Calculating x and y of an object based off angle and radius of the Hyperbola
            // x = a*sec(angle) + xoffset = a*(1/cos(angle)) + xoffset
            // y = b*tan(angle) + yoffset
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            //x = xradius * (1 / Mathf.Cos(Mathf.Deg2Rad * angle)) * + xoffset;
            //y = yradius * Mathf.Tan(Mathf.Deg2Rad * angle) + yoffset;

            // OR...
            // x = acosh(t), where cosh(t) = (1+(e)^-2t) / (2*(e)^(-t))
            // y = bsinh(t), where sinh(t) = (1-(e)^-2t) / (2*(e)^(-t))
            //x = xradius * ((1 + Mathf.Exp((-1) * 2 * (t))) / (2 * Mathf.Exp((-1) * (t))));
            //y = yradius * ((1 - Mathf.Exp((-1) * 2 * (t))) / (2 * Mathf.Exp((-1) * (t))));

            // OR...
            // Solving for y in respects to x
            // y = sqrt(((((x-h)^2) / a^2) - 1) * b^2) + k
            x = x + objectWidth;
            y = Mathf.Sqrt((((Mathf.Pow((x - xoffset), 2)) / Mathf.Pow(xradius, 2)) - 1) / Mathf.Pow(yradius, 2)) + yoffset;

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
            //float xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube
            cube.Insert(i, tempCube);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = parent_object.transform;

            // Calculating Curve 1, Side 2 of Hyperbola
            /*********************************************************************************/

            y = y * (-1);

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
            //xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube
            cube.Insert(i, tempCube);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = parent_object.transform;

            y = y * (-1);

            /*********************************************************************************/
            // Calculating Curve 2, Side 1 of Hyperbola
            /*********************************************************************************/

            // Calculating x and y of an object based off angle and radius of the Hyperbola
            // x = a*sec(angle) + xoffset = a*(1/cos(angle)) + xoffset
            // y = b*tan(angle) + yoffset
            // NOTE: Might have to be flipped like for the CircleT code, still unsure exactly why
            //x = xradius * (1 / Mathf.Cos(Mathf.Deg2Rad * angle)) * + xoffset;
            //y = yradius * Mathf.Tan(Mathf.Deg2Rad * angle) + yoffset;

            // OR...
            // x = acosh(t), where cosh(t) = (1+(e)^-2t) / (2*(e)^(-t))
            // y = bsinh(t), where sinh(t) = (1-(e)^-2t) / (2*(e)^(-t))
            //x = (-1) * xradius * ((1 + Mathf.Exp((-1) * 2 * (t))) / (2 * Mathf.Exp((-1) * (t))));
            //y = yradius * ((1 - Mathf.Exp((-1) * 2 * (t))) / (2 * Mathf.Exp((-1) * (t))));

            // OR...
            // Solving for y in respects to x
            // y = sqrt(((((x-h)^2) / a^2) - 1) * b^2) + k
            x = (-1) * x;
            y = Mathf.Sqrt((((Mathf.Pow((x - xoffset), 2)) / Mathf.Pow(xradius, 2)) - 1) / Mathf.Pow(yradius, 2)) + yoffset;

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
            //xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube
            cube.Insert(i, tempCube);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = parent_object.transform;

            // Calculating Curve 2, Side 2 of Hyperbola
            /*********************************************************************************/

            y = y * (-1);

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
            //xAngle = Mathf.Acos((line.GetPosition(i).x - xoffset) / (-((line.GetPosition(i).x - xoffset) / (line.GetPosition(i).y - yoffset)))) * (float)(180.0 / 3.1415);

            // Rotating object based off calculated angle from earlier
            //tempCube.transform.localEulerAngles = new Vector3(0, 0, xAngle);

            // Placing cube
            cube.Insert(i, tempCube);

            // Makes the element/GameObject above a child of the user's created GameObject previously
            cube[i].transform.parent = parent_object.transform;

            y = y * (-1);

            /*********************************************************************************/

            x = (-1) * x;

            t = (3 * (t + 1)) / 4;

            // Calculating next angle based off an additional segment calculated from earlier
            angle += (360f / segments);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
