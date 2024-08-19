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
    

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            movement.x = -1;
        }
        else{
            if (Input.GetKeyDown(KeyCode.D)) {
                movement.x = 1;
            }
            else {
                movement.x = 0;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.W)) movement.y = 1;
        else{ 
            if (Input.GetKeyDown(KeyCode.S)) movement.y = -1;
        else movement.y = 0;
            
        }
        
        rigi.AddForce(movement,ForceMode2D.Force);
    }
}
