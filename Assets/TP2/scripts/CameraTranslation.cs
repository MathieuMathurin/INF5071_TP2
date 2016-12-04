using UnityEngine;
using System.Collections;

public class CameraTranslation : MonoBehaviour {

    public float speed = 10f;   

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var position = this.transform.position;
        var translationDistance = speed * Time.deltaTime;
        this.transform.position = new Vector3(position.x, position.y, position.z + translationDistance);
	}
}
