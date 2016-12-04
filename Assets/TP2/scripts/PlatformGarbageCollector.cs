using UnityEngine;
using System.Collections;

public class PlatformGarbageCollector : MonoBehaviour {
    private const int GROUND = 8;  

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == GROUND){
            Destroy(other.gameObject);
        }
    }
}
