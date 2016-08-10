using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour
{
    [Header("PlayerChanges")]
    public float Health = 0f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            var status = coll.GetComponent<CharacterStatus>();

            status.AddHealth(Health);
        }
    }
}
