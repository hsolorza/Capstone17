using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    // Use this for initialization
    //public GameObject emptyGameObjectPrefab;

    void Start()
    {
        /*Vector3 pos1 = new Vector3(0, 0, 0);
        Vector3 pos2 = new Vector3(2, 0, 0);
        Vector3 pos3 = new Vector3(4, 0, 0);
        Vector3 pos4 = new Vector3(6, 0, 0);*/

        GameObject SpawnPoint = Resources.Load("PillarSpawn") as GameObject;



        Instantiate(SpawnPoint, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(SpawnPoint, new Vector3(2, 0, 0), Quaternion.identity);
        Instantiate(SpawnPoint, new Vector3(4, 0, 0), Quaternion.identity);
        Instantiate(SpawnPoint, new Vector3(6, 0, 0), Quaternion.identity);

        // Update is called once per frame
    }

    void Update()
    {

    }
}
