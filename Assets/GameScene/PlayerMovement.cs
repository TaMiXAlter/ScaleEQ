using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigi;
    [SerializeField]
    private Vector2 movement;
    
    [SerializeField] private float MoveSpeed;
    

    void Start() {
        rigi = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            movement.x = -1;
            rigi.AddForce(movement,ForceMode2D.Force);
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
            rigi.AddForce(movement,ForceMode2D.Force);
        }
        
        movement.x = 0;
    }
}
