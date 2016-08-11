using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public Transform target; //This will be your citizen
    public float distance;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("a"))
            RotateLeft();
        if (Input.GetKeyDown("d"))
            RotateRight();
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * -90);
    
    }
    void RotateRight()
    {
        transform.Rotate(Vector3.forward * 90);
    }
}
