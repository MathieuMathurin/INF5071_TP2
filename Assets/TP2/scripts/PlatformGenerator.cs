using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject floorPrefab;

    public int distanceBetweenInstances = 10;
    public bool somethingExists;
    private float nextInstanciation;

    private const int GROUND = 8;

    // Use this for initialization
    void Start () {
        nextInstanciation = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        var isPositionToCreate = transform.position.z >= nextInstanciation;

        if (isPositionToCreate && !somethingExists)
        {
            RandomizeCreation();            
            nextInstanciation = transform.position.z + distanceBetweenInstances;
        }
    }

    void CreatePlatform(GameObject type)
    {        
        var platform = (GameObject)Instantiate(type, transform.position, new Quaternion());

        var x = platform.transform.position.x;
        var y = 0; //Create at origin
        var z = platform.transform.position.z + platform.transform.lossyScale.z / 2; //Object creates at center and we would like to create it at extremity

        platform.layer = GROUND;

        platform.transform.position = new Vector3(x, y, z);        
    }

    void RandomizeCreation()
    {
        var random = Random.Range(1, 3);
        GameObject type;

        var skip = System.Convert.ToBoolean(Random.Range(0, 10));

        if (skip) return;

        switch (random)
        {
            case 1:
                type = platformPrefab;
                break;
            case 2:
                type = floorPrefab;
                break;
            default:
                type = floorPrefab;
                break;
        }

        CreatePlatform(type);
    }

    void OnCollisionEnter(Collision collision)
    {
        somethingExists = true;
    }

    void OnCollisionExit(Collision collision)
    {
        somethingExists = false;
        //Postpone creation to make a Gap
        nextInstanciation = transform.position.z + distanceBetweenInstances;        
    }    
}
