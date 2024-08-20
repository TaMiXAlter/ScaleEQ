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

    private Animator PlayerAnimator;
    private PlayerSoundEffect PlayerSoundEffect;
    bool isKeyDown = false;
    void Start() {
        rigi = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerSoundEffect = AudioManager.Instance.PlayerSoundEffect;
    }

    private void Update()
    {
        ChargeForDash();
        Truning();
        
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(rigi.velocity.x));

        if (rigi.velocity.y < -5) {
            PlayerAnimator.SetBool("LeavingGround", true);
            PlayerSoundEffect.ToggleSlide(false);
            PlayerSoundEffect.PlayJump();
        }
        else {
            PlayerAnimator.SetBool("LeavingGround", false);
            PlayerSoundEffect.ToggleSlide(true);
            PlayerSoundEffect.PlayLand();
        }
        
    }

    void Truning()
    {
        if(rigi.velocity.x>1f) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if(rigi.velocity.x<-1f) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void ChargeForDash()
    {
        if (Input.GetKey(KeyCode.A)) {
            isKeyDown = true;
            if(movement.x > -maxSpeed) {
                movement.x -= SpeedDelta*Time.deltaTime;
                PlayerSoundEffect.PlayCharge();
            }
        }
       
        if (Input.GetKey(KeyCode.D)) {
            isKeyDown = true;
            if(movement.x < maxSpeed) {
                movement.x += SpeedDelta*Time.deltaTime;
                PlayerSoundEffect.PlayCharge();
            }
        }
     
        if (isKeyDown)
        {
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                PlayerAnimator.SetTrigger("Dash");
                rigi.AddForce(movement, ForceMode2D.Impulse);
                movement.x = 0;
                isKeyDown = false;
                PlayerSoundEffect.PlayRealease();
            }
        }
    }
    

  
}
