using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private ChargeArrow _chargeArrow;
    
    private Rigidbody2D rigi;
    [SerializeField]
    private Vector2 movement;

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float SpeedDelta = 10f;
    
    bool isKeyDown = false;
    void Start() {
        rigi = GetComponent<Rigidbody2D>();
        _chargeArrow = GameObject.Find("ChargeArrow").GetComponent<ChargeArrow>();
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
            _chargeArrow.Move(movement/maxSpeed);
        }
        
        if (isKeyDown)
        {
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                rigi.AddForce(movement, ForceMode2D.Impulse);
                movement.x = 0;
                isKeyDown = false;
                _chargeArrow.Reset();
            }
        }
       
    }
}
