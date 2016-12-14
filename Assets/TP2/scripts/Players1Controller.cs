using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Players1Controller : MonoBehaviour {
    Animator animator;
    Rigidbody rigidBody;
	public string loseText;
    public float speed = 10f;
    public LayerMask whatIsGround;
    public float groundRadius = 0.2f;
    public Transform groundCheck;
    public float jumpForce;
    public float jumpRestriction = 2;

	private string currentMessage = "";

    public bool grounded;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

	void OnGUI() {
		GUIStyle guiStyle = new GUIStyle ();
		guiStyle.fontSize = 100;
		GUI.Label(new Rect(Screen.width / 4, Screen.height / 2, Screen.width, Screen.height) , this.currentMessage, guiStyle);
	}
	
	// Update is called once per frame
	void Update () {        
		if (this.transform.position.y < 3.5) {
			StartCoroutine (ExitGame());
			//SceneManager.LoadScene("MainScene");
		}
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("isGrounded", grounded);
		if (!grounded && rigidBody.velocity.y < 0) {
			rigidBody.AddForce(0.0f, -15.0f, 0.0f);
		}
	
        var jumpSpeed = !grounded ? speed / 2 : speed;

        var movement = new Vector3(-moveX, 0f, -moveZ);
        movement = movement * jumpSpeed * Time.deltaTime;

        
        rigidBody.AddForce(new Vector3(-moveX * jumpSpeed, 0, -moveZ * jumpSpeed), ForceMode.Impulse);        
        
        transform.eulerAngles = new Vector3(0, -Mathf.Atan2(moveX, -moveZ) * 180 / Mathf.PI, 0);

        var jumpKey = KeyCode.Space;
        var controllerJumpKey = KeyCode.Joystick1Button1;
        if (grounded && (Input.GetKeyDown(controllerJumpKey) || Input.GetKeyDown(jumpKey)))
        {
            animator.SetBool("isGrounded", false);
            rigidBody.AddForce(jumpForce * -Physics.gravity, ForceMode.Impulse);
        }

        var movingSpeed = Mathf.Abs(moveX) == 1 || Mathf.Abs(moveZ) == 1 ? 1 : 0;
        animator.SetFloat("Speed", movingSpeed);
    }

	IEnumerator ExitGame() {
		Time.timeScale = 0;
		this.currentMessage = this.loseText;
		yield return new WaitForSecondsRealtime(2);
		Time.timeScale = 1;
		SceneManager.LoadScene("MainScene");
	}
}
