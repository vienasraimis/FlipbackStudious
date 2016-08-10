using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
    public float triggerTime = 1f;

    public Sprite activeSpr, inactiveSpr;

    private bool active = true;
    private SpriteRenderer rend;

    private float time;

    void Start()
    {
        time = triggerTime;
        rend = GetComponent<SpriteRenderer>();
        
        if(active)
        {
            rend.sprite = activeSpr;
        }
        else
        {
            rend.sprite = inactiveSpr;
        }
    }

    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;

        if(time <= 0f)
        {
            active = !active;

            time = triggerTime;

            if(active) rend.sprite = activeSpr;
            else rend.sprite = inactiveSpr;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            coll.GetComponent<CharacterStatus>().AddHealth(-10f);
        }
    }
}
