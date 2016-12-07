using UnityEngine;
using System.Collections;

public class PlatformRotation : MonoBehaviour {

	// Use this for initialization    
	void Start () {
	   var body = GetComponent<Rigidbody>();
        //To add constraints add bitwise |
        body.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationY;
    }
}
