using UnityEngine;
using System.Collections;

public class ImpossibleJumpSolver : MonoBehaviour {
    public GameObject safetyPlatformPrefab;
    public LayerMask whatIsGround;
    public int minOffset;
    public int maxOffset;
	// Update is called once per frame
	void Update () {
        //TODO: Find why it doesnt find any collider
        var colliders = Physics.CheckBox(transform.position, transform.localScale / 2f, new Quaternion(0, 0, 0, 0), whatIsGround);

        //No platform then impossible situation
        if (!colliders)
        {
            //create a platform at center
            var platform = (GameObject)Instantiate(safetyPlatformPrefab, transform.position, new Quaternion());

            var offset = Random.Range(minOffset, maxOffset + 1);

            var x = platform.transform.position.x + offset;
            var y = 0; //Create at origin
            var z = platform.transform.position.z;

            platform.layer = 8;

            platform.transform.position = new Vector3(x, y, z);
        }
	}
}
