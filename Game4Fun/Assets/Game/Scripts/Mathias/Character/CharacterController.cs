using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(CharacterStatus))]
public class CharacterController : MonoBehaviour
{
    public float Speed = 10f;
    public Transform camera;

    private Rigidbody2D rigi;
    private CharacterStatus status;

    private bool doMove = true;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        status = GetComponent<CharacterStatus>();

        rigi.freezeRotation = true;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.fixedDeltaTime * Speed;

        Rotate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        var prev = transform.position;
        rigi.MovePosition(transform.position + movement);

        if (doMove) status.Step(movement / (Speed));
    }



    private void Rotate(Vector3 move)
    {
        //move must be in Absolute values !!

        Vector3 rot = new Vector3(0,0,0);
        Vector3 camRot = new Vector3(0, 0, 0);

        if (move.x == 1 && move.y == 1)
        {
            rot = new Vector3(0, 0, 315);
        }
        else if (move.x == -1 && move.y == 1)
        {
            rot = new Vector3(0, 0, 45);
        }
        else if (move.x == 1 && move.y == -1)
        {
            rot = new Vector3(0, 0, 45);
        }
        else if (move.x == -1 && move.y == -1)
        {
            rot = new Vector3(0, 0, 315);
        }
        else if(Mathf.Abs(move.x) == 1)
        {
            rot = new Vector3(0, 0, 90);
        }
        else if(Mathf.Abs(move.y) == 1)
        {
            rot = new Vector3(0, 0, 0);
        }

        transform.rotation = Quaternion.Euler(rot);
        camera.rotation = Quaternion.Euler(camRot);
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        doMove = false;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        doMove = true;
    }
}
