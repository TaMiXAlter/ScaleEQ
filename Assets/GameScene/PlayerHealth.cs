using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int Init_PlayerHealth;
    [SerializeField] private PlayerSoundEffect _playerSoundEffect;
    public int Current_PlayerHealth { get; private set; }
    public bool takeDamage { get; private set; } = false;
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
        _playerSoundEffect.PlayHurt();
    }
    public bool IfPlayerDead()
    {
        if (Current_PlayerHealth <= 0)
        {
            Destroy(gameObject);
            _playerSoundEffect.PlayDead();
            return true;
        }
        else
        {
            return false;
        }
    }
}
