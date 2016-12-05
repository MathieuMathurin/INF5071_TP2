using UnityEngine;
using System.Collections;

public class Players1Controller : MonoBehaviour {
    Animator animator;
    Rigidbody rigidBody;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Speed", 10f);
    }
}
