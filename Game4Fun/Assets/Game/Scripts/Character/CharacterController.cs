using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    public float Speed = 10f;

    private Rigidbody2D rigi;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.freezeRotation = false;
    }

    void Update()
    {
        Vector3 movment = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * Speed;

        rigi.MovePosition(transform.position + movment);
    }
}
