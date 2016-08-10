using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{
    public float force = 10f;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Player")
        {
            var status = coll.transform.GetComponent<CharacterStatus>();

            Vector3 dir = transform.position - status.transform.position;
            Debug.Log(dir);

            var move = dir * force *-1;

            Debug.Log(move + status.transform.position);

            //status.GetComponent<Rigidbody2D>().MovePosition(move + status.transform.position);
            status.AddHealth(-10f);
        }
    }
}
