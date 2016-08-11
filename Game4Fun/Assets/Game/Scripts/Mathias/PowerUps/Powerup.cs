using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour
{
    [Header("PlayerChanges")]
    public float Health = 0f;
    public float Speed = 2f;
    public float SpeedTime = 0f;

    //Particles effect - Zimon
    public GameObject powerUpParticleEffect;
    //--------

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            var status = coll.GetComponent<CharacterStatus>();

            status.AddHealth(Health);
            //status.SpeedBoost(Speed,SpeedTime);

            Destroy(gameObject);
            Instantiate(powerUpParticleEffect, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //Play particle effect when destroying PowerUp! - Zimon
        }
    }
}
