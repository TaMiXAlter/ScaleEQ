using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int Init_PlayerHealth;
    private int Current_PlayerHealth;

    void Start()
    {
        Current_PlayerHealth = Init_PlayerHealth;

    }

    void Update()
    {
        IfPlayerDead();
    }

    public void TakeDamage(int damage)
    {
        Current_PlayerHealth -= damage;
    }
    public bool IfPlayerDead()
    {
        if (Current_PlayerHealth <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}
