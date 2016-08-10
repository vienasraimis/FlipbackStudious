using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
    public float triggerTime = 1f;

    public Sprite activeSpr, inactiveSpr;

    public bool active = true;
    private bool ApplyDamage = false;
    private bool damageApplied = false;

    private SpriteRenderer rend;

    public float time;

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

        if (active && ApplyDamage && !damageApplied)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStatus>().AddHealth(-10f);

            damageApplied = true;
        }

        if(time <= 0f)
        {
            active = !active;
            damageApplied = false;

            time = triggerTime;

            if(active) rend.sprite = activeSpr;
            else rend.sprite = inactiveSpr;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            ApplyDamage = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            ApplyDamage = false;
        }
    }
}
