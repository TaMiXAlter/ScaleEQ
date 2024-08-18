using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : MonoBehaviour
{
    public float MoveSpeed { get; set; }
    public float amplitude { get; set; }
    public float frequency { get; set; }

    private Rigidbody2D rigi;
    private Vector2 playerPosition;
    private Vector2 lastDirection;
    private bool targetReached = false;

    public enum MovementType
    {
        HorizontalMoving,
        WavesMoving,
        FacingPlayer

    }
    public MovementType movementType;



    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        SetMovementType(movementType);
        SinWaves();
    }
    private void MoveTowardsPlayer()
    {
        //============ Direction setting
        if (!targetReached)
        {
            Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;

            if (Vector2.Distance(transform.position, playerPosition) < 0.1f)
            {
                targetReached = true;
            }
            else
            {
                lastDirection = direction;
            }
        }

        //============ Angle setting
        float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //============ Velocity setting
        rigi.velocity = lastDirection * MoveSpeed;
    }
    private void SetMovementType(MovementType movementType)
    {
        switch (movementType)
        {
            case MovementType.HorizontalMoving:
                rigi.velocity = new Vector2(MoveSpeed, rigi.velocity.y);
                break;
            case MovementType.WavesMoving:
                rigi.velocity = new Vector2(MoveSpeed, SinWaves());
                break;
            case MovementType.FacingPlayer:
                MoveTowardsPlayer();
                break;
        }
    }
    public void SetPlayerPosition(Vector2 playerPosition) //Count the player position when spawning
    {
        this.playerPosition = playerPosition;
    }
    private float SinWaves() // Count the sin waves
    {
        return Mathf.Sin(Time.time * frequency) * amplitude;
    }
}
