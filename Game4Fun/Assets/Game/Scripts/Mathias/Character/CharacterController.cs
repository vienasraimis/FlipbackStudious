using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(CharacterStatus))]
public class CharacterController : MonoBehaviour
{
    public float Speed = 10f;

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

        var prev = transform.position;
        rigi.MovePosition(transform.position + movement);

        if (doMove) status.Step(movement / (Speed));
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
