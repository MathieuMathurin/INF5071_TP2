using UnityEngine;
using System.Collections;

public class ImpossibleJumpSolver : MonoBehaviour {
    public GameObject safetyPlatformPrefab;
    private const int GROUND = 8;
	// Update is called once per frame
	void Update () {
        //TODO: Find why it doesnt find any collider
        var colliders = Physics.CheckBox(transform.position, transform.localScale / 2f, new Quaternion(), GROUND);

        //No platform then impossible situation
        if (!colliders)
        {
            //create a platform at center
            //var platform = (GameObject)Instantiate(safetyPlatformPrefab, transform.position, new Quaternion());

            //var x = platform.transform.position.x;
            //var y = 0; //Create at origin
            //var z = platform.transform.position.z;

            //platform.layer = GROUND;

            //platform.transform.position = new Vector3(x, y, z);
        }
	}
}
