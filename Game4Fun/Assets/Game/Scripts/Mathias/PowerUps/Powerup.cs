using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour
{
    [Header("PlayerChanges")]
    public float Health = 0f;
    public float Speed = 2f;
    public float SpeedTime = 0f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            var status = coll.GetComponent<CharacterStatus>();

            status.AddHealth(Health);
            status.SpeedBoost(Speed,SpeedTime);

            Destroy(gameObject);
            
        }
    }
}
