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
    private bool isInAir = false;

    [SerializeField] private PlayerCharge PlayerCharge;
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
        PlayerSoundEffect.SetSlideValue(Mathf.Abs(rigi.velocity.x)  /maxSpeed);

        if (rigi.velocity.y < -3 && !isInAir)
        {
            isInAir = true;
            PlayerAnimator.SetBool("LeavingGround", true);
            PlayerSoundEffect.SetSlideValue(0);
            PlayerSoundEffect.PlayJump();
        }
        else if (rigi.velocity.y >= 0 && isInAir)
        {
            isInAir = false;
            PlayerAnimator.SetBool("LeavingGround", false);
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
            if (!isKeyDown) {
                PlayerSoundEffect.PlayCharge();
            }
            isKeyDown = true;
            if(movement.x > -maxSpeed) {
                movement.x -= SpeedDelta*Time.deltaTime;
                PlayerCharge.ChangeSliderValue(Mathf.Lerp(0.5f,0,Mathf.Abs(movement.x/maxSpeed)) );
            }
        }
       
        if (Input.GetKey(KeyCode.D)) {
            if (!isKeyDown) {
                PlayerSoundEffect.PlayCharge();
            }
            isKeyDown = true;
            if(movement.x < maxSpeed) {
                movement.x += SpeedDelta*Time.deltaTime;
                PlayerCharge.ChangeSliderValue(Mathf.Lerp(0.5f,1f,Mathf.Abs(movement.x/maxSpeed)) );
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
                PlayerCharge.ChangeSliderValue(0.5f);
            }
        }
    }
    

  
}
