using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Player")
        {
            var status = coll.transform.GetComponent<CharacterStatus>();
            //Vector3.l
        }
    }
}
