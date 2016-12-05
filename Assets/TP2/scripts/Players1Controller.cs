using UnityEngine;
using System.Collections;

public class Players1Controller : MonoBehaviour {
    Animator animator;
    Rigidbody rigidBody;
    public float speed = 10f;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        var movement = new Vector3(-moveX, 0f, -moveZ);
        movement = movement.normalized * speed * Time.deltaTime;

        rigidBody.MovePosition(transform.position + movement);        
        transform.eulerAngles = new Vector3(0, -Mathf.Atan2(moveX, -moveZ) * 180 / Mathf.PI, 0);

        var movingSpeed = Mathf.Abs(moveX) == 1 || Mathf.Abs(moveZ) == 1 ? 1 : 0;

        animator.SetFloat("Speed", movingSpeed);
    }
}
