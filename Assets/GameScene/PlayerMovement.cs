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

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float SpeedDelta = 10f;
    
    bool isKeyDown = false;
    void Start() {
        rigi = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            isKeyDown = true;
            if(movement.x > -maxSpeed) {
                movement.x -= SpeedDelta*Time.deltaTime;
            }
        }
       
        if (Input.GetKey(KeyCode.D)) {
            isKeyDown = true;
            if(movement.x < maxSpeed) {
                movement.x += SpeedDelta*Time.deltaTime;
            }
        }
        
        
        if(movement.x != 0) {
            
        }
        
        if (isKeyDown)
        {
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                rigi.AddForce(movement, ForceMode2D.Impulse);
                movement.x = 0;
                isKeyDown = false;
                
            }
        }
       
    }
}
