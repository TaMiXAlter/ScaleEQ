using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class RangeDamegeEnemy : DamagePlayer
{
    private float timer;


    void OnTriggerEnter2D(Collider2D other)
    {
        DamagePlayer(other);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            DamagePlayer(other);
            timer = 0f;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        timer = 0f;
    }
    private void DamagePlayer(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);

        }
    }


}
