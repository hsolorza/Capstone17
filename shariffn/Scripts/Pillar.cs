/////////////////////////////
//Nabeel’s Pillar Code
////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public GameObject EmptyGameObject;

    // Use this for initialization
    void Start()
    {    
        
        for (int y = 0; y < 7; y++)
        {
            /*for (int i = 0; i < 10; i++)
            {
                Instantiate(EmptyGameObject, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);

                EmptyGameObject = (GameObject)Instantiate(Resources.Load("Pillar"));
            }*/

            layer(y);
        }

    }


    void layer(int y)
    {
        PillarGen(y);

    }


    void PillarGen(int y)
    {
        GameObject Pillar = Resources.Load("brick") as GameObject;

        //Vector3 center = transform.position;
        //float radius = 0f;
        //int numObjects = 7;

        for (int x = 0; x < 1; x++)
        {
            for (int z = 0; z < 2; z++)
            {
                GameObject brick = Instantiate(Pillar) as GameObject;
                if (y == 0)
                {
                    brick.transform.position = new Vector3(0, 0, 0);

                }

                brick.transform.position = new Vector3(transform.position.x + x * 0.5f,
                    transform.position.y + y * 0.25f,
                    transform.position.z + z * 0.25f);


                
                    /*for (int i = 0; i < numObjects; i++)
                    {
                        //int a = i * 30;
                        Vector3 pos = Arc(y, center, 2.0f);
                        Instantiate(Pillar, pos, Quaternion.identity);
                    }*/
                

                /*int numObjects = 12;

                Vector3 center = transform.position;
				for (int i = 0; i < numObjects; i++)
				{
					int a = i * 30;
					Vector3 pos = Arch(center, 1.0f ,a);
					Instantiate(Pillar, pos, Quaternion.identity);
				}
			}

        }
	}

    Vector3 Arch(Vector3 center, float radius, int y)
    {
        //Debug.Log(a);
        float ang = Mathf.Sin(y / radius); //a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }*/
            }
        }
    }

    /*Vector3 Arc(int y, Vector3 center, float radius)
    {
        
        float ang = Mathf.Sin(y / radius);

        
        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    void ArcGen(float center, int y)
    {
        GameObject Arc = Resources.Load("brick") as GameObject;

        float brickH = 0.25f;
        float brickL = 0.5f;
        float brickW = 0.25f;

        float radius = 0.5f;
        Vector3 center = transform.position;
        Vector3 pos;

        float ang = Mathf.Sin(brickH / radius);
             
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;

        
        /for
        
                GameObject brick = Instantiate(Arc) as GameObject;

                Instantiate(Arc, pos, Quaternion.identity);

        
    }*/

}